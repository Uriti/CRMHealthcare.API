using System;
using System.Collections.Generic;
using CRMHealthcare.Infrastructure.Data.Models;
using TaskEntity = CRMHealthcare.Infrastructure.Data.Models.Task;
using Microsoft.EntityFrameworkCore;

namespace CRMHealthcare.Infrastructure.Data;

public partial class CRMDbContext : DbContext
{
    public CRMDbContext()
    {
    }

    public CRMDbContext(DbContextOptions<CRMDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Interaction> Interactions { get; set; }

    public virtual DbSet<LeadSource> LeadSources { get; set; }

    public virtual DbSet<Opportunity> Opportunities { get; set; }

    public virtual DbSet<OpportunityStage> OpportunityStages { get; set; }

    public virtual DbSet<OpportunityType> OpportunityTypes { get; set; }

        public virtual DbSet<TaskEntity> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLExpress;Database=CRMHealthcareDb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK__Contacts__5C66259B950628C9");

            entity.HasIndex(e => e.MobileNumber, "UX_Contacts_MobileNumber").IsUnique();

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(20);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.MobileNumber).HasMaxLength(20);

            entity.HasOne(d => d.LeadSource).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.LeadSourceId)
                .HasConstraintName("FK_Contacts_LeadSources");
        });

        modelBuilder.Entity<Interaction>(entity =>
        {
            entity.HasKey(e => e.InteractionId).HasName("PK__Interact__922C0496733632C7");

            entity.HasIndex(e => e.OpportunityId, "IX_Interactions_OpportunityId");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.InteractionDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.InteractionType).HasMaxLength(50);
            entity.Property(e => e.Notes).HasMaxLength(1000);

            entity.HasOne(d => d.Opportunity).WithMany(p => p.Interactions)
                .HasForeignKey(d => d.OpportunityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Interactions_Opportunities");

            entity.HasOne(d => d.User).WithMany(p => p.Interactions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Interactions_Users");
        });

        modelBuilder.Entity<LeadSource>(entity =>
        {
            entity.HasKey(e => e.LeadSourceId).HasName("PK__LeadSour__9FB37DD32AD446CD");

            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.SourceName).HasMaxLength(100);
        });

        modelBuilder.Entity<Opportunity>(entity =>
        {
            entity.HasKey(e => e.OpportunityId).HasName("PK__Opportun__0034ED91631F5095");

            entity.HasIndex(e => e.AssignedUserId, "IX_Opportunities_AssignedUserId");

            entity.HasIndex(e => e.ContactId, "IX_Opportunities_ContactId");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.AssignedUser).WithMany(p => p.Opportunities)
                .HasForeignKey(d => d.AssignedUserId)
                .HasConstraintName("FK_Opportunities_Users");

            entity.HasOne(d => d.Contact).WithMany(p => p.Opportunities)
                .HasForeignKey(d => d.ContactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Opportunities_Contacts");

            entity.HasOne(d => d.OpportunityStage).WithMany(p => p.Opportunities)
                .HasForeignKey(d => d.OpportunityStageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Opportunities_OpportunityStages");

            entity.HasOne(d => d.OpportunityType).WithMany(p => p.Opportunities)
                .HasForeignKey(d => d.OpportunityTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Opportunities_OpportunityTypes");
        });

        modelBuilder.Entity<OpportunityStage>(entity =>
        {
            entity.HasKey(e => e.OpportunityStageId).HasName("PK__Opportun__786803BCF5D334DB");

            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.StageName).HasMaxLength(100);
        });

        modelBuilder.Entity<OpportunityType>(entity =>
        {
            entity.HasKey(e => e.OpportunityTypeId).HasName("PK__Opportun__148701B50F230E63");

            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.TypeName).HasMaxLength(100);
        });

        modelBuilder.Entity<TaskEntity>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__Tasks__7C6949B151BC9CA4");

            entity.HasIndex(e => new { e.AssignedUserId, e.DueDate }, "IX_Tasks_AssignedUserId_DueDate");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TaskDescription).HasMaxLength(500);
            entity.Property(e => e.TaskTitle).HasMaxLength(200);

            entity.HasOne(d => d.AssignedUser).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.AssignedUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tasks_Users");

            entity.HasOne(d => d.Interaction).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.InteractionId)
                .HasConstraintName("FK_Tasks_Interactions");

            entity.HasOne(d => d.Opportunity).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.OpportunityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tasks_Opportunities");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C06EB80DF");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.MobileNumber).HasMaxLength(20);
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
