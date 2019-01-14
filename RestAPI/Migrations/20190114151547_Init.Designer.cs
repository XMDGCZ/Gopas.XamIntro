﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestAPI.Database;

namespace RestAPI.Migrations
{
    [DbContext(typeof(ItemContext))]
    [Migration("20190114151547_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity("SharedModel.Entity.ASPItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ASPItems");
                });

            modelBuilder.Entity("SharedModel.ServiceStackFolderModel.SimpleDTO", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MyProperty");

                    b.HasKey("Id");

                    b.ToTable("SimpleDTOs");
                });
#pragma warning restore 612, 618
        }
    }
}
