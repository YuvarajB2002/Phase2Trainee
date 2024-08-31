using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HealthCareManagementSystem_EF_.Models;

public partial class HealthcareManagementSystemContext : DbContext
{
    public HealthcareManagementSystemContext()
    {
    }

    public HealthcareManagementSystemContext(DbContextOptions<HealthcareManagementSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<SignIn> SignIns { get; set; }

    public virtual DbSet<SignUp> SignUps { get; set; }

    public virtual DbSet<TreatmentPlan> TreatmentPlans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=PTSQLTESTDB01;database=HealthcareManagementSystem;integrated security=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__8ECDFCA26DC7BFDC");

            entity.Property(e => e.AppointmentId)
                .ValueGeneratedNever()
                .HasColumnName("AppointmentID");
            entity.Property(e => e.DoctorId).HasColumnName("DoctorID");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Appointme__Patie__4BAC3F29");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patients__970EC346B83D2CA4");

            entity.Property(e => e.PatientId)
                .ValueGeneratedNever()
                .HasColumnName("PatientID");
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.ContactInfo).HasMaxLength(50);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<SignIn>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SignIn");

            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<SignUp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SignUp");

            entity.Property(e => e.ConfirmPassword).HasMaxLength(50);
            entity.Property(e => e.EmailId).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<TreatmentPlan>(entity =>
        {
            entity.HasKey(e => e.TreatmentPlanId).HasName("PK__Treatmen__4E46B64CD75F40D2");

            entity.Property(e => e.TreatmentPlanId)
                .ValueGeneratedNever()
                .HasColumnName("TreatmentPlanID");
            entity.Property(e => e.DoctorId).HasColumnName("DoctorID");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.TreatmentDetails).HasMaxLength(50);

            entity.HasOne(d => d.Patient).WithMany(p => p.TreatmentPlans)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Treatment__Patie__5165187F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
