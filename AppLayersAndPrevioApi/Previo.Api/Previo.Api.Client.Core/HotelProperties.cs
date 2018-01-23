using System.Collections.Generic;
using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    ///     Vybavení hotelů
    ///     každý hotel ve výstupu operací IHotelService.get a IHotelsService.search obsahuje 0..* vybavení, které jsou vybrány z tohoto číselníku.
    ///     U některých vybavení lze navíc zadat cenu nebo vzdálenost.
    ///     Vybavení je sdruženo do několika skupin. Můžete si vybrat, jestli ho takto budete prezentovat i na vašich stránkách nebo vše na jedné hromadě.
    /// </summary>
    [XmlRoot("hotelProperties")]
    public class GroupHotelProperties : List<GroupHotelProperties.GroupProperties>
    {
        /// <summary>
        ///     Skupina vlastností
        ///     Vlastnosti hotelu jsou zařazené do skupin
        /// </summary>
        [XmlType("group")]
        public class GroupProperties
        {
            /// <summary>
            ///     Id skupiny
            /// </summary>
            [XmlElement("hpkId")]
            public int HpkId { get; set; }

            /// <summary>
            ///     Název skupiny
            /// </summary>
            [XmlElement("name")]
            public string Name { get; set; }

            [XmlArray("properties")]
            [XmlArrayItem("property")]
            public HotelProperty[] Properties { get; set; }
        }

        

        /// <summary>
        ///     Reprezentuje jednu vlastnost
        /// </summary>
        [XmlType("property")]
        public class HotelProperty : BaseProperty
        {
            /// <summary>
            ///     Id vlastnosti
            /// </summary>
            [XmlElement("hopId")]
            public int HopId { get; set; }


            /// <summary>
            ///     U této vlastnoti lze zadat vzdálenost od hotelu
            ///     (true|false)
            /// </summary>
            [XmlElement("distanceGet")]
            public bool DistanceGet { get; set; }


            /// <summary>
            /// U této vlastnoti lze zadat cenu 
            /// (true|false)
            /// </summary>
            [XmlElement("priceGet")]
            public bool PriceGet { get; set; }


            /// <summary>
            ///     U této vlastnoti lze zadat jestli je hlídaná (např. u parkoviště)
            ///     (true|false)
            /// </summary>
            [XmlElement("supervisedGet")]
            public bool SupervisedGet { get; set; }


            /// <summary>
            ///     U této vlastnoti lze zadat jestli se nachází přímo na pokoji nebo na hotelu
            ///     (true|false)
            /// </summary>
            [XmlElement("hotelOrRoomGet")]
            public bool HotelOrRoomGet { get; set; }


            /// <summary>
            ///     U této vlastnoti lze zadat kapacitu (osob), např. u společenské místnosti
            ///     (true|false)
            /// </summary>
            [XmlElement("capacityGet")]
            public bool CapacityGet { get; set; }
        }
    }
}