using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQLServer.Models;

namespace GraphQLServer.Schema
{
    public interface IQuery
    {
         Task<List<Author>> GetAuthorsAsync();
         Task<List<Book>> GetBooksAsync();
    }
}