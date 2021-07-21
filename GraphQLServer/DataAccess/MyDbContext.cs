using GraphQLServer.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLServer.DataAccess
{
    public class MyDbContext : DbContext
    {
        

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseMySQL("Server=localhost;Database=graphql_db;Uid=root;Pwd=;");

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorID);

            builder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author);

        }



    }
}

