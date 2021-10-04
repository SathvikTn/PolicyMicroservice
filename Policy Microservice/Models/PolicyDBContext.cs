using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Policy_Microservice.Models
{
    public partial class PolicyDBContext : DbContext
    {
        public PolicyDBContext()
        {
        }

        public PolicyDBContext(DbContextOptions<PolicyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<Business> Businesses { get; set; }
        public virtual DbSet<BusinessMaster> BusinessMasters { get; set; }
        public virtual DbSet<Consumer> Consumers { get; set; }
        public virtual DbSet<ConsumerPolicy> ConsumerPolicies { get; set; }
        public virtual DbSet<PolicyMaster> PolicyMasters { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<PropertyMaster> PropertyMasters { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SATHZZ;Database=PolicyDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Agent>(entity =>
            {
                entity.ToTable("Agent");

                entity.Property(e => e.AgentName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Business>(entity =>
            {
                entity.ToTable("Business");

                entity.Property(e => e.BusinessName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BusinessType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.BusinessMaster)
                    .WithMany(p => p.Businesses)
                    .HasForeignKey(d => d.BusinessMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Business__Busine__1EA48E88");

                entity.HasOne(d => d.Consumer)
                    .WithMany(p => p.Businesses)
                    .HasForeignKey(d => d.ConsumerId)
                    .HasConstraintName("FK__Business__Consum__1F98B2C1");
            });

            modelBuilder.Entity<BusinessMaster>(entity =>
            {
                entity.ToTable("BusinessMaster");
            });

            modelBuilder.Entity<Consumer>(entity =>
            {
                entity.ToTable("Consumer");

                entity.Property(e => e.ConsumerName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PanNumber)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Agent)
                    .WithMany(p => p.Consumers)
                    .HasForeignKey(d => d.AgentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Consumer__AgentI__17F790F9");
            });

            modelBuilder.Entity<ConsumerPolicy>(entity =>
            {
                entity.HasKey(e => e.PolicyId)
                    .HasName("PK__Consumer__2E1339A44103AE3C");

                entity.ToTable("ConsumerPolicy");

                entity.Property(e => e.PolicyStatus)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.PolicyMaster)
                    .WithMany(p => p.ConsumerPolicies)
                    .HasForeignKey(d => d.PolicyMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ConsumerP__Polic__32AB8735");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.ConsumerPolicies)
                    .HasForeignKey(d => d.PropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ConsumerP__Prope__30C33EC3");

                entity.HasOne(d => d.Quote)
                    .WithMany(p => p.ConsumerPolicies)
                    .HasForeignKey(d => d.QuoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ConsumerP__Quote__31B762FC");
            });

            modelBuilder.Entity<PolicyMaster>(entity =>
            {
                entity.ToTable("PolicyMaster");

                entity.Property(e => e.AssuredSum).HasColumnType("decimal(10, 3)");

                entity.Property(e => e.BaseLocation)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ConsumerType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PolicyType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.ToTable("Property");

                entity.Property(e => e.BuildingType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.BusinessId)
                    .HasConstraintName("FK__Property__Busine__22751F6C");

                entity.HasOne(d => d.PropertyMaster)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.PropertyMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Property__Proper__236943A5");
            });

            modelBuilder.Entity<PropertyMaster>(entity =>
            {
                entity.ToTable("PropertyMaster");
            });

            modelBuilder.Entity<Quote>(entity =>
            {
                entity.ToTable("Quote");

                entity.Property(e => e.PropertyType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.QuoteValue).HasColumnType("decimal(8, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
