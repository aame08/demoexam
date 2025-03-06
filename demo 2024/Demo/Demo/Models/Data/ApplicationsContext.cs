using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Demo.Models.Data;

public partial class ApplicationsContext : DbContext
{
    public ApplicationsContext()
    {
    }

    public ApplicationsContext(DbContextOptions<ApplicationsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<CommentApplication> CommentApplications { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<Malfunction> Malfunctions { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<RoleUser> RoleUsers { get; set; }

    public virtual DbSet<Sparepart> Spareparts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;user=root;password=ame0372;database=applications", ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.IdApplication).HasName("PRIMARY");

            entity.ToTable("application");

            entity.HasIndex(e => e.IdEquipment, "fk_a_e");

            entity.HasIndex(e => e.IdMalfunction, "fk_a_m");

            entity.HasIndex(e => e.IdUser, "fk_a_u");

            entity.Property(e => e.IdApplication).HasColumnName("ID_application");
            entity.Property(e => e.CustomersNumber)
                .HasMaxLength(15)
                .HasColumnName("customers_number");
            entity.Property(e => e.DateAddition).HasColumnName("date_addition");
            entity.Property(e => e.DescriptionProblem)
                .HasColumnType("text")
                .HasColumnName("description_problem");
            entity.Property(e => e.IdEquipment).HasColumnName("ID_equipment");
            entity.Property(e => e.IdMalfunction).HasColumnName("ID_malfunction");
            entity.Property(e => e.IdUser).HasColumnName("ID_user");
            entity.Property(e => e.Priority)
                .HasMaxLength(50)
                .HasColumnName("priority");
            entity.Property(e => e.StatusApplication)
                .HasMaxLength(50)
                .HasColumnName("status_application");

            entity.HasOne(d => d.IdEquipmentNavigation).WithMany(p => p.Applications)
                .HasForeignKey(d => d.IdEquipment)
                .HasConstraintName("fk_a_e");

            entity.HasOne(d => d.IdMalfunctionNavigation).WithMany(p => p.Applications)
                .HasForeignKey(d => d.IdMalfunction)
                .HasConstraintName("fk_a_m");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Applications)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("fk_a_u");
        });

        modelBuilder.Entity<CommentApplication>(entity =>
        {
            entity.HasKey(e => e.IdComment).HasName("PRIMARY");

            entity.ToTable("comment_application");

            entity.HasIndex(e => e.IdApplication, "fk_c_a");

            entity.HasIndex(e => e.IdUser, "fk_c_u");

            entity.Property(e => e.IdComment).HasColumnName("ID_comment");
            entity.Property(e => e.DateWriting).HasColumnName("date_writing");
            entity.Property(e => e.IdApplication).HasColumnName("ID_application");
            entity.Property(e => e.IdUser).HasColumnName("ID_user");
            entity.Property(e => e.TextComment)
                .HasColumnType("text")
                .HasColumnName("text_comment");

            entity.HasOne(d => d.IdApplicationNavigation).WithMany(p => p.CommentApplications)
                .HasForeignKey(d => d.IdApplication)
                .HasConstraintName("fk_c_a");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.CommentApplications)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("fk_c_u");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.IdEquipment).HasName("PRIMARY");

            entity.ToTable("equipment");

            entity.Property(e => e.IdEquipment).HasColumnName("ID_equipment");
            entity.Property(e => e.NameEquipment)
                .HasMaxLength(100)
                .HasColumnName("name_equipment");
        });

        modelBuilder.Entity<Malfunction>(entity =>
        {
            entity.HasKey(e => e.IdMalfunction).HasName("PRIMARY");

            entity.ToTable("malfunction");

            entity.Property(e => e.IdMalfunction).HasColumnName("ID_malfunction");
            entity.Property(e => e.NameMalfunction)
                .HasColumnType("text")
                .HasColumnName("name_malfunction");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.IdReport).HasName("PRIMARY");

            entity.ToTable("report");

            entity.HasIndex(e => e.IdApplication, "fk_r_a");

            entity.Property(e => e.IdReport).HasColumnName("ID_report");
            entity.Property(e => e.AssistanceProvided)
                .HasColumnType("text")
                .HasColumnName("assistance_provided");
            entity.Property(e => e.CauseMalfunction)
                .HasColumnType("text")
                .HasColumnName("cause_malfunction");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.IdApplication).HasColumnName("ID_application");
            entity.Property(e => e.LeadTime)
                .HasColumnType("time")
                .HasColumnName("lead_time");

            entity.HasOne(d => d.IdApplicationNavigation).WithMany(p => p.Reports)
                .HasForeignKey(d => d.IdApplication)
                .HasConstraintName("fk_r_a");
        });

        modelBuilder.Entity<RoleUser>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("PRIMARY");

            entity.ToTable("role_users");

            entity.Property(e => e.IdRole).HasColumnName("ID_role");
            entity.Property(e => e.NameRole)
                .HasMaxLength(50)
                .HasColumnName("name_role");
        });

        modelBuilder.Entity<Sparepart>(entity =>
        {
            entity.HasKey(e => new { e.IdSpareParts, e.IdApplication })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("spareparts");

            entity.HasIndex(e => e.IdApplication, "fk_sp_a");

            entity.Property(e => e.IdSpareParts)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_spareParts");
            entity.Property(e => e.IdApplication).HasColumnName("ID_application");
            entity.Property(e => e.CostSpareParts).HasColumnName("cost_spareParts");
            entity.Property(e => e.NameSpareParts)
                .HasMaxLength(100)
                .HasColumnName("name_spareParts");
            entity.Property(e => e.QuantitySpareParts).HasColumnName("quantity_spareParts");

            entity.HasOne(d => d.IdApplicationNavigation).WithMany(p => p.Spareparts)
                .HasForeignKey(d => d.IdApplication)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sp_a");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.IdRole, "fk_u_r");

            entity.Property(e => e.IdUser).HasColumnName("ID_user");
            entity.Property(e => e.IdRole).HasColumnName("ID_role");
            entity.Property(e => e.LoginUser)
                .HasMaxLength(50)
                .HasColumnName("login_user");
            entity.Property(e => e.NameUser)
                .HasMaxLength(50)
                .HasColumnName("name_user");
            entity.Property(e => e.PasswordUser)
                .HasMaxLength(50)
                .HasColumnName("password_user");
            entity.Property(e => e.PatronymicUser)
                .HasMaxLength(50)
                .HasColumnName("patronymic_user");
            entity.Property(e => e.SurnameUser)
                .HasMaxLength(50)
                .HasColumnName("surname_user");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("fk_u_r");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
