using System;
using System.Collections.Generic;
using db_ms.Models;
using Microsoft.EntityFrameworkCore;

namespace db_ms.DBContext;

public partial class PgnatsContext : DbContext
{
    public PgnatsContext()
    {
    }

    public PgnatsContext(DbContextOptions<PgnatsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=pgnats;Username=postgres;Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("car_pk");

            entity.ToTable("car");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Model)
                .HasMaxLength(15)
                .HasColumnName("model");
            entity.Property(e => e.PeopleId).HasColumnName("people_id");

            entity.HasOne(d => d.People).WithMany(p => p.Cars)
                .HasForeignKey(d => d.PeopleId)
                .HasConstraintName("people_fk");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("people_pk");

            entity.ToTable("people");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(15)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(15)
                .HasColumnName("last_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
