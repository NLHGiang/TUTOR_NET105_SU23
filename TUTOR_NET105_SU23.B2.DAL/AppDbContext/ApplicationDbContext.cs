using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUTOR_NET105_SU23.B2.DAL.Configurations;
using TUTOR_NET105_SU23.B2.DAL.Entities;

namespace TUTOR_NET105_SU23.B2.DAL.AppDbContext
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext()
        {
            
        }

		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}

		// DbSet
		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Role> Roles { get; set; }

		// Configs
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(// ConnectionString
											"Server=MSI\\SQLEXPRESS;Database=TUTOR_NET105_SU23.B2;Trusted_Connection=True;"
											);
			}

		}

		// Create Model
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new UserConfigs());
			modelBuilder.ApplyConfiguration(new RoleConfigs());
		}
	}
}
