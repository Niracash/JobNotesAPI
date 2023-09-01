using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Data;
using ToDoAPI.Models;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoDbContext _db;

        public TodoController(TodoDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTodos()
        {
            var todos = await _db.Todos.
                Where( x => x.IsRemoved == false)
                .OrderByDescending( x => x.CreatedDate)
                .ToListAsync();
            return Ok(todos);
        }
        [HttpGet]
        [Route("get-removed-todos")]
        public async Task<IActionResult> GetAllRemovedTodos()
        {
            var todos = await _db.Todos.
                Where(x => x.IsRemoved == true)
                .OrderByDescending(x => x.CreatedDate)
                .ToListAsync();
            return Ok(todos);
        }
        [HttpPost]
        public async Task<IActionResult> AddTodo(Todo todo)
        {
            todo.Id = Guid.NewGuid();
            _db.Todos.Add(todo);
            await _db.SaveChangesAsync();
            return Ok(todo);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> updateTodo([FromRoute] Guid id, Todo todoUpdate)
        {
            var todo = await _db.Todos.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.IsDone = todoUpdate.IsDone;
            todo.DoneDate = DateTime.Now; 
            await _db.SaveChangesAsync();
            return Ok(todo);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteTodo([FromRoute] Guid id)
        {
            var todo = await _db.Todos.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            todo.IsRemoved = true;
            todo.RemovedDate = DateTime.Now;
            await _db.SaveChangesAsync();
            return Ok(todo);
        }
        [HttpPut]
        [Route("restore-removed-task/{id:Guid}")]
        public async Task<IActionResult> RestoreRemovedTodo([FromRoute] Guid id, Todo restoreRemovedTodo)
        {
            var todo = await _db.Todos.FindAsync(id);

            if (todo == null)
            {
                return NotFound();
            }

            todo.IsRemoved = false;
            todo.RemovedDate = null;
            await _db.SaveChangesAsync();
            return Ok(todo);
        }
    }
}
