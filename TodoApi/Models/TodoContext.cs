using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; } = null!;
    }

    // #region Response Model
    //
    // public class TodoList // 목록 조회
    // {
    //     
    //     
    // }
    //
    // public class TodoDetails // 상세 조회
    // {
    //     
    // }
    //
    // #endregion
    //
    // #region Request Model
    //
    // public class AddTodo // 입력
    // {
    //
    // }
    //
    // public class Delete // 삭제
    // {
    //     
    // }
    //
    // #endregion

    
}
