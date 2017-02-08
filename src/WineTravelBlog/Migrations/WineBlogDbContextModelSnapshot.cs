using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WineTravelBlog.Models;

namespace WineTravelBlog.Migrations
{
    [DbContext(typeof(WineBlogDbContext))]
    partial class WineBlogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WineTravelBlog.Models.Region", b =>
                {
                    b.Property<int>("RegionId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("AvgRainfall");

                    b.Property<string>("GrowingSeason");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.HasKey("RegionId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("WineTravelBlog.Models.Wine", b =>
                {
                    b.Property<int>("WineId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<string>("Comments");

                    b.Property<string>("Name");

                    b.Property<string>("Nose");

                    b.Property<int>("OverAllRating");

                    b.Property<string>("Pallete");

                    b.Property<float>("Price");

                    b.Property<int?>("RegionId");

                    b.Property<string>("Type");

                    b.Property<int>("WineryId");

                    b.HasKey("WineId");

                    b.HasIndex("RegionId");

                    b.HasIndex("WineryId");

                    b.ToTable("Wines");
                });

            modelBuilder.Entity("WineTravelBlog.Models.Winery", b =>
                {
                    b.Property<int>("WineryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AvgPrice");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<string>("PrimaryVarietals");

                    b.Property<int>("RegionId");

                    b.Property<string>("Style");

                    b.HasKey("WineryId");

                    b.HasIndex("RegionId");

                    b.ToTable("Wineries");
                });

            modelBuilder.Entity("WineTravelBlog.Models.Wine", b =>
                {
                    b.HasOne("WineTravelBlog.Models.Region", "Region")
                        .WithMany("Wines")
                        .HasForeignKey("RegionId");

                    b.HasOne("WineTravelBlog.Models.Winery", "Winery")
                        .WithMany("Wines")
                        .HasForeignKey("WineryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WineTravelBlog.Models.Winery", b =>
                {
                    b.HasOne("WineTravelBlog.Models.Region", "Region")
                        .WithMany("Wineries")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
