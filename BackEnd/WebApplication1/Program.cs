using DAL.Context;
using DAL.Repositories;
using BLL.Services;
using Microsoft.EntityFrameworkCore;
namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var allowedOrigines = "myOri";
            builder.Services.AddDbContext<DBContext>(op =>
            {
                op.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });
            builder.Services.AddCors(op =>
            {
                op.AddPolicy(allowedOrigines, po =>
                {
                    po.AllowAnyMethod();
                    po.AllowAnyHeader();
                    po.AllowAnyOrigin();
                });
            });
            builder.Services.AddControllers();
            builder.Services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            var app = builder.Build();
            app.UseCors(allowedOrigines);
            app.MapControllers();
            app.Run();
        }
    }
}
