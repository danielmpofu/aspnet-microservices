using Discount.GRPC.Protos;
using Discount.GRPC.Repository;

namespace Discount.GRPC.Services;

public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
{
    private readonly ICouponRepository couponRepository;
    private readonly ILogger<DiscountService> logger;

    public DiscountService(ICouponRepository couponRepository, ILogger<DiscountService> logger)
    {
        this.couponRepository = couponRepository;
        this.logger = logger;
    }


}