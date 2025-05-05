using FlaschenpostTestWebAPI.Interface;
using FlaschenpostTestWebAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace FlaschenpostTestWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        IService<Project> _projectService;
        public ProjectController(IService<Project> projectService, ILogger<ProjectController> logger)
        {
            _logger = logger;
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IEnumerable<Project>> Get()
        {
            _logger.LogInformation($"{nameof(ProjectController)} - HttpGet all request");
            var list = await _projectService.GetAll();
            return list;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> Get(int id)
        {
            _logger.LogInformation($"{nameof(ProjectController)} - HttpGet by id request");
            var category = await _projectService.GetById(id);
            return category == null ? NotFound("Item not found in DataBase") : Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Project project)
        {
            _logger.LogInformation($"{nameof(ProjectController)} - HttpPost request");
            if (project == null) return BadRequest();
            var item = await _projectService.Add(new Project { Title = project.Title, Description = project.Description,  CategoryId = project.CategoryId, Icon = project.Icon });
            var res = await _projectService.Save();
            project = item;
            return CreatedAtAction(nameof(Get), project);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Project project)
        {
            _logger.LogInformation($"{nameof(ProjectController)} - HttpPut request");
            if (project == null) return BadRequest();

            var item = await _projectService.GetById(project.Id);
            if (item == null) return NotFound("Item not found in DataBase");

            await _projectService.Update(project);
            var res = await _projectService.Save();
            return CreatedAtAction(nameof(Put), res);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Project project)
        {
            _logger.LogInformation($"{nameof(ProjectController)} - HttpDelete request");
            if (project == null) return BadRequest();

            var item = await _projectService.GetById(project.Id);
            if (item == null) return NotFound("Item not found in DataBase");

            await _projectService.Delete(project);
            var res = await _projectService.Save();
            return CreatedAtAction(nameof(Delete), res);
        }
    }
}
