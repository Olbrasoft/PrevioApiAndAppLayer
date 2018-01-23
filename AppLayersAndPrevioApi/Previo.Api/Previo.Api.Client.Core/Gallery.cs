using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Galerie fotek hotelu okolí a balíčků.
    /// </summary>
    [XmlType("gallery")]
    public struct Gallery
    {   
        /// <summary>
        /// Id galerie
        /// </summary>
       [XmlElement("galId")]
       public int GalId { get; set; }

       /// <summary>
       /// Popisek galerie
       /// </summary>
       [XmlElement("label")]
       public string Label { get; set; }

       /// <summary>
       /// Určuje, zda-li je galerie profilová (do profilové fotogalerie jsou zahrnuty nejlepší fotografie hotelu a představují ucelenou prezentaci hotelu,
       ///  která by měla být prezentována na portálech Previo partnerů). První fotografie (nejnižší hodnota elementu order) v takto označené galerii je titulní.
       /// </summary>
       [XmlElement("profile")]
       public bool Profile { get; set; }


       /// <summary>
       /// Galerie obsahuje fotky, které jsou přiřazené také ke specifikovanému druhu pokojů IHotelService.GetObjectKinds
       /// http://api.previo.cz/Hotel.getObjectKinds
       ///  (nebo více druhům pokojů). 
       /// Pokud element chybí, tak je galerie určená pro celý hotel.
       /// [0..*]
       /// </summary>
       [XmlElement("objectKind")]
       public ObjectKind[] ObjectKinds { get; set; }

        /// <summary>
        /// Fotky
        /// </summary>
       [XmlArrayAttribute("photos")]
       [XmlArrayItem("photo")] //[1..*]
       public Photo[] Photos { get; set; }
    }
}
