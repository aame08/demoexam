using Microsoft.EntityFrameworkCore;

namespace Demo.Models;

public partial class DemoContext : DbContext
{
    public DemoContext()
    {
    }

    public DemoContext(DbContextOptions<DemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MaterialType> MaterialTypes { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnersProduct> PartnersProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;user=root;password=ame0372;database=demo", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<MaterialType>(entity =>
        {
            entity.HasKey(e => e.IdMaterialType).HasName("PRIMARY");

            entity.ToTable("material_type");

            entity.Property(e => e.IdMaterialType).HasColumnName("id_material_type");
            entity.Property(e => e.DefectType)
                .HasColumnType("double(3,2)")
                .HasColumnName("defect_type");
            entity.Property(e => e.NameMaterialType)
                .HasMaxLength(50)
                .HasColumnName("name_material_type");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.IdPartner).HasName("PRIMARY");

            entity.ToTable("partners");

            entity.Property(e => e.IdPartner).HasColumnName("id_partner");
            entity.Property(e => e.AddressCity)
                .HasMaxLength(50)
                .HasColumnName("address_city");
            entity.Property(e => e.AddressHome)
                .HasMaxLength(20)
                .HasColumnName("address_home");
            entity.Property(e => e.AddressIndex).HasColumnName("address_index");
            entity.Property(e => e.AddressLocality)
                .HasMaxLength(50)
                .HasColumnName("address_locality");
            entity.Property(e => e.AddressStreet)
                .HasMaxLength(50)
                .HasColumnName("address_street");
            entity.Property(e => e.DirectorName)
                .HasMaxLength(50)
                .HasColumnName("director_name");
            entity.Property(e => e.DirectorPatronymic)
                .HasMaxLength(50)
                .HasColumnName("director_patronymic");
            entity.Property(e => e.DirectorSurname)
                .HasMaxLength(100)
                .HasColumnName("director_surname");
            entity.Property(e => e.EmailPartner)
                .HasMaxLength(100)
                .HasColumnName("email_partner");
            entity.Property(e => e.InnPartner)
                .HasMaxLength(11)
                .HasColumnName("inn_partner");
            entity.Property(e => e.NamePartner)
                .HasMaxLength(50)
                .HasColumnName("name_partner");
            entity.Property(e => e.PhomeNumber)
                .HasMaxLength(15)
                .HasColumnName("phome_number");
            entity.Property(e => e.RatingPartner).HasColumnName("rating_partner");
            entity.Property(e => e.TypePartner)
                .HasMaxLength(3)
                .HasColumnName("type_partner");
        });

        modelBuilder.Entity<PartnersProduct>(entity =>
        {
            entity.HasKey(e => e.IdPartnersProducts).HasName("PRIMARY");

            entity.ToTable("partners_products");

            entity.HasIndex(e => e.ArticleProduct, "article_product");

            entity.HasIndex(e => e.IdPartner, "id_partner");

            entity.Property(e => e.IdPartnersProducts).HasColumnName("id_partners_products");
            entity.Property(e => e.ArticleProduct)
                .HasMaxLength(7)
                .IsFixedLength()
                .HasColumnName("article_product");
            entity.Property(e => e.CountProduct).HasColumnName("count_product");
            entity.Property(e => e.DateSale).HasColumnName("date_sale");
            entity.Property(e => e.IdPartner).HasColumnName("id_partner");

            entity.HasOne(d => d.ArticleProductNavigation).WithMany(p => p.PartnersProducts)
                .HasForeignKey(d => d.ArticleProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("partners_products_ibfk_1");

            entity.HasOne(d => d.IdPartnerNavigation).WithMany(p => p.PartnersProducts)
                .HasForeignKey(d => d.IdPartner)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("partners_products_ibfk_2");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ArticleProduct).HasName("PRIMARY");

            entity.ToTable("products");

            entity.HasIndex(e => e.IdProductType, "id_product_type");

            entity.Property(e => e.ArticleProduct)
                .HasMaxLength(7)
                .IsFixedLength()
                .HasColumnName("article_product");
            entity.Property(e => e.IdProductType).HasColumnName("id_product_type");
            entity.Property(e => e.MinCost)
                .HasColumnType("double(6,2)")
                .HasColumnName("min_cost");
            entity.Property(e => e.NameProduct)
                .HasMaxLength(255)
                .HasColumnName("name_product");

            entity.HasOne(d => d.IdProductTypeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdProductType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_ibfk_1");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.IdProductType).HasName("PRIMARY");

            entity.ToTable("product_type");

            entity.Property(e => e.IdProductType).HasColumnName("id_product_type");
            entity.Property(e => e.CoefficientProductType)
                .HasColumnType("double(3,2)")
                .HasColumnName("coefficient_product_type");
            entity.Property(e => e.NameProductType)
                .HasMaxLength(50)
                .HasColumnName("name_product_type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
