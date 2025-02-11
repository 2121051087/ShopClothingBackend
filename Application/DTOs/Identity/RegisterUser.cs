using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothing.Application.DTOs.Identity
{
    public class RegisterUser : BaseModel
    {
        public required string FullName { get; set; }

        public required string ConfirmPassword { get; set; }
    }

  
}
