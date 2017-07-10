using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using webapp;

namespace lesson10.Migrations
{
    [DbContext(typeof(FamilyContext))]
    [Migration("20170522203259_Initialize")]
    partial class Initialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("webapp.Child", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("Email");

                    b.Property<int>("FamilyId");

                    b.Property<string>("FavoriteMovieId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.ToTable("Children");
                });

            modelBuilder.Entity("webapp.Family", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Dad");

                    b.Property<string>("Mom");

                    b.HasKey("Id");

                    b.ToTable("Families");
                });

            modelBuilder.Entity("webapp.Child", b =>
                {
                    b.HasOne("webapp.Family")
                        .WithMany("Children")
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
