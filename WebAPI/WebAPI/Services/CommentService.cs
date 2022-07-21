using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.ViewModel;

namespace WebAPI.Services
{
    public class CommentService
    {
        private readonly saledbContext _context;
        private readonly IMapper _mapper;

        public CommentService(saledbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<CommentViewModel>> GetAllCommentAsync()
        {
            var data = await _context.Comment.OrderByDescending(s => s.Id).ToListAsync();
            return _mapper.Map<List<CommentViewModel>>(data);
        }

        public async Task<CommentViewModel> GetCommentByIDAsync(int ID)
        {
            var data = await _context.Comment.Where(s => s.Id == ID).FirstOrDefaultAsync();
            return _mapper.Map<CommentViewModel>(data);
        }

        public async Task<bool> DeleteCommentAsync(int ID)
        {
            try
            {
                Comment existingItem = await _context.Comment.Where(c => c.Id == ID).FirstOrDefaultAsync();
                _context.Comment.Remove(existingItem);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<CommentViewModel> UpdateCommentAsync(int ID, CommentViewModel model)
        {
            try
            {
                _mapper.Map<Comment>(model);
                Comment existingItem = await _context.Comment.Where(s => s.Id == ID).FirstOrDefaultAsync();
                //model.modified_by = SessionHelper.currentUser.id;
                //model.modified_at = DateTime.Now.ToUniversalTime();
                await _context.SaveChangesAsync();
                return _mapper.Map<CommentViewModel>(existingItem);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<CommentViewModel> AddNewCommentAsync(CommentViewModel model)
        {
            try
            {
                var data = _mapper.Map<Comment>(model);
                //model.created_by = SessionHelper.currentUser.id;
                //model.created_at = DateTime.Now.ToUniversalTime();
                _context.Comment.Add(data);
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
