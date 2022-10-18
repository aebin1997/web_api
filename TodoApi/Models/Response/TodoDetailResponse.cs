namespace TodoApi.Models.Response;

/// <summary>
/// 할일 상세 조회 응답 클래스
/// </summary>
public class TodoDetailResponse
{
    public long Id { get; set; }

    public string Title { get; set; } = "";

    public string Writer { get; set; } = "";

    public DateTime RegTime { get; set; } = DateTime.UtcNow;

}