using WebAPI.ViewModel;

namespace WebAPI.IServices
{
    public interface ICommentService
    {
        public Task<List<CommentViewModel>> GetAllCommentAsync();
        public Task<CommentViewModel> AddNewCommentAsync(CommentViewModel model);
        public Task<CommentViewModel> GetCommentByIDAsync(int ID);
        public Task<CommentViewModel> UpdateCommentAsync(int ID, CommentViewModel model);
        public Task<bool> DeleteCommentAsync(int ID);
    }
}
