namespace WebAPI.ViewModel
{
    public class ReceiptViewModel
    {
        public int Id { get; set; }
        public string Total { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
