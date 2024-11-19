using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.domain
{
    //When is more accurate to use ValueObject? 
    //When you have a class that is small and has no identity, it is a good candidate to be a ValueObject.

    public abstract class ValueObject
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object? obj)
        {
            if(obj == null || obj.GetType() != GetType())
                return false;

            var valueObject = (ValueObject)obj;
            if(valueObject.Equals(this))
                return true;
            
            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Aggregate( 1, 
                    (current, obj) => {

                        unchecked // unchecked keyword is used to remove overflow-checking for integral-type arithmetic operations and conversions.
                        {
                            return (current * 23) + (obj?.GetHashCode() ?? 0);
                        }
                    });
        }

        public static bool operator ==(ValueObject a, ValueObject b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject a, ValueObject b)
        {
            return !(a == b);
        }

    }
}
