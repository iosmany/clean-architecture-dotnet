using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.core.EF
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IsUnicodeAttribute : Attribute
    {
        public bool Unicode { get; private set; }
        public IsUnicodeAttribute(bool unicode=true)
        {
            Unicode = unicode;
        }
    }
}
