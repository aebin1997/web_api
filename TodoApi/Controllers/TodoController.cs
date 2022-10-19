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
    [Route("")]
    [ApiController]
    [Produces("application/json")]
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
        public async Task<ActionResult<IEnumerable<TodoEntity>>> GetTodoItems()
        {
            var result = _todo.GetTodoEntities();

            if (result.isSuccess == false)
            {
                Console.WriteLine("get todo list fail");
            }

            TodoListResponse responseModel = new TodoListResponse(result.totalCount, result.list);

            // responseModel.TotalCount = result.totalCount;
            // if (responseModel.TotalCount > 0)
            // {
            //     responseModel.List = result.list.Select(p => new TodoListItem()
            //     {
            //         Id = p.Id,
            //         Title = p.Title,
            //         Writer = p.Writer
            //     }).ToList();
            // }
            // else
            // {
            //     responseModel.List = new List<TodoListItem>();
            // }

            return StatusCode(StatusCodes.Status200OK, responseModel);
        }
        
        // POST: 입력
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("to-do")]
        [HttpPost]
        public async Task<ActionResult> AddTodoItem([FromBody]AddTodoRequest model)
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

        // GET: 상세 조회 
        [Route("todos/{id}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoEntity>> GetTodoItem([FromRoute]int id)
        {
          
            var result = _todo.GetTodoEntity(id);

            if (result.isSuccess == false)
            {
                Console.WriteLine("get todo details fail");
            }

            return StatusCode(StatusCodes.Status200OK, result.details);;
        }

        // DELETE: 삭제
        [Route("to-do/{id}")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodoItem([FromRoute]int id)
        {
            var result = _todo.DeleteEntity(id);
            
            if (result == false)
            {
                Console.WriteLine("delete fail");
            }
            
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}

