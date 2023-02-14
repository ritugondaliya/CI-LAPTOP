using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace entityDataFirst.DataModels;

public partial class EmployeeDbContext : DbContext
{
    public EmployeeDbContext()
    {
    }

    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Salesman> Salesmen { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:connstr");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__customer__CD65CB8500573648");

            entity.ToTable("customer");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("customer_id");
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.CustName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("cust_name");
            entity.Property(e => e.Grade).HasColumnName("grade");
            entity.Property(e => e.SalesmanId).HasColumnName("salesman_id");

            entity.HasOne(d => d.Salesman).WithMany(p => p.Customers)
                .HasForeignKey(d => d.SalesmanId)
                .HasConstraintName("FK__customer__salesm__571DF1D5");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptId).HasName("PK__Departme__DCA65974C755A9C4");

            entity.ToTable("Department");

            entity.Property(e => e.DeptId)
                .ValueGeneratedNever()
                .HasColumnName("dept_id");
            entity.Property(e => e.DeptName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dept_name");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Employee__1299A861835F67CB");

            entity.ToTable("Employee");

            entity.Property(e => e.EmpId)
                .ValueGeneratedNever()
                .HasColumnName("emp_id");
            entity.Property(e => e.DeptId).HasColumnName("dept_id");
            entity.Property(e => e.EmpName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("emp_name");
            entity.Property(e => e.MngrId).HasColumnName("mngr_id");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrdNo).HasName("PK__orders__DC38690481D7769A");

            entity.ToTable("orders");

            entity.Property(e => e.OrdNo)
                .ValueGeneratedNever()
                .HasColumnName("ord_no");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.OrdDate)
                .HasColumnType("date")
                .HasColumnName("ord_date");
            entity.Property(e => e.PurchAmt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("purch_amt");
            entity.Property(e => e.SalesmanId).HasColumnName("salesman_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__orders__customer__59FA5E80");

            entity.HasOne(d => d.Salesman).WithMany(p => p.Orders)
                .HasForeignKey(d => d.SalesmanId)
                .HasConstraintName("FK__orders__salesman__5AEE82B9");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6ED329F0513");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("ProductID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ReorderLevel).HasColumnName("REorderLevel");
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 4)");
        });

        modelBuilder.Entity<Salesman>(entity =>
        {
            entity.HasKey(e => e.SalesmanId).HasName("PK__salesman__A8A8389F66C85776");

            entity.ToTable("salesman");

            entity.Property(e => e.SalesmanId)
                .ValueGeneratedNever()
                .HasColumnName("salesman_id");
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Commission).HasColumnName("commission");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
