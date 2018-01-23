namespace Moon.Globalization.DAL.FromConfig
{
    public class EnableCulturesConfigReadOnlyRepository:BaseConfigEnableCulturesReadOnlyRepository
    {
        public EnableCulturesConfigReadOnlyRepository(ICultureInfoParser parser ) : base("EnableCultures", ",",parser)
        {}
    }
}
