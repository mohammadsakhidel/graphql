using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace GraphQLServer
{
    public class Program
    {
        public static IHost Host { get; private set; }

        public static void Main(string[] args)
        {
            Host = CreateHostBuilder(args).Build();
            Host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
