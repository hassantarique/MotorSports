using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MotorSports.EFDAL;

public partial class MotorSports_2Context : DbContext
{
    public MotorSports_2Context()
    {
    }

    public MotorSports_2Context(DbContextOptions<MotorSports_2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventManager> EventManagers { get; set; }

    public virtual DbSet<EventParticipant> EventParticipants { get; set; }

    public virtual DbSet<EventSponsor> EventSponsors { get; set; }

    public virtual DbSet<Participant> Participants { get; set; }

    public virtual DbSet<RaceResult> RaceResults { get; set; }

    public virtual DbSet<RaceSchedule> RaceSchedules { get; set; }

    public virtual DbSet<RaceStanding> RaceStandings { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sponsor> Sponsors { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Venue> Venues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-T143SR9;Initial Catalog=MotorSportTestDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.EventDate).HasColumnType("datetime");
            entity.Property(e => e.EventName).HasMaxLength(50);
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.VenueId).HasColumnName("VenueID");

            entity.HasOne(d => d.Status).WithMany(p => p.Events)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_Events_Status");

            entity.HasOne(d => d.Venue).WithMany(p => p.Events)
                .HasForeignKey(d => d.VenueId)
                .HasConstraintName("FK_Events_Venues");
        });

        modelBuilder.Entity<EventManager>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_EventManager4");

            entity.ToTable("EventManager");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<EventParticipant>(entity =>
        {
            entity.Property(e => e.EventParticipantId)
                .ValueGeneratedNever()
                .HasColumnName("EventParticipantID");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");
            entity.Property(e => e.TeamId).HasColumnName("TeamID");

            entity.HasOne(d => d.Event).WithMany(p => p.EventParticipants)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventParticipants_Events");

            entity.HasOne(d => d.Participant).WithMany(p => p.EventParticipants)
                .HasForeignKey(d => d.ParticipantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventParticipants_Participants");

            entity.HasOne(d => d.Team).WithMany(p => p.EventParticipants)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("FK_EventParticipants_Teams");
        });

        modelBuilder.Entity<EventSponsor>(entity =>
        {
            entity.Property(e => e.EventSponsorId).HasColumnName("EventSponsorID");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.SponsorId).HasColumnName("SponsorID");

            entity.HasOne(d => d.Event).WithMany(p => p.EventSponsors)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventSponsors_Events");

            entity.HasOne(d => d.Sponsor).WithMany(p => p.EventSponsors)
                .HasForeignKey(d => d.SponsorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventSponsors_Sponsors");
        });

        modelBuilder.Entity<Participant>(entity =>
        {
            entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");
            entity.Property(e => e.LicenseNumber).HasMaxLength(50);
            entity.Property(e => e.TeamId).HasColumnName("TeamID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Team).WithMany(p => p.Participants)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("FK_Participants_Teams");

            entity.HasOne(d => d.User).WithMany(p => p.Participants)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Participants_Users");
        });

        modelBuilder.Entity<RaceResult>(entity =>
        {
            entity.Property(e => e.RaceResultId).HasColumnName("RaceResultID");
            entity.Property(e => e.EventParticipantId).HasColumnName("EventParticipantID");

            entity.HasOne(d => d.EventParticipant).WithMany(p => p.RaceResults)
                .HasForeignKey(d => d.EventParticipantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RaceResults_EventParticipants");
        });

        modelBuilder.Entity<RaceSchedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RaceSche__3214EC07CE2E0A04");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Location).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<RaceStanding>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RaceStan__3214EC078332C7CE");

            entity.Property(e => e.DriverName).HasMaxLength(100);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK_UserRoles");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<Sponsor>(entity =>
        {
            entity.Property(e => e.SponsorId).HasColumnName("SponsorID");
            entity.Property(e => e.ContactInfo).HasMaxLength(50);
            entity.Property(e => e.SponsorName).HasMaxLength(50);
            entity.Property(e => e.SponsorType).HasMaxLength(50);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.StatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.Property(e => e.TeamId).HasColumnName("TeamID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.TeamManagerId).HasColumnName("TeamManagerID");
            entity.Property(e => e.TeamName).HasMaxLength(50);

            entity.HasOne(d => d.TeamManager).WithMany(p => p.Teams)
                .HasForeignKey(d => d.TeamManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teams_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("EMail");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PaswordHash).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UserRoles_Roles"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UserRoles_Users"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK_UserRoles_1");
                        j.ToTable("UserRoles");
                        j.IndexerProperty<int>("UserId").HasColumnName("UserID");
                        j.IndexerProperty<int>("RoleId").HasColumnName("RoleID");
                    });
        });

        modelBuilder.Entity<Venue>(entity =>
        {
            entity.Property(e => e.VenueId).HasColumnName("VenueID");
            entity.Property(e => e.Location).HasMaxLength(50);
            entity.Property(e => e.TrackLength).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.VenueName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
