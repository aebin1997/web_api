using TodoApi.Models.Entities;
using TodoApi.Models.Request;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Services;

public interface ITodoService
{
    bool AddTodoEntity(string title, string password, string writer);
}

public class TodoService : ITodoService
{
    private int autoIncrement { get; set; } = 0;
    
    private List<TodoEntity> todos = new List<TodoEntity>();
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