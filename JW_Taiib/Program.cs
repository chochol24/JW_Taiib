using BLL.Interfaces;
using BLL_EF;
using DAL;
namespace JW_Taiib
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<ProductBLL, ProductBLL_EF>();
            builder.Services.AddScoped<OrderBLL, OrderBLL_EF>();
            builder.Services.AddScoped<BasketPositionBLL, BasketPositionBLL_EF>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<WebShopContext>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors(optBuilder => optBuilder
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowAnyOrigin()
                                .Build());
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}