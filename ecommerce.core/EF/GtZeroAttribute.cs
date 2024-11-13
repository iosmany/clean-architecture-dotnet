using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.core.EF
{
    /// <summary>
    /// Greater than zero, not zero
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class GtZeroAttribute : ValidationAttribute
    {
        readonly Type[] _types = new Type[] { typeof(int), typeof(long), typeof(decimal), typeof(uint), typeof(ulong), typeof(byte), typeof(short) }; 

        public override bool IsValid(object? value)
        {
            if (value is null)
                return false;

            var currentType = value.GetType();
            if (!_types.Contains(currentType))
                throw new NotSupportedException("The type is not supported");   

            return value switch
            {
                int i => i > 0,
                long l => l > 0,
                decimal d => d > 0,
                uint ui => ui > 0,
                ulong ul => ul > 0,
                byte b => b > 0,
                short s => s > 0,
                _ => false
            };
        }
    }
}
