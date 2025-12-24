namespace ATNewsprimeApp.Entitys
{
    public class Comment
    {
        public int Id { get; set; }
        public int NewsId { get; set; }   //FK
        public string UserName { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;


        public News AllNews { get; set; } // navigation Property

    }
}
