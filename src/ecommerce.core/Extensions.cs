using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.core
{
    public static class Extensions
    {
        public static string ToCurrency(this decimal value)
            => value.ToString("C");
        public static DateOnly ToDateOnly(this DateTime dateTime)
            => DateOnly.FromDateTime(dateTime);
        public static DateTime ToDateTime(this DateOnly dateOnly)
            => new DateTime(dateOnly.Year, dateOnly.Month, dateOnly.Day);
        public static DateOnly ToDateOnly(this DateTimeOffset dateTimeOffset)
            => DateOnly.FromDateTime(dateTimeOffset.DateTime);
        public static DateTimeOffset ToDateTimeOffset(this DateOnly dateOnly)
            => new DateTimeOffset(dateOnly.ToDateTime());
    }
}
