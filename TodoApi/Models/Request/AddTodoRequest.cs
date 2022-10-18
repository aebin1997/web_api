namespace TodoApi.Models;

/// <summary>
/// 할일 등록 요청 클래스
/// </summary>
public class AddTodoRequest
{
    public string Title { get; set; }
    
    public string Password { get; set; }
    
    public string Writer { get; set; }
}