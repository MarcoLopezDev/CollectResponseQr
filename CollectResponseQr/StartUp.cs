using CollectResponseQr.Data;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;

[assembly: FunctionsStartup(typeof(CollectResponseQr.StartUp))]
namespace CollectResponseQr
{
    public class StartUp : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
            //var connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            builder.Services.AddDbContext<ApplicationDbContext>(
              options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionString));
        }
    }
}
