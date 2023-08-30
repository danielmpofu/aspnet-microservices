using AutoMapper;
using Discount.GRPC.Entities;
using Discount.GRPC.Protos;
using Discount.GRPC.Repository;
using Grpc.Core;

namespace Discount.GRPC.Services;

public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
{
    private readonly ICouponRepository couponRepository;
    private readonly IMapper mapper;
    private readonly ILogger<DiscountService> logger;

    public DiscountService(ICouponRepository couponRepository,IMapper mapper, ILogger<DiscountService> logger)
    {
        this.couponRepository = couponRepository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async override Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var coupon = couponRepository.GetDiscount(request.ProductName);
        if (coupon == null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, $"Discount with the name {request.ProductName} was not found"));
        }
        var couponModel = mapper.Map<CouponModel>(coupon);
        return couponModel;

    }

    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var coupon = mapper.Map<Coupon>(request.Coupon);
        var s = await couponRepository.CreateDiscount(coupon);
        logger.LogInformation($"done creating coupon {coupon.ProductName} -->");
        var couponModel = mapper.Map<CouponModel>(coupon);
        return couponModel;

    }

    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var coupon = mapper.Map<Coupon>(request.Coupon);
        var s = await couponRepository.UpdateDiscount(coupon.Id, coupon);
        logger.LogInformation($"done creating coupon {coupon.ProductName} -->");
        var couponModel = mapper.Map<CouponModel>(coupon);
        return couponModel;
    }

    public async override Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        var s = await couponRepository.DeleteDiscount(request.ProductName);
        logger.LogInformation($"done deleting coupon {request.ProductName} -->");
        return new DeleteDiscountResponse { Success = true };
    }
}