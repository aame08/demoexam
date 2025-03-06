using Microsoft.EntityFrameworkCore;

namespace Demo2.Models;

public partial class Demo2Context : DbContext
{
    public Demo2Context()
    {
    }

    public Demo2Context(DbContextOptions<Demo2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderproduct> Orderproducts { get; set; }

    public virtual DbSet<Pickuppoint> Pickuppoints { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Producttype> Producttypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=ame0372;database=demo2", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.ManufacturerId).HasName("PRIMARY");

            entity.ToTable("manufacturers");

            entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");
            entity.Property(e => e.ManufacturerName)
                .HasMaxLength(100)
                .HasColumnName("manufacturer_name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.PointId, "point_id");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.NameClient)
                .HasMaxLength(100)
                .HasColumnName("name_client");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.OrderDeliveryDate).HasColumnName("order_deliveryDate");
            entity.Property(e => e.OrderStatus)
                .HasColumnType("text")
                .HasColumnName("order_status");
            entity.Property(e => e.PatronymicClient)
                .HasMaxLength(100)
                .HasColumnName("patronymic_client");
            entity.Property(e => e.PointId).HasColumnName("point_id");
            entity.Property(e => e.ReceiptCode).HasColumnName("receipt_code");
            entity.Property(e => e.SurnameClient)
                .HasMaxLength(100)
                .HasColumnName("surname_client");

            entity.HasOne(d => d.Point).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PointId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_ibfk_1");
        });

        modelBuilder.Entity<Orderproduct>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ArticleNumberProduct })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("orderproducts");

            entity.HasIndex(e => e.ArticleNumberProduct, "articleNumber_product");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ArticleNumberProduct)
                .HasMaxLength(100)
                .HasColumnName("articleNumber_product")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CountProduct).HasColumnName("count_product");

            entity.HasOne(d => d.ArticleNumberProductNavigation).WithMany(p => p.Orderproducts)
                .HasForeignKey(d => d.ArticleNumberProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orderproducts_ibfk_2");

            entity.HasOne(d => d.Order).WithMany(p => p.Orderproducts)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orderproducts_ibfk_1");
        });

        modelBuilder.Entity<Pickuppoint>(entity =>
        {
            entity.HasKey(e => e.PointId).HasName("PRIMARY");

            entity.ToTable("pickuppoint");

            entity.Property(e => e.PointId).HasColumnName("point_id");
            entity.Property(e => e.PointCity)
                .HasMaxLength(100)
                .HasColumnName("point_city");
            entity.Property(e => e.PointHome)
                .HasMaxLength(10)
                .HasColumnName("point_home");
            entity.Property(e => e.PointIndex).HasColumnName("point_index");
            entity.Property(e => e.PointnStreet)
                .HasMaxLength(100)
                .HasColumnName("pointn_street");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ArticleNumberProduct).HasName("PRIMARY");

            entity.ToTable("products");

            entity.HasIndex(e => e.ManufacturerId, "manufacturer_id");

            entity.HasIndex(e => e.SupplierId, "supplier_id");

            entity.HasIndex(e => e.TypeId, "type_id");

            entity.Property(e => e.ArticleNumberProduct)
                .HasMaxLength(100)
                .HasColumnName("articleNumber_product")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CostProduct).HasColumnName("cost_product");
            entity.Property(e => e.DescriptionProduct)
                .HasColumnType("text")
                .HasColumnName("description_product");
            entity.Property(e => e.DiscountAmountProduct)
                .HasPrecision(2, 1)
                .HasColumnName("discountAmount_product");
            entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");
            entity.Property(e => e.MaxDiscountProduct).HasColumnName("maxDiscount_product");
            entity.Property(e => e.NameProduct)
                .HasColumnType("text")
                .HasColumnName("name_product");
            entity.Property(e => e.PhotoProduct)
                .HasColumnType("text")
                .HasColumnName("photo_product");
            entity.Property(e => e.QuantityInStockProduct).HasColumnName("quantityInStock_product");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.UnitProduct)
                .HasMaxLength(10)
                .HasColumnName("unit_product");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Products)
                .HasForeignKey(d => d.ManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_ibfk_1");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_ibfk_2");

            entity.HasOne(d => d.Type).WithMany(p => p.Products)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_ibfk_3");
        });

        modelBuilder.Entity<Producttype>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PRIMARY");

            entity.ToTable("producttypes");

            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.TypeName)
                .HasMaxLength(100)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(100)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PRIMARY");

            entity.ToTable("suppliers");

            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(100)
                .HasColumnName("supplier_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.RoleUser, "role_user");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.LoginUser)
                .HasColumnType("text")
                .HasColumnName("login_user");
            entity.Property(e => e.NameUser)
                .HasMaxLength(100)
                .HasColumnName("name_user");
            entity.Property(e => e.PasswordUser)
                .HasColumnType("text")
                .HasColumnName("password_user");
            entity.Property(e => e.PatronymicUser)
                .HasMaxLength(100)
                .HasColumnName("patronymic_user");
            entity.Property(e => e.RoleUser).HasColumnName("role_user");
            entity.Property(e => e.SurnameUser)
                .HasMaxLength(100)
                .HasColumnName("surname_user");

            entity.HasOne(d => d.RoleUserNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
