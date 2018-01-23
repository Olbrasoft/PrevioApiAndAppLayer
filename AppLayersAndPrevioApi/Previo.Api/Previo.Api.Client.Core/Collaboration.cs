using System.Xml.Serialization;
using Previo.Api.Client.BLL;

namespace Previo.Api.Client
{
    /// <summary>
    /// http://api.previo.cz/Hotel.setCollaboration
    /// </summary>
    [XmlRoot("collaboration")]
    public class Collaboration : ICollaboration
    {
        /// <summary>
        ///     Pro serializaci do xml je potřeba bezparamtrický konstruktor.
        /// </summary>
        public Collaboration()
        {}

        public Collaboration(StatusesCollaboration status, double? totalBonusRate=null, double? partnerBonusRate = null, double? previoBonusRate=null)
        {
            Status = status;
            
            if (partnerBonusRate != null) PartnerBonusRate = (double) partnerBonusRate;
            if (previoBonusRate != null) PrevioBonusRate =(double) previoBonusRate;
            if (totalBonusRate != null) TotalBonusRate =(double) totalBonusRate;
        }

        /// <summary>
        /// Stav spolupráce
        /// [1]
        /// </summary>
        [XmlElement("status")]
        public StatusesCollaboration Status { get; set; }
        

        /// <summary>
        /// Provize partnera v procentech
        /// [1]
        /// </summary>
        [XmlElement("partnerBonusRate")]
        public double PartnerBonusRate;
        
        /// <summary>
        /// Provize Previa v procentech
        /// [1]
        /// </summary>
        [XmlElement("previoBonusRate")]
        public double PrevioBonusRate;


        /// <summary>
        /// Celková provize (partner + Previo) v procentech
        /// [1]
        /// </summary>
        [XmlElement("totalBonusRate")]
        public double TotalBonusRate;
        
    }
}
