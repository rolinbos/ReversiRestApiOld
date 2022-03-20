using Microsoft.EntityFrameworkCore;
using ReversiRestApi.Models;

namespace ReversiRestApi.Dal
{
    public class ApiContext: DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
            
        }
        
        public DbSet<Game> Game { get; set; }
    }
}