namespace TodoApi.Models.Entities
{
    public class TodoEntity
    {
        public long Id { get; set; }
        public string Title { get; set; } = "";
        public string Writer { get; set; } = "";
        public string Password { get; set; } = "";
        public DateTime RegTime { get; set; } = DateTime.UtcNow;
        // public string? Name { get; set; }
        // public bool IsComplete { get; set; }
    }
}

// 모델은 앱에서 관리하는 데이터를 나타내는 일련의 클래스입니다. 
// 모델 클래스는 프로젝트의 어디로든 이동할 수 있지만 규칙에 따라 Models 폴더를 사용합니다.