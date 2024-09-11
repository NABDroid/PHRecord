using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PHRecord.Models;

namespace PHRecord.Context;

public partial class PhrDbContext : DbContext
{
    public PhrDbContext()
    {
    }

    public PhrDbContext(DbContextOptions<PhrDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AreaMapping> AreaMappings { get; set; }

    public virtual DbSet<DoctorInfo> DoctorInfos { get; set; }

    public virtual DbSet<DoctorsVisitingHour> DoctorsVisitingHours { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<HistoryTitle> HistoryTitles { get; set; }

    public virtual DbSet<Hospital> Hospitals { get; set; }

    public virtual DbSet<LoginCred> LoginCreds { get; set; }

    public virtual DbSet<PatientHistory> PatientHistories { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-37G7U0T;Initial Catalog=PHR_DB;User ID=solution;Password=solution;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AreaMapping>(entity =>
        {
            entity.HasKey(e => e.AreaId);

            entity.ToTable("AreaMapping");

            entity.Property(e => e.AreaId).HasColumnName("areaID");
            entity.Property(e => e.AreaName).HasColumnName("areaName");
            entity.Property(e => e.AreaTypeId).HasColumnName("areaTypeID");
            entity.Property(e => e.CurrentPopulation).HasColumnName("currentPopulation");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.ParentId).HasColumnName("parentID");
        });

        modelBuilder.Entity<DoctorInfo>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_doctorInfo");

            entity.ToTable("DoctorInfo");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("userId");
            entity.Property(e => e.AchievedDegrees).HasColumnName("achievedDegrees");
            entity.Property(e => e.ChamberAddress).HasColumnName("chamberAddress");
            entity.Property(e => e.HospitalId).HasColumnName("hospitalId");
            entity.Property(e => e.Latitude)
                .HasColumnType("decimal(18, 10)")
                .HasColumnName("latitude");
            entity.Property(e => e.Longitude)
                .HasColumnType("decimal(18, 10)")
                .HasColumnName("longitude");
            entity.Property(e => e.RegistrationNo).HasColumnName("registrationNo");
            entity.Property(e => e.Universities).HasColumnName("universities");
            entity.Property(e => e.WorkTimes).HasColumnName("workTimes");
        });

        modelBuilder.Entity<DoctorsVisitingHour>(entity =>
        {
            entity.HasKey(e => e.MappingId);

            entity.ToTable("DoctorsVisitingHour");

            entity.Property(e => e.MappingId).HasColumnName("mappingId");
            entity.Property(e => e.DoctorId).HasColumnName("doctorId");
            entity.Property(e => e.EndTime).HasColumnName("endTime");
            entity.Property(e => e.HospitalId).HasColumnName("hospitalId");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.OffDays)
                .HasMaxLength(50)
                .HasColumnName("offDays");
            entity.Property(e => e.StartTime).HasColumnName("startTime");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.Property(e => e.DocumentId).HasColumnName("documentId");
            entity.Property(e => e.DocTypeId).HasColumnName("docTypeId");
            entity.Property(e => e.DocumentDescription).HasColumnName("documentDescription");
            entity.Property(e => e.DocumentTitle)
                .HasMaxLength(120)
                .HasColumnName("documentTitle");
            entity.Property(e => e.FileDate).HasColumnName("fileDate");
            entity.Property(e => e.FileType)
                .HasMaxLength(50)
                .HasColumnName("fileType");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.MainDocument).HasColumnName("mainDocument");
            entity.Property(e => e.UploadTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("uploadTime");
            entity.Property(e => e.UserId).HasColumnName("userId");
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.HasKey(e => e.DocTypeId);

            entity.ToTable("DocumentType");

            entity.Property(e => e.DocTypeId).HasColumnName("docTypeId");
            entity.Property(e => e.DocType)
                .HasMaxLength(50)
                .HasColumnName("docType");
        });

        modelBuilder.Entity<HistoryTitle>(entity =>
        {
            entity.HasKey(e => e.TitleId).HasName("PK_HistoryTitles");

            entity.ToTable("HistoryTitle");

            entity.Property(e => e.TitleId).HasColumnName("titleId");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Title)
                .HasMaxLength(120)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Hospital>(entity =>
        {
            entity.Property(e => e.HospitalId).HasColumnName("hospitalID");
            entity.Property(e => e.BookedSeat)
                .HasDefaultValue(0)
                .HasColumnName("bookedSeat");
            entity.Property(e => e.ContactNo).HasColumnName("contactNo");
            entity.Property(e => e.DistrictId).HasColumnName("districtID");
            entity.Property(e => e.DivisionId).HasColumnName("divisionID");
            entity.Property(e => e.HospitalAddress).HasColumnName("hospitalAddress");
            entity.Property(e => e.HospitalName).HasColumnName("hospitalName");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.NoOfSeat)
                .HasDefaultValue(0)
                .HasColumnName("noOfSeat");
            entity.Property(e => e.UnionId).HasColumnName("unionID");
        });

        modelBuilder.Entity<LoginCred>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_loginUser");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("userId");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LoginPassword).HasColumnName("loginPassword");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("userName");
        });

        modelBuilder.Entity<PatientHistory>(entity =>
        {
            entity.HasKey(e => e.HistoryId);

            entity.ToTable("PatientHistory");

            entity.Property(e => e.HistoryId).HasColumnName("historyId");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.IsTrue).HasColumnName("isTrue");
            entity.Property(e => e.Remarks)
                .HasMaxLength(120)
                .HasColumnName("remarks");
            entity.Property(e => e.TitleId).HasColumnName("titleId");
            entity.Property(e => e.UserId).HasColumnName("userId");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("UserInfo");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.BloodGroup)
                .HasMaxLength(50)
                .HasColumnName("bloodGroup");
            entity.Property(e => e.ContctNo)
                .HasMaxLength(50)
                .HasColumnName("contctNo");
            entity.Property(e => e.DateOfBirth).HasColumnName("dateOfBirth");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .HasColumnName("emailAddress");
            entity.Property(e => e.FatherName)
                .HasMaxLength(50)
                .HasColumnName("fatherName");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .HasColumnName("fullName");
            entity.Property(e => e.GenderId).HasColumnName("genderId");
            entity.Property(e => e.IdentificationNo).HasColumnName("identificationNo");
            entity.Property(e => e.IdentificationTypeId)
                .HasMaxLength(100)
                .HasColumnName("identificationTypeId");
            entity.Property(e => e.InactiveTime)
                .HasColumnType("datetime")
                .HasColumnName("inactiveTime");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.MotherName)
                .HasMaxLength(50)
                .HasColumnName("motherName");
            entity.Property(e => e.RegistrationTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("registrationTime");
            entity.Property(e => e.UserType).HasColumnName("userType");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.ToTable("UserType");

            entity.Property(e => e.UserTypeId).HasColumnName("userTypeId");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.UserTypeTitle)
                .HasMaxLength(50)
                .HasColumnName("userTypeTitle");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
