using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.CitasMedicas
{
    public class contexto: DbContext
    {
        public contexto(): base("Citas Medicas")
        {
            

        }
        protected override void  OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<Paciente> Paciente { get; set; }
    }
}
