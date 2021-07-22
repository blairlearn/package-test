using System;
using System.IO;

using Newtonsoft.Json.Linq;
using Xunit;

namespace NCI.OCPL.Api.Common.Testing
{
  public partial class TestingToolsTests
  {
    [Fact]
    public void GetDataFileAsJToken_Null()
    {
      Assert.Throws<ArgumentNullException>(
        () => TestingTools.GetDataFileAsJToken(null)
      );
    }

    [Fact]
    public void GetDataFileAsJToken_NonexistingFile()
    {
      Assert.Throws<FileNotFoundException>(
        () => TestingTools.GetDataFileAsJToken("NonExistingFile.json")
      );
    }

    [Theory]
    [InlineData("simple-string.json", @"""This is a simple string""")]
    [InlineData("simple-integer.json", @"42")]
    [InlineData("simple-null.json", @"null")]
    [InlineData("structured.json", @"{
                                        ""string"": ""string-value"",
                                        ""integer"": 5,
                                        ""null"": null,
                                        ""object"": {
                                          ""member1"": ""member"",
                                          ""member2"": 42
                                        }
                                      }")]
    public void GetDataFileAsJToken_SimpleString(string filename, string expectedValue)
    {
      JToken expected = JToken.Parse(expectedValue);

      string path = Path.Join("Tools/TestingTools/GetDataFileAsJToken", filename);
      JToken actual = TestingTools.GetDataFileAsJToken(path);

      Assert.Equal(expected, actual, new JTokenEqualityComparer());
    }

  }
}