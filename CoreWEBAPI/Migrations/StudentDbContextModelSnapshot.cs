﻿// <auto-generated />
using CoreWEBAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreWEBAPI.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    partial class StudentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreWEBAPI.Models.Student", b =>
                {
                    b.Property<int>("StudentUniqueId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseName")
                        .IsRequired();

                    b.Property<string>("EducationYear")
                        .IsRequired();

                    b.Property<string>("StudentId")
                        .IsRequired();

                    b.Property<string>("StudentName")
                        .IsRequired();

                    b.Property<string>("University")
                        .IsRequired();

                    b.HasKey("StudentUniqueId");

                    b.ToTable("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
