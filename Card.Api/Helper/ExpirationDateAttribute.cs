using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Card.Api.Helper
{
    public class ExpirationDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var date = Convert.ToDateTime(value);
            var timeSpan = DateTime.UtcNow - date;

            if (timeSpan.Minutes <= 15)
            {
                return true;
            }
            return false;            
        }
    }
}
