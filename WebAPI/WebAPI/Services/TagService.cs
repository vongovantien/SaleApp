using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.ViewModel;

namespace WebAPI.Services
{
    public class TagService
    {
        private readonly saledbContext _context;
        private readonly IMapper _mapper;

        public TagService(saledbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<TagViewModel>> GetAllTagAsync()
        {
            var data = await _context.Tag.OrderByDescending(s => s.Id).ToListAsync();
            return _mapper.Map<List<TagViewModel>>(data);
        }

        public async Task<TagViewModel> GetTagByIDAsync(int ID)
        {
            var data = await _context.Tag.Where(s => s.Id == ID).FirstOrDefaultAsync();
            return _mapper.Map<TagViewModel>(data);
        }

        public async Task<bool> DeleteTagAsync(int ID)
        {
            try
            {
                Tag existingItem = await _context.Tag.Where(c => c.Id == ID).FirstOrDefaultAsync();
                _context.Tag.Remove(existingItem);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<TagViewModel> UpdateTagAsync(int ID, TagViewModel model)
        {
            try
            {
                _mapper.Map<Tag>(model);
                Tag existingItem = await _context.Tag.Where(s => s.Id == ID).FirstOrDefaultAsync();
                //model.modified_by = SessionHelper.currentUser.id;
                //model.modified_at = DateTime.Now.ToUniversalTime();
                await _context.SaveChangesAsync();
                return _mapper.Map<TagViewModel>(existingItem);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<TagViewModel> AddNewTagAsync(TagViewModel model)
        {
            try
            {
                var data = _mapper.Map<Tag>(model);
                //model.created_by = SessionHelper.currentUser.id;
                //model.created_at = DateTime.Now.ToUniversalTime();
                _context.Tag.Add(data);
                await _context.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
