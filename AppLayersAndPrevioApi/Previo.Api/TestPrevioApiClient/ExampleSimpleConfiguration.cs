using System;
using System.Collections.Generic;
using System.Configuration;


namespace TestPrevioApiClient
{
    /// <summary>
    /// 
    /// </summary>

    public class ExampleSimpleConfiguration : ConfigurationSection
    {

        [ConfigurationProperty("exampleType")]
        public string NejakaHodnodaTypu
        {
            get { return this["exampleType"] as string; }
        }


        [ConfigurationProperty("exampleName")]
        public string NejakeJmeno
        {
            get { return this["exampleName"] as string; }
        }

    }
}
