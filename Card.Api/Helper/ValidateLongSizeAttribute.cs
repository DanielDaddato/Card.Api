using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Card.Api.Helper
{
    public class ValidateLongSizeAttribute : ValidationAttribute
    {
        private int _maxSize { get; set; }

        public ValidateLongSizeAttribute(int maxSize)
        {
            _maxSize = maxSize;
        }
        public override bool IsValid(object value)
        {
            long attribute = Convert.ToInt64(value);

            bool result = attribute.ToString().Length <= _maxSize;

            return result;
        }
    }
}
