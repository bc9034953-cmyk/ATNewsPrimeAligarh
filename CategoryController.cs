using ATNewsprimeApp.DtoRequest;
using ATNewsprimeApp.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ATNewsprimeApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpPost("AddCategory")]

        public async Task<IActionResult> AddCategory([FromBody]  
        CategoryCreateRequest request)
        {
            return Ok(await _categoryService.CreateCategoryAsync(request));
        }


        [HttpGet("AllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
           var Data= await _categoryService.GetAllCategoriesAsync();
            return Ok(Data);
        }



        [HttpGet("GatCategoryById/{id}")]

        public async Task<IActionResult> GatCategoryByid(int id)
        {
            return Ok(await _categoryService.GatCategoriesbyIdAsync(id));
        }


        [HttpPut("UpdateCategoryById/{id}")]

        public async Task<IActionResult> UpdateCategoryById(int id, CategoryUpdateRequest request)
        {
            return Ok(await _categoryService.UpdateCategoryByIdAsync(id, request));
        }

        [HttpDelete("DeleteCategoryById/{id}")]

        public async Task<IActionResult> DeleteCategoryById(int id)
        {
            var result= await _categoryService.DeleteCategoryByIdAsync(id);
            return Ok(result);
           
        }

    }
}
