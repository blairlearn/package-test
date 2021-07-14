namespace NCI.OCPL.Api.Common
{
  /// <summary>
  /// We can't mock interfaces, so....
  /// </summary>
  public interface ITestInterface
  {
    int IntProperty { get; set; }
    string StringProperty { get; set; }
  }
  public class TestType : ITestInterface
  {
    public int IntProperty { get; set; }
    public string StringProperty { get; set; }
    public string AdditionalProperty { get; set; }
  }

}