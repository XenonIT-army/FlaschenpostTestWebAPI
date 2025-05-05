using FlaschenpostTestWebAPI.Interface;
using FlaschenpostTestWebAPI.Model;
using FlaschenpostTestWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlaschenpostTestWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemController : ControllerBase
    {
        private readonly ILogger<TodoItemController> _logger;
        IService<TodoItem> _todoItemService;
        public TodoItemController( IService<TodoItem> todoItemService, ILogger<TodoItemController> logger)
        {
            _logger = logger;
            _todoItemService = todoItemService;
        }

        [HttpGet]
        public async Task<IEnumerable<TodoItem>> Get()
        {
            _logger.LogInformation($"{nameof(CategoryController)} - HttpGet all request");
            var list =  await _todoItemService.GetAll();
            return list;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> Get(int id)
        {
            _logger.LogInformation($"{nameof(TodoItemController)} - HttpGet by id request");
            var todoItem = await _todoItemService.GetById(id);
            return todoItem == null ? NotFound("Item not found in DataBase") : Ok(todoItem);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TodoItem todoItem)
        {
            _logger.LogInformation($"{nameof(TodoItemController)} - HttpPost request");
            if (todoItem == null) return BadRequest();
            var item = await _todoItemService.Add(new TodoItem {Title = todoItem.Title, Description = todoItem.Description,
                ProjectId = todoItem.ProjectId, CreatedAt = todoItem.CreatedAt, CompletedAt =todoItem.CompletedAt, DueDate = todoItem.DueDate,
             IsCompleted = todoItem.IsCompleted, Priority = todoItem.Priority});
             var res = await _todoItemService.Save();

            todoItem = item;

            return CreatedAtAction(nameof(Get), todoItem);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TodoItem todoItem)
        {
            _logger.LogInformation($"{nameof(TodoItemController)} - HttpPut request");
            if (todoItem == null) return BadRequest();

            var item =  await _todoItemService.GetById(todoItem.Id);
            if(item == null) return NotFound("Item not found in DataBase");

            await _todoItemService.Update(todoItem);
            var res = await _todoItemService.Save();
            return CreatedAtAction(nameof(Put), res);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] TodoItem todoItem)
        {
            _logger.LogInformation($"{nameof(TodoItemController)} - HttpDelete request");
            if (todoItem == null) return BadRequest();

            var item = await _todoItemService.GetById(todoItem.Id);
            if (item == null) return NotFound("Item not found in DataBase");

            await _todoItemService.Delete(todoItem);
            var res = await _todoItemService.Save();
            return CreatedAtAction(nameof(Delete), res);
        }
    }
}
