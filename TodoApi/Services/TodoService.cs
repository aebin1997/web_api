using TodoApi.Models.Entities;
using TodoApi.Models.Response;
using TodoApi.Models.Request;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Services;

public interface ITodoService
{
    bool AddTodoEntity(string title, string password, string writer);
    (bool isSuccess, List<TodoListItem> list) GetTodoEntities();

    // bool GetTodoEntity();
    // bool DeleteEntity(long id);
}

public class TodoService : ITodoService
{
    private int autoIncrement { get; set; } = 0;
    
    private List<TodoEntity> todos = new List<TodoEntity>();
    
    public (bool isSuccess, List<TodoListItem> list) GetTodoEntities()
    {
        try
        {
            if (todos == null)
            {
                return (false, null)!;
            }

            var list = (from todo in todos
                select new TodoListItem
                {
                    Id = todo.Id,
                    Title = todo.Title,
                    Writer = todo.Writer
                }).ToList();

            return (true, list);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return (false, null)!;
        }
    }
    
    public bool AddTodoEntity(string title, string password, string writer)
    {
        try
        {
            autoIncrement += 1;
            
            var todo = new TodoEntity
            {
                Title = title,
                Password = password,
                Writer = writer
            };

            todos.Add(todo);
            
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }

    
}