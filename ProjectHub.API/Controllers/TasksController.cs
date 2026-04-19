using Microsoft.AspNetCore.Mvc;
using ProjectHub.Core.DTOs;
using ProjectHub.Core.Entities;
using ProjectHub.Core.Interfaces;

namespace ProjectHub.API.Controllers
{
    [ApiController]
    [Route("api/projects/{projectId}/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int projectId)
        {
            var tasks = await _taskRepository.GetAllByProjectIdAsync(projectId);
            return Ok(tasks);
        }

        [HttpGet("{taskId}")]
        public async Task<IActionResult> GetById(int projectId, int taskId)
        {
            var task = await _taskRepository.GetByIdAsync(projectId, taskId);
            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int projectId, TaskDto dto)
        {
            var task = new ProjectTask
            {
                Title = dto.Title,
                Description = dto.Description,
                IsCompleted = dto.IsCompleted,
                ProjectId = projectId
            };

            var created = await _taskRepository.CreateAsync(task);
            return CreatedAtAction(nameof(GetById), new { projectId, taskId = created.Id }, created);
        }

        [HttpPut("{taskId}")]
        public async Task<IActionResult> Update(int projectId, int taskId, TaskDto dto)
        {
            var task = new ProjectTask
            {
                Title = dto.Title,
                Description = dto.Description,
                IsCompleted = dto.IsCompleted,
                ProjectId = projectId
            };

            var updated = await _taskRepository.UpdateAsync(taskId, task);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{taskId}")]
        public async Task<IActionResult> Delete(int projectId, int taskId)
        {
            var result = await _taskRepository.DeleteAsync(taskId);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}