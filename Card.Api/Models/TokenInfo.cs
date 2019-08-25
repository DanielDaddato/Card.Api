using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Card.Api.Models
{
    public class TokenInfo
    {
        public long Token { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
