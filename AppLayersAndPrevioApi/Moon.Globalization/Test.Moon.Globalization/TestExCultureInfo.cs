using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moon.Globalization;
namespace Test.Moon.Globalization
{
    [TestClass]
    public class TestExCultureInfo
    {
        [TestMethod]
        public void TestToNeutralCultureFromChildCulture()
        {
            var culture = new System.Globalization.CultureInfo("cs-CZ");

            Assert.IsTrue(culture.ToNeutralCulture().IsNeutralCulture);
        }

        [TestMethod]
        public void TestToNeutralCultureFromNeutralCulture()
        {
            var culture = new System.Globalization.CultureInfo("cs");

            Assert.IsTrue(culture.ToNeutralCulture().IsNeutralCulture);
        }


        [TestMethod]
        public void TestExceptionToNeutralCultureFrom()
        {
            var culture = new System.Globalization.CultureInfo("cs").Parent;

            try
            {
                culture.ToNeutralCulture();
                Assert.Fail("Tohle nemělo projít defaultní invariant culture nelze prevest NeutralCulture  ");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
                
            }

         
        }

    }
}
