using Dapper;
using Discount.GRPC.Entities;
using Npgsql;

namespace Discount.GRPC.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly IConfiguration configuration;
        private readonly NpgsqlConnection connection;
        public CouponRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connection = new NpgsqlConnection(this.configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        }
        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            var affected = await connection.ExecuteAsync("insert into Coupon (ProductName,Description,Amount) values (@ProductName,@Description,@Amount)",
                new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });

            return affected != 0;

        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            var q = "delete from coupon where ProductName =@ProductName";
            var deleted = await connection.ExecuteAsync(q, new { ProductName = productName});
            return deleted != 0;
        }

        public async Task<Coupon> GetDiscount(string productName)
        {
            var q = "Select * from Coupon where ProductName = @ProductName";
            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>(q, new { ProductName = productName });
            if (coupon == null)
                return new Coupon
                {
                    Amount = 0,
                    Description = "No discounts available for this product at the moment",
                    Id = 221,
                    ProductName = "No Discount"
                };
            return coupon;
        }

        public async Task<bool> UpdateDiscount(string couponId, Coupon coupon)
        {
            var affected = await connection.ExecuteAsync("update Coupon SET ProductName = @ProductName , Description = @Description , Amount = @Amount wher Id=@Id",
                new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount, Id =  couponId });

            return affected != 0;
        }
    }
}
