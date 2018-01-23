using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using Moon.Globalization.DAL.FromConfig.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Moon.Globalization.DAL.FromConfig.Web.Tests
{
    [TestClass()]
    public class DefaultCultureWebConfigReadOnlyRepositoryTests
    {
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost:2356/Default.aspx")]
        [AspNetDevelopmentServerHost("$(SolutionDir)\\TestWeb")]
        public void GetDefaultCultureTest()
        {
            var rep = new Web.DefaultCultureWebConfigReadOnlyRepository();
           Assert.IsTrue( rep.GetDefaultCulture().Name == "en");
        }
    }
}
