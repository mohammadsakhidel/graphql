using System.Collections.Generic;

namespace GraphQLServer.Models
{
    public class Author
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
        
        public List<Book> Books { get; set; }
    }
}