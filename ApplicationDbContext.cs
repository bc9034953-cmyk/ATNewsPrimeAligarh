using ATNewsprimeApp.DtoRequest;
using ATNewsprimeApp.Entitys;
using Microsoft.EntityFrameworkCore;

namespace ATNewsprimeApp.DbContent
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {

        }


        // Tables
        public DbSet<Admin> AllAdmins { get; set; }
        public DbSet<Category> AllCategories { get; set; }
        public DbSet<News> AllNewses { get; set; }
        public DbSet<Comment> AllComments { get; set; }
        public DbSet<Password> PasswordReset { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Admin>().ToTable("AllAdmins");
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 1,
                    Name = "Sharad",
                    Email = "SharadSDS@gmail.com",
                    PasswordHash = "$2a$12$Ktx9sC3f/pYvJ2QhPbU6yeq6bWn5pJ.0sTj9DfB9FjPi/6eKn1T5G",
                    Role = "SuperAdmin",
                    PhoneNumber = "9999999999",
                    CreatedAt = DateTime.Now
                }
            );

            modelBuilder.Entity<Comment>()  
                .HasOne(c => c.AllNews)
                .WithMany(n => n.Comments)
                .HasForeignKey(c => c.NewsId)
                .OnDelete(DeleteBehavior.Cascade);


       //     modelBuilder.Entity<PasswordReset>()
       //.HasOne(p => p.Admin)
       //.WithMany()
       //.HasForeignKey(p => p.AdminId);

       //     base.OnModelCreating(modelBuilder);

        }



    }
}

