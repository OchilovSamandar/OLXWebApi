using Microsoft.EntityFrameworkCore;
using OLXWebApi.Domain.Entities;
using OLXWebApi.Shared.Helper;

namespace OLXWebApi.Data.DbContexts
{
    public class OlxDbContext: DbContext
    {
        public OlxDbContext(DbContextOptions<OlxDbContext> options) :
            base(options) 
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<MyAds> MyAds { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
               new User() { Id = 1, Firstname = "Mukhammadkarim", Lastname = "Tukhtaboyev", Email = "dotnetgo@icloud.com",  UserRole = Domain.Enums.UserRole.User,Awatar = null, Password = PasswordHelper.Hash("12345678"),MyAdsList=null,MyAnnouncementList=null,IsActive=true, CreatedAt = DateTime.UtcNow, UpdatedAt = null },
               new User() { Id = 2, Firstname = "Jamshid", Lastname = "Ma'ruf", Email = "wonderboy1w3@gmail.com",  UserRole = Domain.Enums.UserRole.User,Awatar = null, Password = PasswordHelper.Hash("12345678"),MyAdsList=null,MyAnnouncementList=null,IsActive=true, CreatedAt = DateTime.UtcNow, UpdatedAt = null },
               new User() { Id = 3, Firstname = "Samandar", Lastname = "Ochilov", Email = "ochilovsamandar71@gmail.com", UserRole = Domain.Enums.UserRole.User, Password = PasswordHelper.Hash("12345678"), MyAdsList = null, MyAnnouncementList = null, IsActive = true, CreatedAt = DateTime.UtcNow, UpdatedAt = null }
               //new User() { Id = 4, FirstName = "Muzaffar", LastName = "Nurillayev", Email = "nurillaewmuzaffar@gmail.com", Phone = "+998 995030110", RoleId = 5, Password = PasswordHelper.Hash("12345678"), CreatedAt = DateTime.UtcNow, UpdatedAt = null },
               //new User() { Id = 5, FirstName = "Azim", LastName = "Ochilov", Email = "azimochilov@icloud.com", Phone = "+998 991233999", RoleId = 6, Password = PasswordHelper.Hash("12345678"), CreatedAt = DateTime.UtcNow, UpdatedAt = null },
               //new User() { Id = 6, FirstName = "Abdulloh", LastName = "Ahmadjonov", Email = "abdulloh@icloud.com", Phone = "+998 991236999", RoleId = 1, Password = PasswordHelper.Hash("12345678"), CreatedAt = DateTime.UtcNow, UpdatedAt = null },
               //new User() { Id = 7, FirstName = "Komron", LastName = "Rahmonov", Email = "komron2052@gmail.com", Phone = "+998 991234999", RoleId = 2, Password = PasswordHelper.Hash("12345678"), CreatedAt = DateTime.UtcNow, UpdatedAt = null },
               //new User() { Id = 8, FirstName = "Nozimjon", LastName = "Usmonaliyev", Email = "nozimjon@gmail.com", Phone = "+998 991235999", RoleId = 3, Password = PasswordHelper.Hash("12345678"), CreatedAt = DateTime.UtcNow, UpdatedAt = null },
               //new User() { Id = 9, FirstName = "AlJavhar", LastName = "Boyaliyev", Email = "aljavhar@gmail.com", Phone = "+998 902344545", RoleId = 4, Password = PasswordHelper.Hash("12345678"), CreatedAt = DateTime.UtcNow, UpdatedAt = null },
               //new User() { Id = 10, FirstName = "Muhammad", LastName = "Rahimboyev", Email = "muhammad@gmail.com", Phone = "+998 937770202", RoleId = 5, Password = PasswordHelper.Hash("12345678"), CreatedAt = DateTime.UtcNow, UpdatedAt = null }
               );
        }
    }
}
