using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLServer.DataAccess;
using GraphQLServer.Models;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLServer.Schema
{
    public interface IQuery
    {
         Task<List<Author>> GetAuthorsAsync();
         Task<List<Book>> GetBooksAsync();
         Task<Book> GetBook(int id);
    }
}