using WebAPI.ViewModel;

namespace WebAPI.IServices
{
    public interface ITagService
    {
        public Task<List<TagViewModel>> GetAllTagAsync();
        public Task<TagViewModel> AddNewTagAsync(TagViewModel model);
        public Task<TagViewModel> GetTagByIDAsync(int ID);
        public Task<TagViewModel> UpdateTagAsync(int ID, TagViewModel model);
        public Task<bool> DeleteTagAsync(int ID);
    }
}
