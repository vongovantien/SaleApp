namespace WebAPI.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Price { get; set; }
        public string? PriceSale { get; set; }
        public string? Code { get; set; }
        public int CategoryId { get; set; }
        public int? SupplierId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CategoryName { get; set; }
    }
}
