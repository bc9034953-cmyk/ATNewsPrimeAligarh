using ATNewsprimeApp.Entitys;

namespace ATNewsprimeApp.DtoResponse
{
    public class CommentResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int NewsId { get; set; }
        public int CommentId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
