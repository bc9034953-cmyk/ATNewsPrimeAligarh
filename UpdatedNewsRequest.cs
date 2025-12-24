namespace ATNewsprimeApp.DtoRequest
{
    public class UpdatedNewsRequest
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string ImageUrl { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public int CategoryId { get; set; }
         public bool IsPublished { get; set; } 
    }
}
