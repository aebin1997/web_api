namespace TodoApi.Models.Response;

/// <summary>
/// 할일 목록 응답 클래스
/// </summary>
public class TodoListResponse
{
    public long TotalCount { get; set; }

    public List<TodoListItem> List { get; set; } = null!;
}

public class TodoListItem
{
    public long Id { get; set; }

    public string Title { get; set; } = "";

    public string Writer { get; set; } = "";
}