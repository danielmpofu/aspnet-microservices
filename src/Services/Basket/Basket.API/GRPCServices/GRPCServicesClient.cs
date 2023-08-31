using Discount.GRPC.Protos;

namespace Basket.API.GRPCServices
{
    public class GRPCServicesClient
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient discountProtoService;

        public GRPCServicesClient(DiscountProtoService.DiscountProtoServiceClient discountProtoService)
        {
            this.discountProtoService = discountProtoService;
        }

        public async Task<CouponModel> GetDiscount(string productName)
        {
            var discountRequest = new GetDiscountRequest { ProductName = productName };
            return await discountProtoService.GetDiscountAsync(discountRequest);
        }
    }
}
