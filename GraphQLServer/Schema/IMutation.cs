using System.Threading.Tasks;
using GraphQLServer.DataAccess;
using GraphQLServer.Models;
using GraphQLServer.Schema.InputTypes;
using HotChocolate;

namespace GraphQLServer.Schema
{
    public interface IMutation
    {
        Task<Author> CreateAuthorAsync(AuthorInput input, [Service] MyDbContext db);
        Task<Book> CreateBookAsync(BookInput input, [Service] MyDbContext db);
    }
}