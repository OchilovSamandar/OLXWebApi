﻿using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using OLXWebApi.Domain.Entities;
using OLXWebApi.Domain.Enums;
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
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().HasData(
            //   new User() { Id = 1, Firstname = "Mukhammadkarim", Lastname = "Tukhtaboyev", Email = "dotnetgo@icloud.com",  Role = UserRole.User,Awatar = null, Password = PasswordHelper.Hash("12345678"),MyAdsList=null,MyAnnouncementList=null,IsActive=true, CreatedAt = DateTime.UtcNow, UpdatedAt = null },
            //   new User() { Id = 2, Firstname = "Jamshid", Lastname = "Ma'ruf", Email = "wonderboy1w3@gmail.com",  Role = UserRole.User,Awatar = null, Password = PasswordHelper.Hash("12345678"),MyAdsList=null,MyAnnouncementList=null,IsActive=true, CreatedAt = DateTime.UtcNow, UpdatedAt = null },
            //   new User() { Id = 3, Firstname = "Samandar", Lastname = "Ochilov", Email = "ochilovsamandar71@gmail.com", Role = UserRole.Admin,Awatar = null, Password = PasswordHelper.Hash("12345678"), MyAdsList = null, MyAnnouncementList = null, IsActive = true, CreatedAt = DateTime.UtcNow, UpdatedAt = null }
            //   );

            modelBuilder.Entity<Role>().HasData(
              new Role() { Id = 1 , Name="Admin",CreatedAt =  DateTime.UtcNow ,UpdatedAt = null},
              new Role() { Id = 2 , Name="User",CreatedAt =  DateTime.UtcNow ,UpdatedAt = null}
                );
        }
    }
}
