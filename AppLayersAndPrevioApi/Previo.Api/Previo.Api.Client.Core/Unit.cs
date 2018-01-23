using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Způsob účtování balíčku. Má význam POUZE u online rezervací. 
    /// Na Plachtě rezervací se na tyto jednotky nebere ohled a cena se určuje dle počtu balíčků.
    /// </summary>
    public class Unit
    {
        /// <summary>
        ///  pId jednotky.
        /// [1]
        /// </summary>
        [XmlElement("pcuId")]
        public int PcuId { get; set; }

        /// <summary>
        ///  Název jednotky. Cena za ...
        /// [1]
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        ///  Popisek jednotky.
        /// [1]
        /// </summary>
        [XmlElement("description")]
        public string Description { get; set; } 
        

    }



}
