using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost\\SQLEXPRESS;database=SirketDb;integrated security=true;");
        }


        public DbSet<Sirket> Sirkets { get; set; }
        public DbSet<Departman> Departmans { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Personel> Personels { get; set; }
    }
}
