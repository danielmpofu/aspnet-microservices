using Discount.GRPC.Entities;

namespace Discount.GRPC.Repository
{
    public interface ICouponRepository
    {
        Task<Coupon> GetDiscount(string productName);
        Task<bool> CreateDiscount(Coupon coupon);
        Task<bool> UpdateDiscount(string couponId ,Coupon coupon);
        Task<bool> DeleteDiscount(string productName);
    }
}
