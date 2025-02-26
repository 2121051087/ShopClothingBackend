
using AutoMapper;
using Microsoft.AspNetCore.Http;
using ShopClothing.Application.DTOs;
using ShopClothing.Application.DTOs.Order;
using ShopClothing.Application.Services.Interfaces.Cart;
using ShopClothing.Application.Services.Interfaces.Order;
using ShopClothing.Application.Services.Interfaces.PayPal;
using ShopClothing.Domain.Entities.Order;
using ShopClothing.Domain.Entities.Payment;
using ShopClothing.Domain.Interface;
using ShopClothing.Domain.Interface.Order;
using ShopClothing.Domain.Interface.Transaction;
using System.Security.Claims;

namespace ShopClothing.Application.Services.Implementations.Order
{
    public class OrderService : IOrderService
    {
        private readonly IPayPalService _payPalService;
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;
        private readonly IGeneric<Orders> _orderInterface;
        private readonly IGeneric<OrderDetails> _orderDetailInterface;

        private readonly IGeneric<Transactions> _transactionInterface;
        private readonly IOrderRepository _orderRepository;

        private readonly ITransactionRepository _transactionRepository;

        public OrderService(IGeneric<Orders> orderInterface, IGeneric<OrderDetails> orderDetailInterface,
            IPayPalService payPalService, IMapper mapper, ICartService cartService
            , IGeneric<Transactions> transactionInterface, ITransactionRepository transactionRepository, IOrderRepository orderRepository)
        {


            _mapper = mapper;


            _payPalService = payPalService;
            _cartService = cartService;


            _orderInterface = orderInterface;
            _orderDetailInterface = orderDetailInterface;
            _transactionInterface = transactionInterface;

            _orderRepository = orderRepository;
            _transactionRepository = transactionRepository;

        }


        public async Task<ServiceResponse> CreateOrderCashOnDeliveryAsync(CreateOrder order)
        {

            var mappedData = _mapper.Map<Orders>(order);
            mappedData.OrderID = Guid.NewGuid();

            var existCart = await _cartService.GetCartAsync(order.UserID!);
            if (existCart.CartItems == null)
            {
                return new ServiceResponse(false, "Cart is empty");

            }
            foreach (var item in existCart.CartItems)
            {
                decimal TotalPrice = item.QuantityBasket * item.GetProduct!.Price;
                mappedData.TotalAmount += TotalPrice;
            }


            int result = await _orderInterface.AddAsync(mappedData);
            if (result <= 0) return new ServiceResponse(false, "Order Not Created");

            var orderDetails = _mapper.Map<List<OrderDetails>>(existCart.CartItems);
            orderDetails.ForEach(x => x.OrderID = mappedData.OrderID);
            orderDetails.ForEach(x => x.OrderDetailID = Guid.NewGuid());

            var resultOrderDetail = await _orderDetailInterface.AddRangeAsync(orderDetails);

            if (resultOrderDetail <= 0) return new ServiceResponse(false, "Order detail not Created");


            return new ServiceResponse(true, "Order Created Successfully");
        }




        //public async Task<(string ApprovalUrl, Guid TransactionID)> CreateOrderAsyncWithPayPal(CreateOrder order)
        //{
        //    var existCart = await _cartService.GetCartAsync(order.UserID!);
        //    if (existCart.CartItems == null || !existCart.CartItems.Any())
        //        return (null!, Guid.Empty);

        //    decimal totalAmount = existCart.CartItems.Sum(item => item.QuantityBasket * item.GetProduct!.Price);

        //    // Gọi PayPal API để tạo đơn hàng
        //    var approvalUrl = await _payPalService.CreatePaymentAsync(totalAmount);
        //    if (string.IsNullOrEmpty(approvalUrl)) return (null!, Guid.Empty);


        //    var transaction = new Transactions
        //    {
        //        TransactionID = Guid.NewGuid(),
        //        Status = "Pending",
        //        Amount = totalAmount,
        //        Currency = "USD",
        //        TransactionDate = DateTime.UtcNow.AddHours(7),
        //        PaymentReference = Guid.NewGuid().ToString(),

        //    };
        //    await _transactionInterface.AddAsync(transaction);


        //    var mappedData = _mapper.Map<Orders>(order);
        //    mappedData.OrderStatus = "Pending";
        //    mappedData.OrderID = Guid.NewGuid();
        //    await _orderInterface.AddAsync(mappedData);

        //    var orderDetails = _mapper.Map<List<OrderDetails>>(existCart.CartItems);
        //    orderDetails.ForEach(x => x.OrderID = mappedData.OrderID);
        //    orderDetails.ForEach(x => x.OrderDetailID = Guid.NewGuid());
        //    await _orderDetailInterface.AddRangeAsync(orderDetails);



        //    return (approvalUrl, transaction.TransactionID);
        //}


        public async Task<(string ApprovalUrl, Guid TransactionID)> CreateOrderAsyncWithPayPal(CreateOrder order)
        {
            var existCart = await _cartService.GetCartAsync(order.UserID!);
            if (existCart.CartItems == null || !existCart.CartItems.Any())
                return (null!, Guid.Empty);

            decimal totalAmount = existCart.CartItems.Sum(item => item.QuantityBasket * item.GetProduct!.Price);

            // Gọi PayPal API để tạo đơn hàng và lấy orderID
            var (approvalUrl, orderID) = await _payPalService.CreatePaymentAsync(totalAmount);
            if (string.IsNullOrEmpty(approvalUrl) || string.IsNullOrEmpty(orderID)) return (null!, Guid.Empty);

            // Tạo giao dịch với PaymentReference = orderID của PayPal
            var transaction = new Transactions
            {
                TransactionID = Guid.NewGuid(),
                Status = "Pending",
                Amount = totalAmount,
                Currency = "USD",
                TransactionDate = DateTime.UtcNow.AddHours(7),
                PaymentReference = orderID
            };
            await _transactionInterface.AddAsync(transaction);

            var mappedData = _mapper.Map<Orders>(order);
            mappedData.OrderStatus = "Pending";
            mappedData.OrderID = Guid.NewGuid();
            mappedData.TransactionID = transaction.TransactionID;
            mappedData.TotalAmount = totalAmount;
            await _orderInterface.AddAsync(mappedData);

            var orderDetails = _mapper.Map<List<OrderDetails>>(existCart.CartItems);
            orderDetails.ForEach(x => x.OrderID = mappedData.OrderID);
            orderDetails.ForEach(x => x.OrderDetailID = Guid.NewGuid());
            await _orderDetailInterface.AddRangeAsync(orderDetails);

            return (approvalUrl, transaction.TransactionID);
        }


        public async Task<ServiceResponse> ConfirmPayPalPayment(Guid transactionId)
        {
            var transaction = await _transactionInterface.GetByIdAsync(transactionId);
            if (transaction == null) return new ServiceResponse(false, "Transaction not found");
            var order = await _orderRepository.GetOrderByTransactionID(transaction.TransactionID);

            var isSuccess = await _payPalService.CapturePaymentAsync(transaction.PaymentReference);
            if (!isSuccess)
            {
                transaction.Status = "Failed";
                await _transactionInterface.UpdateAsync(transaction);

                if (order != null)
                {
                    order.OrderStatus = "Failed";
                    await _orderInterface.UpdateAsync(order);
                }


                return new ServiceResponse(false, "Payment Failed");
            }

            transaction.Status = "Completed";
            await _transactionInterface.UpdateAsync(transaction);

            // Cập nhật trạng thái đơn hàng (Order) sang "Completed"
            if (order != null)
            {
                order.OrderStatus = "Completed";
                await _orderInterface.UpdateAsync(order);
            }

            return new ServiceResponse(true, "Payment Successful");
        }


        public async Task<ServiceResponse> PayPalReturn( string token, string PayerID)
        {
            if ( string.IsNullOrEmpty(token) || string.IsNullOrEmpty(PayerID))
                return new ServiceResponse(false, "Invalid request");
            var transaction = await _transactionRepository.GetTransactionByPaymentID(token);

            if (transaction == null) return new ServiceResponse(false, "Transaction not found");

            var order = await _orderRepository.GetOrderByTransactionID(transaction.TransactionID);


            // Gọi API capture của PayPal để xác nhận thanh toán
            var isSuccess = await _payPalService.CapturePaymentAsync(token);
            if (!isSuccess)
            {
                    transaction.Status = "Failed";
                    await _transactionInterface.UpdateAsync(transaction);
                if (order != null)
                {
                    order.OrderStatus = "Failed";
                    await _orderInterface.UpdateAsync(order);
                }
                return new ServiceResponse(false, "Payment Capture Failed");

            }
            transaction.Status = "Completed";
            transaction.PayerID = PayerID; // Lưu PayerID vào DB nếu cần
            
            await _transactionInterface.UpdateAsync(transaction);
                
            
            if (order != null)
                {
                    order.OrderStatus = "Completed";
                    await _orderInterface.UpdateAsync(order);
                }
            return new ServiceResponse(true, "Payment Successful");
           



        }
    }
}
 