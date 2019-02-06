using Microsoft.VisualStudio.TestTools.UnitTesting;
using SageAufbaukursCSharp.ServiceImplementations;

namespace SageAufbaukursCSharpTest
{
    [TestClass]
    public class SaveFileUtilTest
    {
        [TestMethod]
        public void TestDrivenDevelopment()
        {
            var mock = new SaveFileUtil(null);
            mock.Save(null);
        }
    }
}
