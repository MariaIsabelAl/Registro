using Registro.Entidades;
using Microsoft.EntityFrameworkCore;



namespace Registro.DAL
{
    public class Contexto : DbContext
    {
        public  DbSet<Personas> Personas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server= DESKTOP-5RINN5J\SQLEXPRESS; Database = TestDb; Trusted_Connection = True; ");
        }
    }
}
