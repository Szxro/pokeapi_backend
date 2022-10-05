﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(PokeContext))]
    [Migration("20221005134907_initTest3")]
    partial class initTest3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ModelDB.AbilitiesDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstAbility")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PokemonId")
                        .HasColumnType("int");

                    b.Property<string>("SecondAbilitiy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId");

                    b.ToTable("Abilities");
                });

            modelBuilder.Entity("ModelDB.PokemonDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Pokemons");
                });

            modelBuilder.Entity("ModelDB.SpriteDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PokemonId")
                        .HasColumnType("int");

                    b.Property<string>("UrlSprite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId")
                        .IsUnique();

                    b.ToTable("Sprites");
                });

            modelBuilder.Entity("ModelDB.StatsDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PokemonId")
                        .HasColumnType("int");

                    b.Property<string>("Stats")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId")
                        .IsUnique();

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("ModelDB.TypesDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PokemonId")
                        .HasColumnType("int");

                    b.Property<string>("Types")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId")
                        .IsUnique();

                    b.ToTable("Types");
                });

            modelBuilder.Entity("ModelDB.AbilitiesDB", b =>
                {
                    b.HasOne("ModelDB.PokemonDB", "Pokemon")
                        .WithMany("Abilities")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("ModelDB.SpriteDB", b =>
                {
                    b.HasOne("ModelDB.PokemonDB", "Pokemon")
                        .WithOne("PokeSprite")
                        .HasForeignKey("ModelDB.SpriteDB", "PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("ModelDB.StatsDB", b =>
                {
                    b.HasOne("ModelDB.PokemonDB", "Pokemon")
                        .WithOne("Stats")
                        .HasForeignKey("ModelDB.StatsDB", "PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("ModelDB.TypesDB", b =>
                {
                    b.HasOne("ModelDB.PokemonDB", "PokemonDB")
                        .WithOne("Types")
                        .HasForeignKey("ModelDB.TypesDB", "PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PokemonDB");
                });

            modelBuilder.Entity("ModelDB.PokemonDB", b =>
                {
                    b.Navigation("Abilities");

                    b.Navigation("PokeSprite")
                        .IsRequired();

                    b.Navigation("Stats")
                        .IsRequired();

                    b.Navigation("Types")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
