﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VeskoWeb.DataBase.Context;

namespace VeskoWeb.DataBase.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190423214735_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VeskoWeb.Domain.Models.TeamMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Facebook");

                    b.Property<string>("ImagePath");

                    b.Property<DateTime?>("InactivateDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Linkedin");

                    b.Property<string>("Name");

                    b.Property<string>("Role");

                    b.Property<string>("Twiter");

                    b.HasKey("Id");

                    b.ToTable("TeamMembers");
                });
#pragma warning restore 612, 618
        }
    }
}
