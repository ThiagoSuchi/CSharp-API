using Microsoft.EntityFrameworkCore;
using ProjectCSharp.models;

namespace ProjectCSharp.Data
{
    // É necessário herdar de DbContext para criar o contexto(conexão) do banco de dados
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions options) : base(options) {}         

        public DbSet<Personagem> DBZ { get; set; }
        
    }
}