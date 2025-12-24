using ATNewsprimeApp.DtoRequest;
using ATNewsprimeApp.DtoResponse;

namespace ATNewsprimeApp.IService
{
    public interface ICategoryService
    {
        Task<CategoryResponse> CreateCategoryAsync(CategoryCreateRequest request);
        Task<List<CategoryResponse>> GetAllCategoriesAsync();
        Task<CategoryResponse> GatCategoriesbyIdAsync(int id);   
        Task<CategoryResponse> UpdateCategoryByIdAsync(int id, CategoryUpdateRequest request);
        Task<DeleteCategoryResponse> DeleteCategoryByIdAsync(int id);
    }
}
