namespace ATNewsprimeApp.DtoRequest
{
    public class NewsCreateRequest
    {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Slug { get; set; }
            public string ImageUrl { get; set; }
            public string ShortDescription { get; set; }
            public string FullDescription { get; set; }


            // Foreign key properties
            public int CategoryId { get; set; }
            public int CreatedByAdminId { get; set; }



            public bool IsPublished { get; set; }

    }
}
