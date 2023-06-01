using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UserWebAPI.Models
{
    public partial class EMP_CURDContext : DbContext
    {
        public EMP_CURDContext()
        {
        }

        public EMP_CURDContext(DbContextOptions<EMP_CURDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeV2> EmployeeV2s { get; set; } = null!;
        public virtual DbSet<TblUser> TblUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                //optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=EMP_CURD;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Empid);

                entity.Property(e => e.Empid).HasColumnName("EMPId");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);
            });

            modelBuilder.Entity<EmployeeV2>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.IUserId);

                entity.ToTable("tblUsers");

                entity.Property(e => e.IUserId).HasColumnName("iUser_Id");

                entity.Property(e => e.DtDateOfBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("dtDateOfBirth");

                entity.Property(e => e.StrEmail)
                    .HasMaxLength(200)
                    .HasColumnName("strEmail");

                entity.Property(e => e.StrFirstName)
                    .HasMaxLength(128)
                    .HasColumnName("strFirst_Name");

                entity.Property(e => e.StrLastName)
                    .HasMaxLength(128)
                    .HasColumnName("strLast_Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
