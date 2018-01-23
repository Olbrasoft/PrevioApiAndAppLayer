using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moon.Configuration;

namespace TestPrevioApiClient
{
    /// <summary>
    /// 
    /// </summary>

    public class ExampleAdvanceConfiguration : ConfigurationSection
    {

        [ConfigurationProperty("dalsiVlastnosti", IsRequired = true)]
        public GenericConfigurationElementCollection<ItemConfiguration> KolekceVlastnosti
        {
            get { return (GenericConfigurationElementCollection<ItemConfiguration>)this["dalsiVlastnosti"]; }
        }

        [ConfigurationProperty("spolecnaVlastnost")]
        public string SpolecnaVlastnost
        {
            get { return this["spolecnaVlastnost"] as string; }
        }
        
    }



    public class ItemConfiguration: ConfigurationElement
    {
         [ConfigurationProperty("exampleNeco1",IsKey=true) ]
        public string Neco1
        {
            get { return this["exampleNeco1"] as string; }
        }

         [ConfigurationProperty("exampleNeco2")]
         public string Neco2
         {
             get { return this["exampleNeco2"] as string; }
         }
    }


    //public class ItemConfigurationCollection : ConfigurationElementCollection
    //{
    //    protected override ConfigurationElement CreateNewElement()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    protected override object GetElementKey(ConfigurationElement element)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}


}
