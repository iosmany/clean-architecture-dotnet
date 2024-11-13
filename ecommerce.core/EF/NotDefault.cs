using System.ComponentModel.DataAnnotations;

namespace ecommerce.core.EF
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class NotDefaultAttribute : ValidationAttribute
    {
        public NotDefaultAttribute()
        { }

        public override bool IsValid(object? value)
        {
            if (value is null)
                return false;
            return value != GetDefaultValue(value) == false;
        }

        object? GetDefaultValue(object? value)
        {
            return value switch
            {
                null => null,
                string s => default(string),
                int i => default(int),
                uint i => default(uint),
                long l => default(long),
                float f => default(float),
                double d => default(double),
                decimal d => default(decimal),
                bool b => default(bool),
                DateTimeOffset dateTimeOffset => default(DateTimeOffset),
                DateTime dateTime => default(DateTime),
                TimeSpan timeSpan => default(TimeSpan),
                _ => Activator.CreateInstance(value.GetType())
            };
        }
    }
}
