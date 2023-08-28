using DiscountApi.Entities;
using DiscountApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiscountApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly ICouponRepository couponRepository;

        public CouponsController(ICouponRepository couponRepository)
        {
            this.couponRepository = couponRepository;
        }

        [HttpGet("{productName}")]
        public async Task<ActionResult<Coupon>> GetCoupons(string productName)
        {
            var coupon = await couponRepository.GetDiscount(productName);
            return Ok(coupon);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateDiscount(string couponId, [FromBody] Coupon coupon)
        {
            var updated = await couponRepository.UpdateDiscount(couponId: couponId, coupon: coupon);
            return Ok(updated);
        }

  
        [HttpDelete("{productName}")]
        public async Task<ActionResult<bool>> DeleteCoupon(string productName)
        {
           var deleted = couponRepository.DeleteDiscount(productName);
            return Ok(deleted);
        }
    }

}
