namespace WebAPI.ViewModel
{
    public class SupplierViewModel
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
