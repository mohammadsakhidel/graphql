using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLServer.DataAccess;
using GraphQLServer.Models;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLServer.Schema
{
    public class Query : IQuery
    {
        public async Task<List<Author>> GetAuthorsAsync()
        {
            using var db = Program.Host.Services.GetRequiredService<MyDbContext>() as MyDbContext;
            return await Task.Run(() =>
            {
                return db.Authors.Include(a => a.Books).ToList();
            });
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            using var db = Program.Host.Services.GetRequiredService<MyDbContext>() as MyDbContext;
            return await Task.Run(() =>
            {
                return db.Books.Include(b => b.Author).ToList();
            });
        }

        public async Task<Book?> GetBook(int id)
        {
            var db = Program.Host.Services.GetRequiredService<MyDbContext>();
            return await Task.Run(() =>
            {
                return db.Books
                    .Include(b => b.Author)
                    .SingleOrDefault(b => b.ID == id);
            });
        }
    }
}
