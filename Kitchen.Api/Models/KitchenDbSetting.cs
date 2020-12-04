namespace Kitchen.Api.Models
{
    public class KitchenDbSetting : IKitchenDbSetting
    {
        public string KitchenCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
