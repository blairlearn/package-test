using System;
using System.IO;
using System.Text.Json;

using Moq;
using Xunit;

namespace NCI.OCPL.Api.Common
{
  public partial class InterfaceJsonConverterTest
  {
    /// <summary>
    /// Expect a null value to come back as the word "null".
    /// </summary>
    [Fact]
    public void Write_NullObject()
    {
      TestType value = null;

      JsonSerializerOptions serializerOptions = new JsonSerializerOptions();

      using var stream = new MemoryStream();
      using (var writer = new Utf8JsonWriter(stream, new JsonWriterOptions()))
      {
        InterfaceJsonConverter<ITestInterface> converter = new InterfaceJsonConverter<ITestInterface>();
        converter.Write(writer, value, serializerOptions);
      }

      stream.Seek(0, SeekOrigin.Begin); // Reset stream to beginning.
      using StreamReader sr = new StreamReader(stream);
      string actual = sr.ReadToEnd();
      Assert.Equal("null", actual);

    }

    /// <summary>
    /// Expect an actual value to be serialized.
    /// </summary>
    [Fact]
    public void Write_Object()
    {
      TestType value = new TestType
      {
        StringProperty = "string value",
        IntProperty = 72,
        AdditionalProperty = "Not part of the interface"
      };
      // This is horrible, but we need a JSON comparer.
      string expected = "{\"IntProperty\":72,\"StringProperty\":\"string value\",\"AdditionalProperty\":\"Not part of the interface\"}";

      JsonSerializerOptions serializerOptions = new JsonSerializerOptions();

      using var stream = new MemoryStream();
      using (var writer = new Utf8JsonWriter(stream, new JsonWriterOptions()))
      {
        InterfaceJsonConverter<ITestInterface> converter = new InterfaceJsonConverter<ITestInterface>();
        converter.Write(writer, value, serializerOptions);
      }

      stream.Seek(0, SeekOrigin.Begin); // Reset stream to beginning.
      using StreamReader sr = new StreamReader(stream);
      string actual = sr.ReadToEnd();
      Assert.Equal(expected, actual);
    }
  }
}