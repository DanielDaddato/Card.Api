using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Card.Api.Helper
{
    public class ValidateIntSizeAttribute : ValidationAttribute
    {
        private int _maxSize { get; set; }

        public ValidateIntSizeAttribute(int maxSize)
        {
            _maxSize = maxSize;
        }

        public override bool IsValid(object value)
        {
            int attribute = Convert.ToInt32(value);

            bool result = attribute.ToString().Length <= _maxSize;

            return result;
        }
    }
}
