using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace NCI.OCPL.Api.Common
{
  /// <summary>
  /// Base class for the "Program" class containing an API's entry point.
  /// </summary>
  public abstract class NciApiProgramBase
  {

    /// <summary>
    /// Builds a host for the web application
    /// </summary>
    /// <param name="args"></param>
    /// <typeparam name="TStartup">The API's startup class.</typeparam>
    /// <returns></returns>
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