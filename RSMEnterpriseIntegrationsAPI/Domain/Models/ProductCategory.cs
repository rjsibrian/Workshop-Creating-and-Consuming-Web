namespace RSMEnterpriseIntegrationsAPI.Domain.Models
{
    public class ProductCategory
    {
        public int ProductCategoryID { get; set; }
        public string? Name { get; set; }
        public Guid Rowguid { get; set; } = Guid.NewGuid();
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}
