using FlaschenpostTestDAL.Entities;
using FlaschenpostTestWebAPI.Interface;
using FlaschenpostTestWebAPI.Model;
using FlaschenpostTestWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlaschenpostTestWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        IService<Category> _categoryService;
        public CategoryController(IService<Category> categoryService, ILogger<CategoryController> logger)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            _logger.LogInformation($"{nameof(CategoryController)} - HttpGet all request");
            var list = await _categoryService.GetAll();
            return list;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(int id)
        {
            _logger.LogInformation($"{nameof(CategoryController)} - HttpGet by id request");
            var category = await _categoryService.GetById(id);
            return category == null ? NotFound("Item not found in DataBase") : Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            _logger.LogInformation($"{nameof(CategoryController)} - HttpPost request");
            if (category == null) return BadRequest();
            var item = await _categoryService.Add(new Category {Title = category.Title, Description = category.Description });
            var res = await _categoryService.Save();
            category = item;
            return CreatedAtAction(nameof(Get),category);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Category category)
        {
            _logger.LogInformation($"{nameof(CategoryController)} - HttpPut request");
            if (category == null) return BadRequest();

            var item = await _categoryService.GetById(category.Id);
            if (item == null) return NotFound("Item not found in DataBase");

            await _categoryService.Update(category);
            var res = await _categoryService.Save();
            return CreatedAtAction(nameof(Put), res);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Category category)
        {
            _logger.LogInformation($"{nameof(CategoryController)} - HttpDelete request");
            if (category == null) return BadRequest();

            var item = await _categoryService.GetById(category.Id);
            if (item == null) return NotFound("Item not found in DataBase");

            await _categoryService.Delete(category);
            var res = await _categoryService.Save();
            return CreatedAtAction(nameof(Delete), res);
        }
    }
}
