namespace TodoApi.Models.Response;

/// <summary>
/// 할일 목록 응답 클래스
/// </summary>
public class TodoListResponse
{
    public long TotalCount { get; set; }

    public List<TodoListItem> List { get; set; }

    // 생성자: 인스턴스를 만들 때 사용하는 클래스와 이름이 같은 메서드
    public TodoListResponse(int totalCount, List<TodoListItem> list)
    {
        // 서비스에서 반환 받은 데이터를 해당 위치에서 데이터를 입력할 수 있도록 수정한다.
        this.TotalCount = totalCount;
        this.List = list;
    }
}

public class TodoListItem
{
    public long Id { get; set; }

    public string Title { get; set; } = "";

    public string Writer { get; set; } = "";
}