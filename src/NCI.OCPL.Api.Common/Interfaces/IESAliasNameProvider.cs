namespace NCI.OCPL.Api.Common
{
  /// <summary>
  /// Defines an interface for a class which passes an Elasticsearch alias name to
  /// a service.
  /// </summary>
  public interface IESAliasNameProvider
  {
    /// <summary>
    /// The alias name.
    /// </summary>
    public string Name { get; }
  }
}