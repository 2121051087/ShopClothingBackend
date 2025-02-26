using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ShopClothing.Application.Services.Interfaces.PayPal;

using System.Globalization;
using System.Net.Http.Json;


namespace ShopClothing.Application.Services.Implementations.PayPal
{
    public class PayPalService : IPayPalService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly ILogger<PayPalService> _logger;
        private string _accessToken;

        public PayPalService(HttpClient httpClient, IConfiguration config, ILogger<PayPalService> logger)
        {
            _httpClient = httpClient;
            _config = config;
            _logger = logger;
        }

        // Lấy Access Token từ PayPal API
        private async Task<string> GetAccessTokenAsync()
        {
            if (!string.IsNullOrEmpty(_accessToken)) return _accessToken;

            var clientId = _config["PayPal:ClientId"];
            var secret = _config["PayPal:ClientSecret"];
            var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{secret}"));

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

            var response = await _httpClient.PostAsync("https://api-m.sandbox.paypal.com/v1/oauth2/token",
                new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded"));

            if (!response.IsSuccessStatusCode) throw new Exception("Failed to retrieve PayPal access token");

            var result = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
            _accessToken = result.RootElement.GetProperty("access_token").GetString()!;

            return _accessToken!;
        }

        

        //// Xác nhận thanh toán
        //public async Task<bool> CapturePaymentAsync(string paymentId)
        //{
        //    var accessToken = await GetAccessTokenAsync();
        //    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        //    var response = await _httpClient.PostAsync($"https://api-m.sandbox.paypal.com/v2/checkout/orders/{paymentId}/capture", null);
        //    return response.IsSuccessStatusCode;
        //}

        public async Task<bool> CapturePaymentAsync(string orderId)
        {
            var accessToken = await GetAccessTokenAsync();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var request = new HttpRequestMessage(HttpMethod.Post, $"https://api-m.sandbox.paypal.com/v2/checkout/orders/{orderId}/capture");

            // Gửi request với nội dung rỗng
            request.Content = new StringContent("", Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"PayPal Capture Error: {errorMessage}");
                return false;
            }

            return true;
        }





        public async Task<(string ApprovalUrl, string OrderID)> CreatePaymentAsync(decimal amount)
        {
            var accessToken = await GetAccessTokenAsync();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var requestBody = new
            {
                intent = "CAPTURE",
                purchase_units = new[]
                {
            new
            {
                amount = new
                {
                    currency_code = "USD",
                    value = amount.ToString("F2", CultureInfo.InvariantCulture)
                }
            }
        },
                application_context = new
                {
                    return_url = "https://localhost:7264/api/orders/return",
                    cancel_url = "https://localhost:7264/api/orders/return",

                     //return_url = "https://postman-echo.com/get?status=success",
                     //cancel_url = "https://postman-echo.com/get?status=cancel",
                     brand_name = "ShopClothing",  // Tên cửa hàng
                     landing_page = "BILLING",  // Chuyển hướng thẳng đến thanh toán
                     user_action = "PAY_NOW" // Nhấn "Pay Now" ngay lập tức

                }
            };

            var response = await _httpClient.PostAsJsonAsync("https://api-m.sandbox.paypal.com/v2/checkout/orders", requestBody);
            if (!response.IsSuccessStatusCode) return (null!, null!);

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var orderData = JsonSerializer.Deserialize<JsonElement>(jsonResponse);
            var orderID = orderData.GetProperty("id").GetString();  // ✅ Lấy orderID từ PayPal
            var approvalUrl = orderData.GetProperty("links").EnumerateArray()
                .FirstOrDefault(link => link.GetProperty("rel").GetString() == "approve")
                .GetProperty("href").GetString();

            return (approvalUrl!, orderID!);
        }


    }
}
