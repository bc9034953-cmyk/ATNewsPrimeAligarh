namespace ATNewsprimeApp.DtoRequest
{
    public class AddCommentRequest
    {
        public int NewsId { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
    }
}
