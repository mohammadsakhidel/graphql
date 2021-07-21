using System.Threading.Tasks;
using GraphQLServer.Models;
using GraphQLServer.Schema.InputTypes;

namespace GraphQLServer.Schema
{
    public interface IMutation
    {
         Task<Author> CreateAuthorAsync(AuthorInput input);
         Task<Book> CreateBookAsync(BookInput input);
    }
}