using Nest;
using Newtonsoft.Json;

namespace integration_test_harness
{
  /// <summary>
  /// Demonstration of Elasticsearch serialization.
  /// </summary>
  public class CustomSerializationModel
  {
    /// <summary>
    /// Property which uses default serialization.
    /// </summary>
    [Text(Name = "default")]
    public string Default { get; set; }

    /// <summary>
    /// Property which uses custom serialization to convert an array
    /// to a single value.
    /// </summary>
    [Text(Name = "custom")]
    [JsonConverter(typeof(CustomJsonConverter))]
    public string Custom { get; set; }
  }
}