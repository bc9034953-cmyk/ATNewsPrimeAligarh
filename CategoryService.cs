using ATNewsprimeApp.DbContent;
using ATNewsprimeApp.DtoRequest;
using ATNewsprimeApp.DtoResponse;
using ATNewsprimeApp.Entitys;
using ATNewsprimeApp.IService;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ATNewsprimeApp.Service
{
    public class CategoryService : ICategoryService
    {

        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CategoryResponse> CreateCategoryAsync(CategoryCreateRequest request)
        {
            var category = new Category
            {
                Name = request.Name,
                Description = request.Description,
                Slug = request.Name.ToLower().Replace(" ", "-"),
                CreatedAt = DateTime.Now
            };
            _context.AllCategories.Add(category);

            await _context.SaveChangesAsync();
            return ToReaponse(category);
        }

        public async Task<DeleteCategoryResponse> DeleteCategoryByIdAsync(int id)
        {
            var category = await _context.AllCategories.FindAsync(id);
            if (category == null)
            {

                return new DeleteCategoryResponse
                {
                    Success = false,
                    Message = "Category not found"
                };
            }

            _context.AllCategories.Remove(category);
            await _context.SaveChangesAsync(); 
            return new DeleteCategoryResponse
            {
                Success = true,
                Message = "Category Delete Succesfully"
            };
        }

        public async Task<CategoryResponse> GatCategoriesbyIdAsync(int id)
        {
            var category = await _context.AllCategories.FindAsync(id);
            if (category == null)
                return null;
            return ToReaponse(category);
        }

        public async Task<List<CategoryResponse>> GetAllCategoriesAsync()
        {
            var categorise = await _context.AllCategories
                .OrderByDescending(e => e.Id)
                .Select(e => new CategoryResponse
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Slug = e.Slug,
                    CreatedAt = e.CreatedAt
                }).ToListAsync();
            return categorise;
        }

        public async Task<CategoryResponse> UpdateCategoryByIdAsync(int id, CategoryUpdateRequest request)
        { 
            var category = await _context.AllCategories.FindAsync(id);
            if (category == null)
                return null;
            category.Name = request.Name;
            category.Description = request.Description;
            category.Slug = request.Slug;

            _context.SaveChangesAsync();
            return ToReaponse(category);


        }

        private CategoryResponse ToReaponse(Category category)
        {
            return new CategoryResponse
            {
                Id = category.Id,
                Name = category.Name,
                Slug = category.Slug,
                Description = category.Description,
                CreatedAt = category.CreatedAt
            };
        }
    }
}
