using Microsoft.EntityFrameworkCore;
using ProAgil.WebApi.Model;

namespace ProAgil.WebApi.Data
{
    public class DataContex : DbContext
    {
        public DataContex(DbContextOptions<DataContex> options) : base (options){}

        public DbSet<Evento> Eventos {get;set;}
    }
}