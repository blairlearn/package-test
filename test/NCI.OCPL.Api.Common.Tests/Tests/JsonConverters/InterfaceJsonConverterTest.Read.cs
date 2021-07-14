using System;
using System.Text.Json;

using Xunit;

namespace NCI.OCPL.Api.Common
{
  public partial class InterfaceJsonConverterTest
  {
    /// <summary>
    /// The Read method should never work.
    /// </summary>
    [Fact]
    public void Read_ExpectFailure()
    {
      InterfaceJsonConverter<object> converter = new InterfaceJsonConverter<object>();

      Utf8JsonReader reader = new Utf8JsonReader();
      Type type = typeof(ITestInterface);
      JsonSerializerOptions options = new JsonSerializerOptions();

      Exception actualEx = null;

      // This can't use Assert.Throws because refs can't be passed from within a lambda.
      try
      {
        converter.Read(ref reader, type, options);
      }
      catch (Exception ex)
      {
        actualEx = ex;
      }

      Assert.NotNull(actualEx);
      Assert.IsType<NotImplementedException>(actualEx);
    }
  }
}