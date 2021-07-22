using System;
using System.IO;

using Newtonsoft.Json.Linq;
using Xunit;

namespace NCI.OCPL.Api.Common.Testing
{
  public partial class TestingToolsTests
  {
    [Fact]
    public void GetDataFileAsJObject_Null()
    {
      Assert.Throws<ArgumentNullException>(
        () => TestingTools.GetDataFileAsJObject(null)
      );
    }

    [Fact]
    public void GetDataFileAsJObject_NonexistingFile()
    {
      Assert.Throws<FileNotFoundException>(
        () => TestingTools.GetDataFileAsJObject("NonExistingFile.json")
      );
    }

    [Theory]
    [InlineData("structured.json", @"{
                                        ""string"": ""string-value"",
                                        ""integer"": 5,
                                        ""null"": null,
                                        ""object"": {
                                          ""member1"": ""member"",
                                          ""member2"": 42
                                        }
                                      }")]
    public void GetDataFileAsJObject_SimpleString(string filename, string expectedValue)
    {
      JObject expected = JObject.Parse(expectedValue);

      string path = Path.Join("Tools/TestingTools/GetDataFileAsJObject", filename);
      JObject actual = TestingTools.GetDataFileAsJObject(path);

      Assert.Equal(expected, actual, new JTokenEqualityComparer());
    }

  }
}