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
        public ModelContext() : base(ConfigurationManager.AppSettings["ConnectionString"])
        {
        }

        public DbSet<UserDto> Users { get; set; }       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);           
        }
    }
}
