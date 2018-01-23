using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moon.Globalization;

namespace Test.Moon.Globalization
{
    [TestClass]
    public class TestParser
    {
        private ICultureInfoParser Parser;

        [TestInitialize()]
        public void Init()
        {
            Parser = new CultureInfoParser();
        }


        [TestMethod]
        public void TestGoodParser()
        {
            string s = "cs";
            System.Globalization.CultureInfo c;
            Parser.TryParse(s, out c);

            s = "en-Us";
            Parser.TryParse(s, out c);
            Assert.IsTrue(c.Name == new System.Globalization.CultureInfo(s).Name);

            Assert.IsTrue(Parser.Parse("de-De").Name == new System.Globalization.CultureInfo("de-DE").Name);
        }
        

        [TestMethod]
        public void TestExceptionParser()
        {
            Assert.IsNotNull(Parser);
            string s = null;
            System.Globalization.CultureInfo c;

            try
            {
                Parser.TryParse(s, out c);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetType() == typeof (ArgumentNullException));
            }


            try
            {
                s = "aaa";
                var cult = Parser.Parse(s);

            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetType() == typeof (FormatException));

            }
        }
    }
}
