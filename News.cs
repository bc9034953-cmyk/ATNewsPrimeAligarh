namespace ATNewsprimeApp.Entitys
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string ImageUrl { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }

        // Foreign key properties
        public int CategoryId { get; set; }
        public Category Category { get; set; } // navigation property


        public int CreatedByAdminId { get; set; }
        public Admin CreatedByAdmin { get; set; } // navigation property



        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }= DateTime.Now;
        public bool IsPublished { get; set; }



        public List<Comment> Comments { get; set; }


    }
}
