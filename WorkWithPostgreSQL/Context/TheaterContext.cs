using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WorkWithPostgreSQL.Model.Tables;
using WorkWithPostgreSQL.Model.Views;

namespace WorkWithPostgreSQL.Context;

public partial class TheaterContext : DbContext
{
    public TheaterContext()
    {
    }

    public TheaterContext(DbContextOptions<TheaterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actor> Actors { get; set; }

    public virtual DbSet<CategoryOnShow> CategoryOnShows { get; set; }

    public virtual DbSet<CategoryShow> CategoryShows { get; set; }

    public virtual DbSet<Characteristic> Characteristics { get; set; }

    public virtual DbSet<CountOfShowByMonth> CountOfShowByMonths { get; set; }

    public virtual DbSet<Director> Directors { get; set; }

    public virtual DbSet<EduActor> EduActors { get; set; }

    public virtual DbSet<EduDirector> EduDirectors { get; set; }

    public virtual DbSet<ExpActor> ExpActors { get; set; }

    public virtual DbSet<ExpDirector> ExpDirectors { get; set; }

    public virtual DbSet<Month> Months { get; set; }

    public virtual DbSet<Place> Places { get; set; }

    public virtual DbSet<SecPric> SecPrics { get; set; }

    public virtual DbSet<Show> Shows { get; set; }

    public virtual DbSet<ShowActor> ShowActors { get; set; }

    public virtual DbSet<ShowDirector> ShowDirectors { get; set; }

    public virtual DbSet<StandartSelectShow> StandartSelectShows { get; set; }

    public virtual DbSet<Town> Towns { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Theater;Username=postgres;Password=000000");
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("tablefunc");

        modelBuilder.Entity<Actor>(entity =>
        {
            entity.HasKey(e => e.ActId).HasName("actor_pkey");

            entity.ToTable("actor");

            entity.Property(e => e.ActId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("act_id");
            entity.Property(e => e.ActDateBirth).HasColumnName("act_date_birth");
            entity.Property(e => e.ActF)
                .HasMaxLength(60)
                .IsFixedLength()
                .HasColumnName("act_f");
            entity.Property(e => e.ActI)
                .HasMaxLength(60)
                .IsFixedLength()
                .HasColumnName("act_i");
            entity.Property(e => e.ActIdTown)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("act_id_town");
            entity.Property(e => e.ActO)
                .HasMaxLength(60)
                .IsFixedLength()
                .HasColumnName("act_o");

            entity.HasOne(d => d.ActIdTownNavigation).WithMany(p => p.Actors)
                .HasForeignKey(d => d.ActIdTown)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("actor_act_id_town_fkey");
        });

        modelBuilder.Entity<CategoryOnShow>(entity =>
        {
            entity.HasKey(e => e.CatToShoId).HasName("category_on_show_pkey");

            entity.ToTable("category_on_show");

            entity.Property(e => e.CatToShoId)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasColumnName("cat_to_sho_id");
            entity.Property(e => e.CatToShoCatShoId)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasColumnName("cat_to_sho_cat_sho_id");
            entity.Property(e => e.CatToShoShoId)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasColumnName("cat_to_sho_sho_id");

            entity.HasOne(d => d.CatToShoCatSho).WithMany(p => p.CategoryOnShows)
                .HasForeignKey(d => d.CatToShoCatShoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("category_on_show_cat_to_sho_cat_sho_id_fkey");

            entity.HasOne(d => d.CatToShoSho).WithMany(p => p.CategoryOnShows)
                .HasForeignKey(d => d.CatToShoShoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("category_on_show_cat_to_sho_sho_id_fkey");
        });

        modelBuilder.Entity<CategoryShow>(entity =>
        {
            entity.HasKey(e => e.CatShoId).HasName("category_show_pkey");

            entity.ToTable("category_show");

            entity.Property(e => e.CatShoId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("cat_sho_id");
            entity.Property(e => e.CatShoName)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("cat_sho_name");
        });

        modelBuilder.Entity<Characteristic>(entity =>
        {
            entity.HasKey(e => e.ChaId).HasName("characteristics_pkey");

            entity.ToTable("characteristics");

            entity.Property(e => e.ChaId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("cha_id");
            entity.Property(e => e.ChaBod)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("cha_bod");
            entity.Property(e => e.ChaGen).HasColumnName("cha_gen");
            entity.Property(e => e.ChaIdAct)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("cha_id_act");
            entity.Property(e => e.ChaNat)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("cha_nat");
            entity.Property(e => e.ChaRac)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("cha_rac");

            entity.HasOne(d => d.ChaIdActNavigation).WithMany(p => p.Characteristics)
                .HasForeignKey(d => d.ChaIdAct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("characteristics_cha_id_act_fkey");
        });

        modelBuilder.Entity<CountOfShowByMonth>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("count_of_show_by_month");

            entity.Property(e => e.КоличествоПоМесяцам2024ГодаВМи).HasColumnName("Количество по месяцам 2024 года (в ми");
            entity.Property(e => e.Месяц)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Director>(entity =>
        {
            entity.HasKey(e => e.DirId).HasName("director_pkey");

            entity.ToTable("director");

            entity.Property(e => e.DirId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("dir_id");
            entity.Property(e => e.DirDateBirth).HasColumnName("dir_date_birth");
            entity.Property(e => e.DirF)
                .HasMaxLength(60)
                .IsFixedLength()
                .HasColumnName("dir_f");
            entity.Property(e => e.DirGen).HasColumnName("dir_gen");
            entity.Property(e => e.DirI)
                .HasMaxLength(60)
                .IsFixedLength()
                .HasColumnName("dir_i");
            entity.Property(e => e.DirIdTown)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("dir_id_town");
            entity.Property(e => e.DirO)
                .HasMaxLength(60)
                .IsFixedLength()
                .HasColumnName("dir_o");

            entity.HasOne(d => d.DirIdTownNavigation).WithMany(p => p.Directors)
                .HasForeignKey(d => d.DirIdTown)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("director_dir_id_town_fkey");
        });

        modelBuilder.Entity<EduActor>(entity =>
        {
            entity.HasKey(e => e.EduActId).HasName("edu_actor_pkey");

            entity.ToTable("edu_actor");

            entity.Property(e => e.EduActId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("edu_act_id");
            entity.Property(e => e.EduActDateEnd).HasColumnName("edu_act_date_end");
            entity.Property(e => e.EduActDateStart).HasColumnName("edu_act_date_start");
            entity.Property(e => e.EduActIdAct)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("edu_act_id_act");
            entity.Property(e => e.EduActName)
                .HasMaxLength(60)
                .IsFixedLength()
                .HasColumnName("edu_act_name");

            entity.HasOne(d => d.EduActIdActNavigation).WithMany(p => p.EduActors)
                .HasForeignKey(d => d.EduActIdAct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("edu_actor_edu_act_id_act_fkey");
        });

        modelBuilder.Entity<EduDirector>(entity =>
        {
            entity.HasKey(e => e.EduDirId).HasName("edu_director_pkey");

            entity.ToTable("edu_director");

            entity.Property(e => e.EduDirId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("edu_dir_id");
            entity.Property(e => e.EduDirDateEnd).HasColumnName("edu_dir_date_end");
            entity.Property(e => e.EduDirDateStart).HasColumnName("edu_dir_date_start");
            entity.Property(e => e.EduDirIdDir)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("edu_dir_id_dir");
            entity.Property(e => e.EduDirName)
                .HasMaxLength(60)
                .IsFixedLength()
                .HasColumnName("edu_dir_name");

            entity.HasOne(d => d.EduDirIdDirNavigation).WithMany(p => p.EduDirectors)
                .HasForeignKey(d => d.EduDirIdDir)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("edu_director_edu_dir_id_dir_fkey");
        });

        modelBuilder.Entity<ExpActor>(entity =>
        {
            entity.HasKey(e => e.ExpActId).HasName("exp_actor_pkey");

            entity.ToTable("exp_actor");

            entity.Property(e => e.ExpActId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("exp_act_id");
            entity.Property(e => e.ExpActDateEnd).HasColumnName("exp_act_date_end");
            entity.Property(e => e.ExpActDateStart).HasColumnName("exp_act_date_start");
            entity.Property(e => e.ExpActIdArt)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("exp_act_id_art");
            entity.Property(e => e.ExpActWor)
                .HasMaxLength(60)
                .IsFixedLength()
                .HasColumnName("exp_act_wor");

            entity.HasOne(d => d.ExpActIdArtNavigation).WithMany(p => p.ExpActors)
                .HasForeignKey(d => d.ExpActIdArt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("exp_actor_exp_act_id_art_fkey");
        });

        modelBuilder.Entity<ExpDirector>(entity =>
        {
            entity.HasKey(e => e.ExpDirId).HasName("exp_director_pkey");

            entity.ToTable("exp_director");

            entity.Property(e => e.ExpDirId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("exp_dir_id");
            entity.Property(e => e.ExpDirDateEnd).HasColumnName("exp_dir_date_end");
            entity.Property(e => e.ExpDirDateStart).HasColumnName("exp_dir_date_start");
            entity.Property(e => e.ExpDirIdDir)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("exp_dir_id_dir");
            entity.Property(e => e.ExpDirWor)
                .HasMaxLength(60)
                .IsFixedLength()
                .HasColumnName("exp_dir_wor");

            entity.HasOne(d => d.ExpDirIdDirNavigation).WithMany(p => p.ExpDirectors)
                .HasForeignKey(d => d.ExpDirIdDir)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("exp_director_exp_dir_id_dir_fkey");
        });

        modelBuilder.Entity<Month>(entity =>
        {
            entity.HasKey(e => e.MonId).HasName("months_pkey");

            entity.ToTable("months");

            entity.Property(e => e.MonId)
                .ValueGeneratedNever()
                .HasColumnName("mon_id");
            entity.Property(e => e.MonName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("mon_name");
        });

        modelBuilder.Entity<Place>(entity =>
        {
            entity.HasKey(e => e.PlaId).HasName("place_pkey");

            entity.ToTable("place");

            entity.HasIndex(e => e.PlaInn, "place_pla_inn_key").IsUnique();

            entity.Property(e => e.PlaId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("pla_id");
            entity.Property(e => e.PlaIdTow)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("pla_id_tow");
            entity.Property(e => e.PlaInn)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("pla_inn");
            entity.Property(e => e.PlaName)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("pla_name");

            entity.HasOne(d => d.PlaIdTowNavigation).WithMany(p => p.Places)
                .HasForeignKey(d => d.PlaIdTow)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("place_pla_id_tow_fkey");
        });

        modelBuilder.Entity<SecPric>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("sec_pric");

            entity.Property(e => e.ActF)
                .HasMaxLength(60)
                .IsFixedLength()
                .HasColumnName("act_f");
            entity.Property(e => e.SalaryBonus).HasColumnName("salary_bonus");
            entity.Property(e => e.ShoName)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("sho_name");
        });

        modelBuilder.Entity<Show>(entity =>
        {
            entity.HasKey(e => e.ShoId).HasName("show_pkey");

            entity.ToTable("show");

            entity.Property(e => e.ShoId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("sho_id");
            entity.Property(e => e.ShoDate).HasColumnName("sho_date");
            entity.Property(e => e.ShoIdPla)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("sho_id_pla");
            entity.Property(e => e.ShoLen)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("sho_len");
            entity.Property(e => e.ShoName)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("sho_name");

            entity.HasOne(d => d.ShoIdPlaNavigation).WithMany(p => p.Shows)
                .HasForeignKey(d => d.ShoIdPla)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("show_sho_id_pla_fkey");
        });

        modelBuilder.Entity<ShowActor>(entity =>
        {
            entity.HasKey(e => e.ShoactId).HasName("show_actor_pkey");

            entity.ToTable("show_actor");

            entity.Property(e => e.ShoactId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("shoact_id");
            entity.Property(e => e.ShoactAct)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("shoact_act");
            entity.Property(e => e.ShoactSho)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("shoact_sho");

            entity.HasOne(d => d.ShoactActNavigation).WithMany(p => p.ShowActors)
                .HasForeignKey(d => d.ShoactAct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("show_actor_shoact_act_fkey");

            entity.HasOne(d => d.ShoactShoNavigation).WithMany(p => p.ShowActors)
                .HasForeignKey(d => d.ShoactSho)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("show_actor_shoact_sho_fkey");
        });

        modelBuilder.Entity<ShowDirector>(entity =>
        {
            entity.HasKey(e => e.ShodirId).HasName("show_director_pkey");

            entity.ToTable("show_director");

            entity.Property(e => e.ShodirId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("shodir_id");
            entity.Property(e => e.ShodirDir)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("shodir_dir");
            entity.Property(e => e.ShodirSho)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("shodir_sho");

            entity.HasOne(d => d.ShodirDirNavigation).WithMany(p => p.ShowDirectors)
                .HasForeignKey(d => d.ShodirDir)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("show_director_shodir_dir_fkey");

            entity.HasOne(d => d.ShodirShoNavigation).WithMany(p => p.ShowDirectors)
                .HasForeignKey(d => d.ShodirSho)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("show_director_shodir_sho_fkey");
        });

        modelBuilder.Entity<StandartSelectShow>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("standart_select_show");

            entity.Property(e => e.Город)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.ДатаСпектакля).HasColumnName("Дата спектакля");
            entity.Property(e => e.ДлительностьСпектакля)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Длительность спектакля");
            entity.Property(e => e.НазваниеСпектакля)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("Название спектакля");
            entity.Property(e => e.Площадка)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Town>(entity =>
        {
            entity.HasKey(e => e.TwoId).HasName("town_pkey");

            entity.ToTable("town");

            entity.Property(e => e.TwoId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("two_id");
            entity.Property(e => e.TwoName)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("two_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
