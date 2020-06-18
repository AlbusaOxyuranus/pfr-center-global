using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Web;
using LogLevel = NLog.LogLevel;

namespace PFRCenterGlobal.BackendForMobile
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("########################### Startup application ############################");
            ConfigureNlog();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging(builder =>
                {
                    builder.ClearProviders(); //clear default providers, NLog will handle it
                    builder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace); //set minimum level trace, Nlog rules will kick in afterwards
                })
                .UseNLog()
                .UseStartup<Startup>();
        
        //TODO: replace with nlog.config
        private static void ConfigureNlog()
        {
            var config= new LoggingConfiguration();
            var consoleTarget = new ColoredConsoleTarget("coloredConsole")
            {
                Layout = @"${date:format=HH\:mm\:ss} ${logger} ${message} ${exception}"
            };
            
            config.AddTarget(consoleTarget);
            
            // var fileTarget = new FileTarget("file")
            // {
            //     FileName = "${basedir}/file.log",
            //     Layout = @"${date:format=HH\:mm\:ss} ${message} ${exception} ${ndlc}"
            // };
            //
            // config.AddTarget(fileTarget);
            
            config.AddRule(LogLevel.Trace, LogLevel.Info, consoleTarget,"O2.*");
            config.AddRule(LogLevel.Warn, LogLevel.Fatal, consoleTarget);
            // config.AddRule(LogLevel.Warn, LogLevel.Fatal, fileTarget);
            LogManager.Configuration = config;
        }
    }
}
