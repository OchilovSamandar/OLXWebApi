using Microsoft.EntityFrameworkCore;
using OLXWebApi.Domain.Entities;

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
    }
}
