using DTO.Entities.Base;

namespace DTO
{
    public class ProductCategory : BaseEntity
    {
        public string Name { get; set; }
        public Supplier Supplier { get; set; }
        public int SupplierId { get; set; }

        public ProductCategory()
        {
        }

        public ProductCategory(string name, Supplier supplier, int supplierId)
        {
            Name = name;
            Supplier = supplier;
            SupplierId = supplierId;
        }

        public ProductCategory(string name, int supplierId)
        {
            Name = name;
            SupplierId = supplierId;
        }
    }
}