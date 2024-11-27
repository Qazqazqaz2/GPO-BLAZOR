using System;
using System.Collections.Generic;
using DBAgent.Models;
using Microsoft.EntityFrameworkCore;

namespace DBAgent;

public partial class Gpo2Context : DbContext
{
    string _connectionPassword;
    public Gpo2Context(string connectionPassword)
    {
        _connectionPassword = connectionPassword;
    }

    public Gpo2Context(DbContextOptions<Gpo2Context> options, string connectionPassword)
        : base(options)
    {
        _connectionPassword = connectionPassword;
    }

    public virtual DbSet<AskForm> AskForms { get; set; }

    public virtual DbSet<PracticeType> PracticeTypes { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Cafedral> Cafedrals { get; set; }

    public virtual DbSet<Direction> Directions { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    {
        optionsBuilder.UseNpgsql($"Host=localhost;Port=5432;Database=GPO2;Username=postgres;Password={_connectionPassword}");
        optionsBuilder.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AskForm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Анкета_pkey");

            entity.ToTable("Анкета");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PracticeType).HasColumnName("Вид и тип практики");
            entity.Property(e => e.AskFormResposeble).HasColumnName("Ответственные за заполнение");
            entity.Property(e => e.ConsultantLeader).HasColumnName("Руководитель консультант");
            entity.Property(e => e.PracticeLeader).HasColumnName("Руководитель практики");

            entity.HasOne(d => d.PracticeTypeNavigation).WithMany(p => p.AskForms)
                .HasForeignKey(d => d.PracticeType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Вид_и_тип_практики_fkey");

            entity.HasOne(d => d.GroupNavigation).WithMany(p => p.AskFroms)
                .HasForeignKey(d => d.Group)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Группа_fkey");

            entity.HasOne(d => d.ContractNavigation).WithMany(p => p.AskForms)
                .HasForeignKey(d => d.Contract)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Договор_fkey");

            entity.HasOne(d => d.AskFormResposebleNavigation).WithMany(p => p.ResposebleAskFormNavigations)
                .HasForeignKey(d => d.AskFormResposeble)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Ответс_за_заполн_fkey");

            entity.HasOne(d => d.ConsultantLeaderNavigation).WithMany(p => p.ConsultantLeaderAskFormNavigations)
                .HasForeignKey(d => d.ConsultantLeader)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Рук_консул_fkey");

            entity.HasOne(d => d.PracticeLeaderNavigation).WithMany(p => p.PracticeLeaderAskFormNavigations)
                .HasForeignKey(d => d.PracticeLeader)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Рук_практ_fkey");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.AskForms)
                .HasForeignKey(d => d.Status)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Статус_fkey");

            entity.HasOne(d => d.StudentNavigation).WithMany(p => p.StudentAskFormNavigations)
                .HasForeignKey(d => d.Student)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Студент_fkey");
        });

        modelBuilder.Entity<PracticeType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Вид и тип практики_pkey");

            entity.ToTable("Вид и тип практики");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Groups).HasName("Группы_pkey");

            entity.ToTable("Группы");

            entity.Property(e => e.Year).HasColumnName("Год поступления");

            entity.HasOne(d => d.CafedralNavigation).WithMany(p => p.Groups)
                .HasForeignKey(d => d.Cafedral)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Кафедра_fkey");

            entity.HasOne(d => d.DirectionNavigation).WithMany(p => p.Groups)
                .HasForeignKey(d => d.Direction)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Направление_fkey");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Договор_pkey");

            entity.ToTable("Договор");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DateStart).HasColumnName("Дата начала практики");
            entity.Property(e => e.DateEnd).HasColumnName("Дата окончания практики");
            entity.Property(e => e.Equipment).HasColumnName("Материально-Техническое обеспече");
            entity.Property(e => e.Number).HasColumnName("Номер договора о практике");

            entity.HasOne(d => d.OrganizationNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.Organisation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("организация_fkey");
        });

        modelBuilder.Entity<Cafedral>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Кафедра_pkey");

            entity.ToTable("Кафедра");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.EncriptedName).HasColumnName("Название_краткое");
            entity.Property(e => e.FullName).HasColumnName("Название_полное");

            entity.HasOne(d => d.LeaderNavigation).WithMany(p => p.Cafedrals)
                .HasForeignKey(d => d.Leader)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Заведующий_fkey");
        });

        modelBuilder.Entity<Direction>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("Направление_pkey");

            entity.ToTable("Направление");

            entity.Property(e => e.Code).ValueGeneratedNever();

            entity.HasOne(d => d.LeaderNavigation).WithMany(p => p.Directions)
                .HasForeignKey(d => d.LeaderName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Руководитель_fkey");
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Организация_pkey");

            entity.ToTable("Организация");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.FactoryLeader).HasColumnName("Руководитель организации");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Пользователь_pkey");

            entity.ToTable("Пользователь");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");

            entity.HasMany(d => d.Organizations).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "ОрганизацияПользователь",
                    r => r.HasOne<Organization>().WithMany()
                        .HasForeignKey("Организация")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Организация_fkey"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("Пользователь")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Пользователь_fkey"),
                    j =>
                    {
                        j.HasKey("Пользователь", "Организация").HasName("Организация_пользователь_pkey");
                        j.ToTable("Организация_пользователь");
                    });
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Роль_pkey");

            entity.ToTable("Роль");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");

            entity.HasMany(d => d.Users).WithMany(p => p.Рольs)
                .UsingEntity<Dictionary<string, object>>(
                    "РольПользователь",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("Пользователь")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Пользователь"),
                    l => l.HasOne<Role>().WithMany()
                        .HasForeignKey("Роль")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Роль_fkey"),
                    j =>
                    {
                        j.HasKey("Роль", "Пользователь").HasName("Роль_пользователь_pkey");
                        j.ToTable("Роль_пользователь");
                    });
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Статус_pkey");

            entity.ToTable("Статус");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.StatusName).HasColumnName("Статус");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.User).HasName("Студент_pkey");

            entity.ToTable("Студент");

            entity.Property(e => e.User).ValueGeneratedNever();

            entity.HasOne(d => d.GroupNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.Group)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Группа");

            entity.HasOne(d => d.UserNavigation).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Пользователь_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
