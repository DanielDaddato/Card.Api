using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Card.Api.Models
{
    public class CardData
    {
        public long CardNumber { get; set; }
        public DateTime RegistrationData { get; set; }
        public int CVV { get; set; }

    }
}
