namespace Qitar.Tenancy
{
    public interface ITenant
    {
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string ConnectionString { get; set; }
        public string Culture { get; set; }
        public string TimeZone { get; set; }
    }
}
