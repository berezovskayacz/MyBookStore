using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using NLog.Web;

namespace MyBookstore.Web.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://localhost:5001")
                .UseKestrel()
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseNLog()
                .Build();
    }



}

