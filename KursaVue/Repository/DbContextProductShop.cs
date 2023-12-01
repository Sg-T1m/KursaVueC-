using System;
using System.Collections.Generic;
using KursaVue.Model;
using Microsoft.EntityFrameworkCore;

namespace KursaVue.Repository;

public partial class DbContextProductShop : DbContext
{
    public DbContextProductShop()
    {
    }

    public DbContextProductShop(DbContextOptions<DbContextProductShop> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<PersonalDatum> PersonalData { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\perev\\source\\repos\\KursaVue\\KursaVue\\Db\\ProductShop.mdf;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC07817A3AC4");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NameCategories)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<PersonalDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3213E83F304BE84A");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.MidellName)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Sname)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("SName");
        

            entity.HasOne(d => d.User).WithMany(p => p.PersonalData)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_User_id_PresonalData");
    }
        );

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC0702CAAF92");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CategoriesId).HasColumnName("CategoriesID");
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.Img).HasColumnType("ntext");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.Categories).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoriesId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Product_Categories_id");

            entity.HasOne(d => d.User).WithMany(p => p.Products)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_User_id");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07F028B767");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Login)
                .HasMaxLength(15)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(15)
                .IsFixedLength();
            entity.Property(e => e.TypeUsers)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
