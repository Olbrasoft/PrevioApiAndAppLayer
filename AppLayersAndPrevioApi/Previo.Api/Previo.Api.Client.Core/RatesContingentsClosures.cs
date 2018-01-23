using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    ///     ceny, kontingenty, uzavírky, omezení a nastavení plateb
    /// </summary>
    [XmlRoot("rates")]
    public class RatesContingentsClosures
    {
        /// <summary>
        ///     Způsob účtování ceny ubytování
        ///     Pro get se da pouzit Vlastnost WayAccountingPricesAccommodation
        ///     Pokud je hodnota elementu prmId 1, hotel účtuje ceny ubytování podle obsazenosti.
        ///     Pokud je hodnota 2, cena je jednotná za celý pokoj nezávisle na počtu hostů.
        ///     http://api.previo.cz/Hotel.getRates
        /// </summary>
        [XmlElement("prmId")] public int PrmId;


        /// <summary>
        ///     Způsob účtování ceny ubytování
        ///     prmId --> WayAccountingPricesAccommodation
        /// </summary>
        public WayAccountingPricesAccommodation WayAccountingPricesAccommodation
        {
            get { return (WayAccountingPricesAccommodation) PrmId; }
        }


        /// <summary>
        ///     Sezóny, které protínají specifikovaný termín http://api.previo.cz/Hotel.getRates#param.term.
        ///     Mezi sezónami můžou existovat díry.
        ///     Pokud na sebe dvě sezóny navazují, datum do první je stejné jako datum od druhé.
        /// </summary>
        [XmlElement("season")]
        public Season[] Seasons { set; get; }


        /// <summary>
        ///     Sezóna
        /// </summary>
        public class Season : BaseFromTo
        {
            /// <summary>
            ///     Identifikátor sezóny
            /// </summary>
            [XmlElement("priId")]
            public int PriId { set; get; }

            /// <summary>
            ///     Cenové plány
            ///     [1...*]
            /// </summary>
            [XmlElement("ratePlan")]
            public RatePlan[] RatePlans { get; set; }


            /// <summary>
            ///     Cenový plán.
            /// </summary>
            [XmlType("ratePlan")]
            public struct RatePlan
            {
                /// <summary>
                ///     Id cenového plánu.
                ///     Základní cenový plán žádné nemá.
                ///     (proto jako string int null nejde serializovat )
                /// </summary>
                [XmlElement("prlId")]
                public string PrlIdAsString { get; set; }


                /// <summary>
                ///     Ceny ubytování, kontingenty a uzavírky
                /// </summary>
                [XmlElement("objectKind")]
                public ObjectKind[] ObjectKinds { get; set; }


                /// <summary>
                ///     Nabízené stravy a jejich ceny. Stravy jsou seřazeny podle meaId.
                ///     Pro každou stravu (meaId) je vždy první uvedena cena pro výchozí kategorii hostů (guaId) v hotelu,
                ///     pokud ji hotel v této sezóně výchozí kategorii nabízí.
                /// </summary>
                [XmlElement("meal")]
                public Meal[] Meals { get; set; }


                /// <summary>
                ///     Minimální délka pobytu (dní)
                /// </summary>
                [XmlElement("minStay")]
                public int MinStay { get; set; }

                /// <summary>
                ///     Maximální délka pobytu (dní)
                /// </summary>
                [XmlElement("maxStay")]
                public int MaxStay { get; set; }

                /// <summary>
                ///     Dny nájezdu/odjezdu
                /// </summary>
                [XmlElement("range")]
                public Range[] Ranges { get; set; }

                /// <summary>
                ///     Nastavení plateb
                /// </summary>
                [XmlElement("payment")]
                public Payment[] Payments { get; set; }

                [XmlType("meal")]
                public class Meal : BaseMeal
                {
                    /// <summary>
                    ///     Id kategorie hostů
                    /// </summary>
                    [XmlElement("guaId")]
                    public int GuaId { get; set; }

                    /// <summary>
                    ///     Ceny
                    ///     [1..*]
                    /// </summary>
                    [XmlElement("rate")]
                    public Rate[] Rates { get; set; }
                }

                [XmlType("objectKind")]
                public class ObjectKind : BaseObjectKind
                {
                    /// <summary>
                    ///     Ceny ubytování
                    /// </summary>
                    [XmlElement("rate")]
                    public Rate[] Rates { get; set; }


                    /// <summary>
                    ///     Kontingent
                    /// </summary>
                    [XmlElement("contingent")]
                    public Contingent Contingent { get; set; }

                    /// <summary>
                    ///     Zavřené pokoje
                    /// </summary>
                    [XmlElement("closed")]
                    public Closed Closed { get; set; }

                    /// <summary>
                    ///     Cena ubytování
                    /// </summary>
                    [XmlType("rate")]
                    public class Rate : Client.Rate
                    {
                        /// <summary>
                        ///     Obsazenost. Tento element chybí, pokud hotel účtuje jednotnou cenu za celý pokoj.
                        ///     [0..1]
                        /// </summary>
                        [XmlElement("occupancy")]
                        public int? Occupancy { get; set; }

                        /// <summary>
                        ///     Non-refundable rate
                        ///     [0..1]
                        /// </summary>
                        [XmlElement("standardPrice")]
                        public float StandardPrice { get; set; }

                        /// <summary>
                        ///     Non-refundable rate
                        /// </summary>
                        [XmlElement("nrrPrice")]
                        public string NrrPrice { get; set; }
                    }
                }

                /// <summary>
                ///     Nastavení platby
                /// </summary>
                [XmlType("payment")]
                public struct Payment
                {
                    /// <summary>
                    ///     Id platby
                    /// </summary>
                    [XmlElement("payId")]
                    public int PayId { get; set; }

                    /// <summary>
                    ///     Id stavu, do kterého je rezervace přijata v případě,
                    ///     že platba proběhne úspěšně.
                    ///     ReservationStatus.StatusId
                    /// </summary>
                    [XmlElement("cosIdSuccess")]
                    public int CosIdSuccess { get; set; }

                    /// <summary>
                    ///     Id stavu, do kterého je rezervace přijata v případě, že platba neproběhne úspěšně.
                    ///     Úspěšnost platby lze vyhodnotit pouze u platby kreditní kartou (payId = 3), u ostatních typů platby se rezervace uloží vždy do stavu cosIdSuccess.
                    ///     ReservationStatus.StatusId
                    /// </summary>
                    [XmlElement("cosIdFailure")]
                    public int? CosIdFailure { get; set; }


                    /// <summary>
                    ///     Požadovaná záloha
                    /// </summary>
                    [XmlElement("advance")]
                    public RequiredGuarantee Advance { get; set; }

                    /// <summary>
                    ///     Požadovaná záloha
                    /// </summary>
                    [XmlType("advance")]
                    public struct RequiredGuarantee
                    {
                      
                        /// <summary>
                        ///     Typ zálohy (co vyjadřuje value)
                        /// </summary>
                        [XmlElement("type")]
                        public RequiredGuaranteeTypes Type { get; set; }
                        
                        /// <summary>
                        ///     Záloha , hodnota zálohy o jakej ty zálohy se jedná vyjadřuje
                        ///     vlastnost Type
                        /// </summary>
                        [XmlElement("value")]
                        public  float Value { get; set; }

                        /// <summary>
                        ///     Počet dní, do kdy lze zálohu zaplatit. Úvaděno jen u platby převodem.
                        /// </summary>
                        [XmlElement("expiration")]
                        public int? Expiration { get; set; }
                    }
                }

                /// <summary>
                ///     Den nájezdu/odjezdu
                /// </summary>
                public struct Range
                {
                    /// <summary>
                    ///     Den nájezdu
                    /// </summary>
                    [XmlElement("arrival")]
                    public DaysWeek Arrival { get; set; }

                    /// <summary>
                    ///     Den odjezdu
                    /// </summary>
                    [XmlElement("departure")]
                    public DaysWeek Departure { get; set; }
                }
            }
        }
    }
}