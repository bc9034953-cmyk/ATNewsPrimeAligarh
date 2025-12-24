using ATNewsprimeApp.DbContent;
using ATNewsprimeApp.DtoRequest;
using ATNewsprimeApp.DtoResponse;
using ATNewsprimeApp.Entitys;
using ATNewsprimeApp.IService;
using Microsoft.EntityFrameworkCore;

namespace ATNewsprimeApp.Service
{
    public class CommentService : ICommentService
    {

        private readonly ApplicationDbContext _context;


        public CommentService(ApplicationDbContext  context)
        {
            _context = context;
        }

        public async Task<CommentResponse> AddCommentAsync(AddCommentRequest request)
        {


            var newsExists = await _context.AllNewses.AnyAsync(n => n.Id == request.NewsId);
            if (!newsExists)
            {
                return new CommentResponse
                {
                    Success = false,
                    Message = "News not found.",
                    CommentId = 0,
                    CreatedAt = DateTime.UtcNow
                };
            }


            if (request == null || string.IsNullOrWhiteSpace(request.Message))
            {
                return new CommentResponse
                {
                    Success = false,
                    Message = "Invalid comment request.",   
                    CommentId = request.NewsId,
                    CreatedAt = DateTime.Now
                };
            }


            var addcomment = new Comment
            {
                NewsId = request.NewsId,
                UserName = request.UserName,
                Message = request.Message,
                CreatedAt = DateTime.UtcNow,
                AllNews = null
            };


            _context.AllComments.Add(addcomment);
            await _context.SaveChangesAsync();


            return new CommentResponse
            {
                Success = true,
                Message = "Comment added successfully.",
                CommentId = addcomment.Id,
                CreatedAt = addcomment.CreatedAt,
            }; 

        }

        public async Task<DeleteCommentResponse> DeleteCommentByIdAsync(int CommentId)
        {
            var del = await _context.AllComments.FindAsync(CommentId);
            if (del == null)
                return new DeleteCommentResponse
                {
                    Success = false,
                    Message = "Comment Not Found!"
                };
            _context.AllComments.Remove(del);
            await _context.SaveChangesAsync();
            return new DeleteCommentResponse
            {
                Success = true,
                Message = "Comment Deleted Successfully"
            };

        }

        public async Task<List<CommentResponse>> GetAllCommentsAsync(int? NewsId = null)    
        {
            var query = _context.AllComments.AsQueryable();

            // Apply filter ONLY if NewsId is provided
            if (NewsId.HasValue)
            {
                query = query.Where(c => c.NewsId == NewsId.Value);
            }

            var comments = await query
                .OrderByDescending(c => c.CreatedAt)
                .Select(c => new CommentResponse
                {
                    Success = true,
                    Message = c.Message,
                    CommentId = c.Id,
                    NewsId = c.NewsId,
                    CreatedAt = c.CreatedAt,
                })
                .ToListAsync();

            return comments;
        }




    }
}
