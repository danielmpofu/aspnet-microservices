using System.Runtime.CompilerServices;

namespace DiscountApi.Extensions
{
    public static class HostExtensions
    {
        public static DateTime AddCenturies(this DateTime date)
        {
            return date.AddDays(1);
        }
    }
}
