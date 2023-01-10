using MediatR;
using Microsoft.EntityFrameworkCore;
using VehiclesService.Data;
using VehiclesService.Data.Context;
using VehiclesService.Data.Repos;
using VehiclesService.Domain.Contracts;
using VehiclesService.Domain.Contracts.Context;
using VehiclesService.Domain.Contracts.Repos;
using VehiclesService.Domain.ViewModels;

namespace VehiclesService.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            #region Conexão com MySql
            var host = config["DB:HOST"];
            var port = config["DB:PORT"];
            var user = config["DB:USER"];
            var password = config["DB:PASSWORD"];
            var database = config["DB:DATABASE"];

            var connectionString = $"server=10.100.115.6;port=33067;database=dev-vehicles;userid=sa;pwd=Onsoft@2019#Apps";

            services.AddDbContext<VehiclesContext>(
              options => options.UseMySql(connectionString,
                                           ServerVersion.AutoDetect(connectionString),
                                             x =>
                                             {
                                                 //x.MigrationsAssembly(typeof(VehiclesContext).Assembly.FullName);
                                             }).LogTo(Console.WriteLine, LogLevel.Information));
            #endregion

            #region Repository pattern
            services.AddScoped<IDataContext, VehiclesContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region Repos
            services.AddScoped<IBrandRepo, BrandRepo>();
            //services.AddScoped<IModelRepo, ModelRepo>();
            //services.AddScoped<IVehicleRepo, VehicleRepo>();
            #endregion

            #region Mediatr
            //services.AddMediatR(AppDomain.CurrentDomain.Load("VehiclesService"));
            #endregion

            #region AutoMapper
            //services.AddAutoMapper(typeof(MapProfile));
            #endregion

            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var ctx = scope.ServiceProvider.GetRequiredService<VehiclesContext>();

            ctx.Database.Migrate();

            return app;
        }
    }
}
