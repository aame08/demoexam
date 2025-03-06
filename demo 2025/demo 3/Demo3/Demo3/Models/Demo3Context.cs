﻿using Microsoft.EntityFrameworkCore;

namespace Demo3.Models;

public partial class Demo3Context : DbContext
{
    public Demo3Context()
    {
    }

    public Demo3Context(DbContextOptions<Demo3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ListOrder> ListOrders { get; set; }

    public virtual DbSet<Manufacter> Manufacters { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Point> Points { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=ame0372;database=demo3", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("PRIMARY");

            entity.ToTable("categories");

            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.NameCategory)
                .HasMaxLength(100)
                .HasColumnName("name_category");
        });

        modelBuilder.Entity<ListOrder>(entity =>
        {
            entity.HasKey(e => new { e.IdOrder, e.IdProduct })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("list_orders");

            entity.HasIndex(e => e.IdProduct, "id_product");

            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.IdProduct)
                .HasMaxLength(100)
                .HasColumnName("id_product");
            entity.Property(e => e.CountProduct).HasColumnName("count_product");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.ListOrders)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("list_orders_ibfk_1");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.ListOrders)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("list_orders_ibfk_2");
        });

        modelBuilder.Entity<Manufacter>(entity =>
        {
            entity.HasKey(e => e.IdManufacter).HasName("PRIMARY");

            entity.ToTable("manufacters");

            entity.Property(e => e.IdManufacter).HasColumnName("id_manufacter");
            entity.Property(e => e.NameManufacter)
                .HasMaxLength(100)
                .HasColumnName("name_manufacter");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.IdPoint, "id_point");

            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.CodeGiveOrder).HasColumnName("code_give_order");
            entity.Property(e => e.DateDeliverOrder).HasColumnName("date_deliver_order");
            entity.Property(e => e.DateOrder).HasColumnName("date_order");
            entity.Property(e => e.IdPoint).HasColumnName("id_point");
            entity.Property(e => e.NameClient)
                .HasMaxLength(100)
                .HasColumnName("name_client");
            entity.Property(e => e.PatronymicClient)
                .HasMaxLength(100)
                .HasColumnName("patronymic_client");
            entity.Property(e => e.StatusOrder)
                .HasColumnType("enum('Новый','Завершен')")
                .HasColumnName("status_order");
            entity.Property(e => e.SurnameClient)
                .HasMaxLength(100)
                .HasColumnName("surname_client");

            entity.HasOne(d => d.IdPointNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdPoint)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_ibfk_1");
        });

        modelBuilder.Entity<Point>(entity =>
        {
            entity.HasKey(e => e.IdPoint).HasName("PRIMARY");

            entity.ToTable("points");

            entity.Property(e => e.IdPoint).HasColumnName("id_point");
            entity.Property(e => e.BuildPoint).HasColumnName("build_point");
            entity.Property(e => e.CityPoint)
                .HasMaxLength(100)
                .HasColumnName("city_point");
            entity.Property(e => e.IndexPoint).HasColumnName("index_point");
            entity.Property(e => e.StreetPoint)
                .HasMaxLength(100)
                .HasColumnName("street_point");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PRIMARY");

            entity.ToTable("products");

            entity.HasIndex(e => e.IdCategory, "id_category");

            entity.HasIndex(e => e.IdManufacter, "id_manufacter");

            entity.HasIndex(e => e.IdSupplier, "id_supplier");

            entity.Property(e => e.IdProduct)
                .HasMaxLength(100)
                .HasColumnName("id_product");
            entity.Property(e => e.CostProduct).HasColumnName("cost_product");
            entity.Property(e => e.CountProduct).HasColumnName("count_product");
            entity.Property(e => e.DescProduct)
                .HasMaxLength(100)
                .HasColumnName("desc_product");
            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.IdManufacter).HasColumnName("id_manufacter");
            entity.Property(e => e.IdSupplier).HasColumnName("id_supplier");
            entity.Property(e => e.ImageProduct)
                .HasMaxLength(100)
                .HasColumnName("image_product");
            entity.Property(e => e.MaxDiscount).HasColumnName("max_discount");
            entity.Property(e => e.NameProduct)
                .HasMaxLength(100)
                .HasColumnName("name_product");
            entity.Property(e => e.NowDicount).HasColumnName("now_dicount");
            entity.Property(e => e.UnitProduct)
                .HasMaxLength(100)
                .HasColumnName("unit_product");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_ibfk_3");

            entity.HasOne(d => d.IdManufacterNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdManufacter)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_ibfk_1");

            entity.HasOne(d => d.IdSupplierNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdSupplier)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_ibfk_2");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.NameRole)
                .HasMaxLength(100)
                .HasColumnName("name_role");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.IdSupplier).HasName("PRIMARY");

            entity.ToTable("suppliers");

            entity.Property(e => e.IdSupplier).HasColumnName("id_supplier");
            entity.Property(e => e.NameSupplier)
                .HasMaxLength(100)
                .HasColumnName("name_supplier");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.IdRole, "id_role");

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.LoginUser)
                .HasMaxLength(100)
                .HasColumnName("login_user");
            entity.Property(e => e.NameUser)
                .HasMaxLength(100)
                .HasColumnName("name_user");
            entity.Property(e => e.PasswordUser)
                .HasMaxLength(100)
                .HasColumnName("password_user");
            entity.Property(e => e.PatronymicUser)
                .HasMaxLength(100)
                .HasColumnName("patronymic_user");
            entity.Property(e => e.SurnameUser)
                .HasMaxLength(100)
                .HasColumnName("surname_user");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
