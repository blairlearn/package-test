using System;

namespace NCI.OCPL.Api.Common
{

  /// <summary>
  /// Helper class to relay the name of the Elasticsearch alias to use for healthchecks from
  /// the application-specific initialization code to the ESHealthCheckService.
  /// </summary>
  public class ESAliasNameProvider : IESAliasNameProvider
  {
    private string _name;

    /// <summary>
    /// Name of the alias to use for the healthcheck.
    /// </summary>
    public string Name
    {
      get { return _name; }
      set
      {
        if (String.IsNullOrWhiteSpace(value))
          throw new ArgumentNullException(nameof(Name));

        _name = value;
      }
    }
  }
}