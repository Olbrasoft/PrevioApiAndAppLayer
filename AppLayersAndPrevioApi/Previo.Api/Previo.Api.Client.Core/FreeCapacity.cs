using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    ///     Vyhledávání volné kapacity
    /// </summary>
    [XmlRoot("freeCapacity")]
    public class FreeCapacity
    {
        [XmlElement("objectKind")]
        public ObjectKind[] ObjectKinds { get; set; }
        
        public class ObjectKind : BaseObjectKind
        {

            /// <summary>
            /// Konkrétní pokoje
            /// </summary>
            [XmlElement("object")]
            public Room[] Rooms { get; set; }
            
            public class Room : BaseRoom
            {
                /// <summary>
                /// Termín
                /// </summary>
                [XmlElement("term")]
                public Term Term { get; set; }
            }
        }
    }
}