using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using TodoApi.Services;
using TodoApi.Models.Entities;
using TodoApi.Models.Request;
using TodoApi.Models.Response;

namespace TodoApi.Controllers
{
    // [Route("[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        // Service
        private readonly ITodoService _todo;

        public TodoController(ITodoService todo)
        {
            _todo = todo;
        }

        // IActionResult is an interface, we can create a custom response as a return,
        // when you use ActionResult you can return only predefined ones for returning a View or a resource.
        
        // GET: 목록 조회 
        [Route("todos")]
        [HttpGet]
        public async Task<ActionResult> GetTodoEntities(TodoListResponse model)
        {
        }
        
        // POST: 입력
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("to-do")]
        [HttpPost]
        public async Task<ActionResult> AddTodoEntity([FromForm]AddTodoRequest model)
        {
            var result = _todo.AddTodoEntity(
                model.Title,
                model.Password,
                model.Writer
            );

            if (result == false)
            {
                Console.WriteLine("post fail");
            }

            return StatusCode(StatusCodes.Status201Created);
        }

        // // GET: 상세 조회 
        // [Route("todos/{id}")]
        // [HttpGet("{id}")]
        // public async Task<ActionResult<TodoEntity>> GetTodoItem(long id)
        // {
        //   if (TodoEntities == null)
        //   {
        //       return NotFound();
        //   }
        //   
        //   var todoItem = await TodoEntities.FindAsync(id);
        //
        //   if (todoItem == null)
        //   {
        //        return NotFound();
        //   }
        //   return todoItem;
        // }

        // // DELETE: 삭제
        // [Route("to-do/{id}")]
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteTodoItem(long id)
        // {
        //     if (TodoEntities == null)
        //     {
        //         return NotFound();
        //     }
        //     var todoItem = await TodoEntities.FindAsync(id);
        //     if (todoItem == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     TodoEntities.Remove(todoItem);
        //     await SaveChangesAsync();
        //
        //     return NoContent();
        // }
        
        private bool TodoItemExists(long id)
        {
            return (TodoEntities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

