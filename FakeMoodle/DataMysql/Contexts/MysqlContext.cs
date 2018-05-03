using DataContracts.Models;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMySql.Contexts
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MysqlContext : DbContext
    {

        public MysqlContext() : base(ConfigurationManager.AppSettings["ConnectionString"])
        {
        }

        public DbSet<SubmissionDto> Submissions { get; set; }

        public DbSet<UserDto> Users { get; set; }

        public DbSet<AttendanceDto> Attendances { get; set; }

        public DbSet<LaboratoryDto> Laboratories { get; set; }

        public DbSet<AssignmentDto> Assignments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);           
        }
    }
}
