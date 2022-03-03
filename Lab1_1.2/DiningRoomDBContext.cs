using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DiningRoomWebApplication
{
    public partial class DiningRoomDBContext : DbContext
    {
        public DiningRoomDBContext()
        {
        }

        public DiningRoomDBContext(DbContextOptions<DiningRoomDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dish> Dishes { get; set; } = null!;
        public virtual DbSet<DishInclude> DishIncludes { get; set; } = null!;
        public virtual DbSet<Ingredient> Ingredients { get; set; } = null!;
        public virtual DbSet<MenuInclude> MenuIncludes { get; set; } = null!;
        public virtual DbSet<Menue> Menues { get; set; } = null!;
        public virtual DbSet<Type> Types { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= DESKTOP-9KIPNP7\\SQLEXPRESS;\nDatabase=DiningRoomDB; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(10);

                entity.Property(e => e.Notes).HasMaxLength(10);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Dishes)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Dishes_Types");
            });

            modelBuilder.Entity<DishInclude>(entity =>
            {
                entity.HasOne(d => d.Dish)
                    .WithMany(p => p.DishIncludes)
                    .HasForeignKey(d => d.DishId)
                    .HasConstraintName("FK_DishIncludes_Dishes");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.DishIncludes)
                    .HasForeignKey(d => d.IngredientId)
                    .HasConstraintName("FK_DishIncludes_Ingredients");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(10);
            });

            modelBuilder.Entity<MenuInclude>(entity =>
            {
                entity.HasOne(d => d.Dish)
                    .WithMany(p => p.MenuIncludes)
                    .HasForeignKey(d => d.DishId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuIncludes_Dishes");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.MenuIncludes)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuIncludes_Menues");
            });

            modelBuilder.Entity<Menue>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(10);
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
