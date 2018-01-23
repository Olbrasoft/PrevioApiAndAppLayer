using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moon.Xml.Serialization;

namespace MoonXmlSerializationTest
{
    [TestClass]
    public class TestExToSnippetXml
    {
        /// <summary>
        ///     Testuje serializaci pole integeru do Sniped Xml
        /// </summary>
        [TestMethod]
        public void TestToSnippetXmlArryInt()
        {
            var xmlForEquals = "<comIds><comId>0</comId><comId>1</comId><comId>2</comId><comId>3</comId></comIds>";
            var arrayInt = new[] {0, 1, 2, 3};

            Assert.IsTrue(arrayInt.ToSnippetXml("comIds", "comId") == xmlForEquals);
            var a = new[] {"aaa", "bbbb"};
            
            xmlForEquals = "<necos><neco>aaa</neco><neco>bbbb</neco></necos>";

            Assert.IsTrue(a.ToSnippetXml("necos", "neco") == xmlForEquals);

        }
    }
}