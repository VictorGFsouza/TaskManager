using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Enums;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITask _ctx;
        public TaskController(ITask ctx) 
        {
            _ctx = ctx;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Task>> Get(byte? status)
        {
            var itens = _ctx.Search(status).ToList();

            if (itens is null)
            {
                return NotFound();
            }

            return Ok(itens);
        }

        [HttpPost]
        public ActionResult<Task> Post([FromBody] Task task)
        {
            var createdTask = _ctx.Create(task);
            return Ok(createdTask);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] Task task)
        {
            var taskExist = _ctx.Update(id, task);

            return Ok(taskExist);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _ctx.Delete(id);
        }

        [HttpGet("status")]
        public ActionResult<IEnumerable<object>> GetStatus()
        {
            var list = Enum.GetValues(typeof(Status))
                .Cast<Status>()
                .Select(s => new {
                    id = (int)s,
                    descricao = s.GetAttribute<DisplayAttribute>()?.Name ?? s.ToString()
                });

            return Ok(list);
        }
    }
}
