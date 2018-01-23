using System;
using System.Xml.Serialization;

namespace TestPrevioApiClient
{
    /// <summary>
    ///     Testovaci trida aby bylo videt jak vapadqa xml kdyz je vlastnost typu int?
    ///     respektivne null <TestProperty />
    /// </summary>
    public class TestNullClass
    {
        public int? TestProperty { get; set; }

        public DateTime? TestDate { get; set; }

        [XmlIgnore]
        public Uri Url { get; set; }
    }
}