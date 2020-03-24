using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Areas.Identity.Data;
using blog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace blog.Data
{
    public class BlogIdentityDbContext : IdentityDbContext<Writer>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }

        public BlogIdentityDbContext(DbContextOptions<BlogIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
      /*       builder.Entity<Post>()
                .Property(b => b.ModifiedDate)
                .HasDefaultValueSql("getdate()"); */

      /*       builder.Entity<Category>()
                .Property(b => b.ModifiedDate)
                .HasDefaultValueSql("getdate()"); */

            builder.Entity<PostTag>()
                .HasKey(pt => new { pt.TagID, pt.PostID });

            builder.Entity<PostTag>()
                .HasOne(pt => pt.Post)
                .WithMany(b => b.PostTags)
                .HasForeignKey(pt => pt.PostID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PostTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(c => c.postTags)
                .HasForeignKey(pt => pt.TagID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Writer>()
                    .HasMany(w => w.posts)
                    .WithOne(t => t.Writer)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Category>().HasMany(c => c.Posts).WithOne(p => p.Category).HasForeignKey(p => p.CategoryID).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Writer>().HasMany(w => w.Categories).WithOne(c => c.writer).OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}
