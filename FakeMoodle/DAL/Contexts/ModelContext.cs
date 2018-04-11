using DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contexts
{
    public class ModelContext : DbContext
    {
        static Type type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);


        public ModelContext() : base(ConfigurationManager.AppSettings["ConnectionString"])
        {
        }

        public DbSet<SubmissionDto> Submissions { get; set; }

        public DbSet<UserDto> Users { get; set; }

        public DbSet<AttendanceDto> Attendances { get; set; }

        public DbSet<LaboratoryDto> Laboratories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<LaboratoryDto>().HasOptional(x => x.Assignment).WithRequired(x => x.Laboratory);
        }
    }
}
