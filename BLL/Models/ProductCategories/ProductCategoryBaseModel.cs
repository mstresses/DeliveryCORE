namespace BLL.Models.Produtos
{
    public abstract class ProductCategoryBaseModel
    {
        public string Name { get; set; }
        public int SupplierId { get; set; }
    }
}