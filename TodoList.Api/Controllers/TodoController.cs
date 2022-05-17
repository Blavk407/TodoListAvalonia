using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.Api.Data;
using TodoList.Api.Models;
using TodoList.Shared;

namespace TodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TodoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TodoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Todo>> Post(TodoCreateForm todo)
        {
			var todoDbModel = new Todo 
			{
				Description = todo.Description
			};
			_context.Todo.Add(todoDbModel);
            await _context.SaveChangesAsync();
            return Ok(todoDbModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Todo>> Delete([FromRoute] int id)
        {
            var todo = await _context.Todo.FirstOrDefaultAsync(x => x.Id == id);
            if (todo == null)
                return BadRequest();
            _context.Todo.Remove(todo);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Todo>> Put([FromRoute] int id, [FromBody] TodoUpdateForm model)
        {
            var putTodo = await _context.Todo.FirstOrDefaultAsync(x => x.Id == id);
            if (putTodo == null)
                return BadRequest();
            putTodo.Description = model.Description;
            putTodo.Completed = model.Completed;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Todo>> GetBook([FromRoute] int id)
        {
            var todo = await _context.Todo.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (todo == null)
                return NotFound();
            return Ok(todo);
        }

		[HttpGet]
        public async Task<ActionResult<List<Todo>>> GetBooks()
        {
			var todos = await _context.Todo.AsNoTracking().ToListAsync();
			return Ok(todos);
		}
    }
}