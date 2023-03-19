using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.DataAccess.Context;

public partial class WeatherforecasttaskContext : DbContext
{
    public WeatherforecasttaskContext()
    {
    }

    public WeatherforecasttaskContext(DbContextOptions<WeatherforecasttaskContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DailyWeatherReport> DailyWeatherReports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DailyWeatherReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DailyWea__3214EC27075E74B8");

            entity.ToTable("DailyWeatherReport");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.City)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Cloudcover).HasColumnName("cloudcover");
            entity.Property(e => e.Country)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Datetime)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("datetime");
            entity.Property(e => e.DatetimeEpoch).HasColumnName("datetimeEpoch");
            entity.Property(e => e.Temp).HasColumnName("temp");
            entity.Property(e => e.Tempmax).HasColumnName("tempmax");
            entity.Property(e => e.Tempmin).HasColumnName("tempmin");
            entity.Property(e => e.Windspeed).HasColumnName("windspeed");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
