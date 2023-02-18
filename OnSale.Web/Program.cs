using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OnSale.Web.Data;

namespace OnSale.Web
{
    public class Program
    {

        /*****************************************************
         ***************** * * PRODUCCTION  * * **************
         *****************************************************/
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
             .UseUrls("http://0.0.0.0:5000")
             .UseStartup<Startup>();

        /*****************************************************
         ***************** * * WITH SEED DB * * **************
         *****************************************************/
        //public static void Main(string[] args)
        //{
        //    IWebHost host = CreateWebHostBuilder(args).Build();
        //    RunSeeding(host);
        //    host.Run();
        //}

        //private static void RunSeeding(IWebHost host)
        //{
        //    IServiceScopeFactory scopeFactory = host.Services.GetService<IServiceScopeFactory>();
        //    using (IServiceScope scope = scopeFactory.CreateScope())
        //    {
        //        SeedDb seeder = scope.ServiceProvider.GetService<SeedDb>();
        //        seeder.SeedAsync().Wait();
        //    }
        //}

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        //{
        //    return WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>();
        //}
    }
}
