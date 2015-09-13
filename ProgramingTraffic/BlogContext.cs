using ProgramingTraffic.Core.Configurations;
using ProgramingTraffic.Core.Objects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProgramingTraffic
{
    public class BlogContext:DbContext
    {
        public BlogContext():base("name=ProgramingTrafficDbString")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //configure model with fluent API     
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new PostTypeConfiguration());

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }

        internal IList<Post> AllPostsByPage(int v, int split)
        {
            return (this.Database.SqlQuery<Post>("SelectPosts")).ToList(); 
            return Posts.ToList();
        }

        internal IList<Category> AllCategories()
        {
            return Categories.ToList();
        }
    }
}