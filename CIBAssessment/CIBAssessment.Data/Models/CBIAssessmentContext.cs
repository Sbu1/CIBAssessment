using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CIBAssessment.Data.Models
{
    public partial class CBIAssessmentContext : DbContext
    {
        public CBIAssessmentContext()
        {
        }

        public CBIAssessmentContext(DbContextOptions<CBIAssessmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Entry> Entry { get; set; }
        public virtual DbSet<Phonebook> Phonebook { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-0IGTCA8S\\SQLEXPRESS;Database=CBIAssessment;User Id=Phonebookuser; password=phone1; MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Entry>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhonebookId).HasColumnName("PhonebookID");

                entity.HasOne(d => d.Phonebook)
                    .WithMany(p => p.Entry)
                    .HasForeignKey(d => d.PhonebookId)
                    .HasConstraintName("FK__Entry__Phonebook__1273C1CD");
            });

            modelBuilder.Entity<Phonebook>(entity =>
            {
                entity.Property(e => e.PhonebookId).HasColumnName("PhonebookID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
