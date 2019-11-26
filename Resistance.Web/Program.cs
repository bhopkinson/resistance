using MessagePack;
using MessagePack.Resolvers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Resistance.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel(o =>
                {
                    //o.ListenAnyIP(1883, l => l.UseMqtt());
                    o.ListenAnyIP(5000); // default http pipeline
                })
                .UseStartup<Startup>();
    }
}
