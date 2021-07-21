using System.Threading.Tasks;
using GraphQLServer.DataAccess;
using GraphQLServer.Models;
using GraphQLServer.Schema.InputTypes;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLServer.Schema
{
    public class Mutation : IMutation
    {
        public async Task<Author> CreateAuthorAsync(AuthorInput input, [Service] MyDbContext db)
        {
            var author = new Author
            {
                Name = input.Name
            };

            await db.Set<Author>().AddAsync(author);
            await db.SaveChangesAsync();

            return await db.Authors
                .Include(a => a.Books)
                .SingleOrDefaultAsync(a => a.Id == author.Id);
        }

        public async Task<Book> CreateBookAsync(BookInput input, [Service] MyDbContext db)
        {
            var book = new Book
            {
                Title = input.Title,
                AuthorID = input.AuthorID
            };

            await db.Set<Book>().AddAsync(book);
            await db.SaveChangesAsync();

            return await db.Books
                .Include(b => b.Author)
                .SingleOrDefaultAsync(b => b.Id == book.Id);
        }
    }
}