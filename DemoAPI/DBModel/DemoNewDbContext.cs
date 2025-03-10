using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.DBModel;

public partial class DemoNewDbContext : DbContext
{
    public DemoNewDbContext()
    {
    }

    public DemoNewDbContext(DbContextOptions<DemoNewDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmployeeInsertedDatum> EmployeeInsertedData { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<TblEmployee> TblEmployees { get; set; }

    public virtual DbSet<TblEmployeeType> TblEmployeeTypes { get; set; }

    public virtual DbSet<TblGender> TblGenders { get; set; }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    public virtual DbSet<TblProductsSale> TblProductsSales { get; set; }

    public virtual DbSet<Tbldepartment> Tbldepartments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=DESKTOP-JVCT4QT\\MSSQLSERVER01;integrated security=SSPI;database=DemoNewDB;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeInsertedDatum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("employee_inserted_data");

            entity.Property(e => e.EmpMessage)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("emp_message");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__patient__3213E83F4C25E290");

            entity.ToTable("patient");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TblEmployee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__tblEmplo__1299A861561F6C84");

            entity.ToTable("tblEmployee");

            entity.HasIndex(e => e.Email, "UQ__tblEmplo__AB6E616477DDEEF6").IsUnique();

            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.Age)
                .HasDefaultValue(1)
                .HasColumnName("age");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasDefaultValue("abc@abc.com")
                .HasColumnName("email");
            entity.Property(e => e.EmpAddress)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("emp_address");
            entity.Property(e => e.EmpDeptId).HasColumnName("emp_dept_id");
            entity.Property(e => e.EmpGender).HasColumnName("emp_gender");
            entity.Property(e => e.EmpName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("emp_name");
            entity.Property(e => e.EmpType).HasColumnName("emp_type");
            entity.Property(e => e.MonthlySalary).HasColumnName("monthly_salary");

            entity.HasOne(d => d.EmpDept).WithMany(p => p.TblEmployees)
                .HasForeignKey(d => d.EmpDeptId)
                .HasConstraintName("FK__tblEmploy__emp_d__5FB337D6");

            entity.HasOne(d => d.EmpGenderNavigation).WithMany(p => p.TblEmployees)
                .HasForeignKey(d => d.EmpGender)
                .HasConstraintName("FK__tblEmploy__emp_g__5BE2A6F2");

            entity.HasOne(d => d.EmpTypeNavigation).WithMany(p => p.TblEmployees)
                .HasForeignKey(d => d.EmpType)
                .HasConstraintName("fk_emp_type");
        });

        modelBuilder.Entity<TblEmployeeType>(entity =>
        {
            entity.HasKey(e => e.EpmTypeId).HasName("PK__tblEmplo__689DA96B3C5997E0");

            entity.ToTable("tblEmployeeType");

            entity.Property(e => e.EpmTypeId).HasColumnName("epm_type_id");
            entity.Property(e => e.EmpTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("emp_type_name");
        });

        modelBuilder.Entity<TblGender>(entity =>
        {
            entity.HasKey(e => e.GenId).HasName("PK__tblGende__7268D78B23906AA1");

            entity.ToTable("tblGender");

            entity.Property(e => e.GenId).HasColumnName("gen_id");
            entity.Property(e => e.GenName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("gen_name");
        });

        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblProdu__3213E83FD11D8EAD");

            entity.ToTable("tblProducts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TblProductsSale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblProdu__3213E83F4F088AEB");

            entity.ToTable("tblProductsSales");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.QuantitySold).HasColumnName("quantitySold");

            entity.HasOne(d => d.Product).WithMany(p => p.TblProductsSales)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__tblProduc__produ__7E37BEF6");
        });

        modelBuilder.Entity<Tbldepartment>(entity =>
        {
            entity.HasKey(e => e.DeptId).HasName("PK__tbldepar__DCA65974226862B6");

            entity.ToTable("tbldepartment");

            entity.Property(e => e.DeptId).HasColumnName("dept_id");
            entity.Property(e => e.DeptName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("dept_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
