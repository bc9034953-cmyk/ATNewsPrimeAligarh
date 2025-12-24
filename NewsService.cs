using ATNewsprimeApp.DbContent;
using ATNewsprimeApp.DtoRequest;
using ATNewsprimeApp.DtoResponse;
using ATNewsprimeApp.Entitys;
using ATNewsprimeApp.IService;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ATNewsprimeApp.Service
{
    public class NewsService : INewsService
    {
        private readonly ApplicationDbContext _context;

        public NewsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<NewsResponse> AddNewsAsync(NewsCreateRequest request)
        {
            var news = new News
            {
                Title = request.Title,
                Slug = request.Slug,
                ImageUrl = request.ImageUrl,
                ShortDescription = request.ShortDescription,
                FullDescription = request.FullDescription,
                CategoryId = request.CategoryId,
                CreatedByAdminId = request.CreatedByAdminId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsPublished = request.IsPublished

            };
            _context.AllNewses.Add(news);
            await _context.SaveChangesAsync();

            return new NewsResponse
            {
                Success = true,
                Message = "News Added Successfully",
                NewsId = news.Id,

            };
        }

        public async Task<DeleteNewsReaponse> DeleteNewsByIdAsync(int id)
        {
            var del = await _context.AllNewses.FindAsync(id);
            if (del == null)
            {
                return new DeleteNewsReaponse
                {
                    Success = false,
                    Message = "News Not Found!"
                };
            }
               
           _context.AllNewses.Remove(del);
            await _context.SaveChangesAsync();
            return new DeleteNewsReaponse
            {
                Success = true,
                Message = "News Deleted Successfully"
            };
            
        }

        public async Task<List<News>> GetAllNewAsyncs()
        {
            var news = await _context.AllNewses
                         .Include(n => n.Category)         
                         .Include(n => n.CreatedByAdmin)   
                         .OrderByDescending(n => n.CreatedAt)  
                         .ToListAsync();
            return news;
        }

        public async Task<List<News>> GetAllPublicedNewAsyncs()
        {
            var news = await _context.AllNewses
         .Include(n => n.Category)
         .Include(n => n.CreatedByAdmin)
         .Where(n => n.IsPublished == true)   
         .OrderByDescending(n => n.CreatedAt)
         .ToListAsync();

            return news;
        }

        public async Task<News> GetNewsByIdAsync(int id)
        {
            return await _context.AllNewses
                          .Include(n => n.Category)
                          .Include(n => n.CreatedByAdmin)
                          .FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<NewsResponse> UpdatNewsByIdAsync(int id, UpdatedNewsRequest request)
        {
            var upnews = await _context.AllNewses.FindAsync(id);

            if (upnews == null)
                return null;

            upnews.Title = request.Title;
            upnews.Slug = request.Slug;
            upnews.ShortDescription = request.ShortDescription;
            upnews.FullDescription = request.FullDescription;
            upnews.ImageUrl = request.ImageUrl;
            upnews.CategoryId = request.CategoryId;
            upnews.IsPublished = request.IsPublished;
            upnews.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            var response = new NewsResponse
            {
                Success = true,
                Message = "News Updated Successfully",
                NewsId = id
            };

            return response;
        }

    }
}
