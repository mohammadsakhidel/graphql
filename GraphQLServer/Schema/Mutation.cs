using System.Threading.Tasks;
using GraphQLServer.DataAccess;
using GraphQLServer.Models;
using GraphQLServer.Schema.InputTypes;
using HotChocolate;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLServer.Schema
{
    public class Mutation : IMutation
    {
        public async Task<Author> CreateAuthorAsync(AuthorInput input)
        {
            var db = Program.Host.Services.GetRequiredService<MyDbContext>();

            var author = new Author
            {
                Name = input.Name
            };

            await db.Set<Author>().AddAsync(author);
            await db.SaveChangesAsync();

            return author;
        }

        public async Task<Book> CreateBookAsync(BookInput input)
        {
            var db = Program.Host.Services.GetRequiredService<MyDbContext>();

            var book = new Book
            {
                Title = input.Title,
                AuthorID = input.AuthorID
            };

            await db.Set<Book>().AddAsync(book);
            await db.SaveChangesAsync();

            return book;
        }
    }
}