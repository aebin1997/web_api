using TodoApi.Models.Entities;
using TodoApi.Models.Response;
using TodoApi.Models.Request;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Services;

public interface ITodoService
{
    bool AddTodoEntity(string title, string password, string writer);
    (bool isSuccess, List<TodoListItem> list, int totalCount) GetTodoEntities();
    (bool isSuccess, TodoDetailResponse details) GetTodoEntity(int id);
    bool DeleteEntity(int id);
    
    
}

public class TodoService : ITodoService
{
    private int autoIncrement { get; set; } = 0;
    
    private List<TodoEntity> todos = new List<TodoEntity>();
    
    public (bool isSuccess, List<TodoListItem> list, int totalCount) GetTodoEntities()
    {
        try
        {
            if (todos == null)
            {
                return (false, null, 0)!;
            }

            var list = (from todo in todos
                select new TodoListItem
                {
                    Id = todo.Id,
                    Title = todo.Title,
                    Writer = todo.Writer
                }).ToList();

            return (true, list, todos.Count);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return (false, null, 0)!;
        }
    }
    
    public bool AddTodoEntity(string title, string password, string writer)
    {
        try
        {
            autoIncrement += 1;
            
            var todo = new TodoEntity
            {
                Id = autoIncrement,
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

    public bool DeleteEntity(int id)
    {
        try
        {
            if (todos == null)
            {
                return false;
            }

            var todoItem = todos.FirstOrDefault(p => p.Id == id);
            
            if (todoItem == null)
            {
                return false;
            }
        
            todos.Remove(todoItem);

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
    
    public (bool isSuccess, TodoDetailResponse details) GetTodoEntity(int id)
    {
        try
        {
            if (todos == null)
            {
                return (false, null)!;
            }
            
            var todoItem = todos.FirstOrDefault(p => p.Id == id);
            
            if (todoItem == null)
            {
                return (false, null)!;
            }

            var details = new TodoDetailResponse();
            details.Id = todoItem.Id;
            details.Title = todoItem.Title;
            details.Writer = todoItem.Writer;
            details.RegTime = todoItem.RegTime;

            return (true, details);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return (false, null)!;
        }
    }
}