namespace WebAPI.ViewModel
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Content { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? ProductId { get; set; }
    }
}
