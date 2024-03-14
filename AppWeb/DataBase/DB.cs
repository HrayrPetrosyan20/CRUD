using AppWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace AppWeb.DataBase
{
    public class DB:DbContext
    {
        public DB(DbContextOptions<DB> options) : base(options) { }
        public DbSet<Humans> human { get; set; }
    }
}
