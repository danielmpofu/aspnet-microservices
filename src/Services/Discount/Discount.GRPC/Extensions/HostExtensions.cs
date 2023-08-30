using System.Runtime.CompilerServices;

namespace Discount.GRPC.Extensions
{
    public static class HostExtensions
    {
        public static DateTime AddCenturies(this DateTime date)
        {
            return date.AddDays(1);
        }
    }
}
