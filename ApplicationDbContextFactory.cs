using ATNewsprimeApp.DbContent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        optionsBuilder.UseSqlServer(
     "Server=DESKTOP-QBOBP9C\\SQLEXPRESS;Database=ATNewsprimeDb;Trusted_Connection=True;TrustServerCertificate=True;",
     sqlOptions => sqlOptions.EnableRetryOnFailure()
 );


        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
