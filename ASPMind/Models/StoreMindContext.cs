using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASPMind.Models;

public partial class StoreMindContext : DbContext
{
    public StoreMindContext()
    {
    }

    public StoreMindContext(DbContextOptions<StoreMindContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<InventoryAsignation> InventoryAsignations { get; set; }

    public virtual DbSet<InventoryType> InventoryTypes { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<MonitorAsignation> MonitorAsignations { get; set; }

    public virtual DbSet<MonitorInventory> MonitorInventories { get; set; }

    public virtual DbSet<StockType> StockTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-B79K8JR\\SQLEXPRESS; Database=StoreMind; Trusted_Connection=True; TrustServerCertificate=True; MultipleActiveResultSets=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Brand");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Employee");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Inventory");

            entity.Property(e => e.Available).HasColumnName("available");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.IdModel).HasColumnName("id_model");
            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("serialNumber");
        });

        modelBuilder.Entity<InventoryAsignation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("InventoryAsignation");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.IdEmployee).HasColumnName("id_employee");
            entity.Property(e => e.IdInventory).HasColumnName("id_inventory");
        });

        modelBuilder.Entity<InventoryType>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("InventoryType");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Model");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.IdBrand).HasColumnName("id_brand");
            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.StockAvailable).HasColumnName("stockAvailable");
        });

        modelBuilder.Entity<MonitorAsignation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MonitorAsignation");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.IdEmployee).HasColumnName("id_employee");
            entity.Property(e => e.IdInventoy).HasColumnName("id_inventoy");
        });

        modelBuilder.Entity<MonitorInventory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MonitorInventory");

            entity.Property(e => e.Available).HasColumnName("available");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.IdModel).HasColumnName("id_model");
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("serialNumber");
        });

        modelBuilder.Entity<StockType>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("StockType");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
