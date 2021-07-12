using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace NCI.OCPL.Api.Common
{
  public abstract class NciApiProgramBase
  {
    public static IHostBuilder CreateHostBuilder<TStartup>(string[] args)
      where TStartup : NciStartupBase =>
        Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
          webBuilder.UseStartup<TStartup>()
          .ConfigureLogging((hostingContext, logging) =>
          {
            logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
            logging.AddConsole();
            logging.AddDebug();
          });
        });


  }
}