using Card.Api.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Card.Api.Models
{
    public class ValidationInfo
    {
        [Required]
        public long Token { get; set; }

        [Required]
        [ExpirationDate(ErrorMessage = "Token Expired")]
        public DateTime RegistrationDate { get; set; }

        [Required]
        [ValidateIntSize(5, ErrorMessage = "CVV length must be at maximum 5 characters.")]
        public int CVV { get; set; }
    }
}
