using Examination.Domain.Entities.Students;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Data.DbContexts
{
    public class ExaminationDbContext : DbContext
    {
        private readonly string ConnectionString = "Host=localhost;Port=5432;Database=Examination;Username=postgres;Password=Xaxa2004;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
        }
        
        public DbSet<Student> Students { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
    }
}
