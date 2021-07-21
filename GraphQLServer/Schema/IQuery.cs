using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLServer.DataAccess;
using GraphQLServer.Models;
using HotChocolate;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLServer.Schema
{
    public interface IQuery
    {
        Task<List<Author>> GetAuthorsAsync([Service] MyDbContext db);
        Task<List<Book>> GetBooksAsync([Service] MyDbContext db);
        Task<Book> GetBook(int id, [Service] MyDbContext db);
    }
}