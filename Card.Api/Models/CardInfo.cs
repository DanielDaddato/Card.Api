using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Card.Api.Helper;

namespace Card.Api.Models
{
    public class CardInfo
    {
        [Required]
        [ValidateLongSize(16, ErrorMessage = "CardNumber length must be at maximum 16 characters.")]
        public long CardNumber { get; set; }

        [Required]
        [ValidateIntSize(5, ErrorMessage = "CVV length must be at maximum 5 characters.")]
        public int CVV { get; set; }
    }
}
