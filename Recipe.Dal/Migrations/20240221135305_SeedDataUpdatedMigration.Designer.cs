﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Recipe.Dal.DbContexts;

#nullable disable

namespace Recipe.Dal.Migrations
{
    [DbContext(typeof(RecipeDbContext))]
    [Migration("20240221135305_SeedDataUpdatedMigration")]
    partial class SeedDataUpdatedMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Recipe.Entities.AmountTypesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AmountTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = 0,
                            IsDeleted = false,
                            Name = "Cay Kasigi",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = 0,
                            IsDeleted = false,
                            Name = "Tatli Kasigi",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = 0,
                            IsDeleted = false,
                            Name = "Yemek Kasigi",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = 0,
                            IsDeleted = false,
                            Name = "Cay Bardagi",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = 0,
                            IsDeleted = false,
                            Name = "Su Bardagi",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = 0,
                            IsDeleted = false,
                            Name = "Gram",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = 0,
                            IsDeleted = false,
                            Name = "Adet",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = 0,
                            IsDeleted = false,
                            Name = "Dis",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 9,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = 0,
                            IsDeleted = false,
                            Name = "Demet",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 10,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = 0,
                            IsDeleted = false,
                            Name = "Paket",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 11,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = 0,
                            IsDeleted = false,
                            Name = "Litre",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 12,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = 0,
                            IsDeleted = false,
                            Name = "ml",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 0
                        });
                });

            modelBuilder.Entity("Recipe.Entities.CategoriesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = 0,
                            Description = "Sütlaç, revani, irmik helvası, muhallebi, tiramisu, kalburabastı, trileçe... Sütlüsü şerbetlisi, fırında kızaranı, ocakta pişeni derken liste uzar da gider.",
                            ImageUrl = "https://localhost:7056/Images/842f340a-df95-4056-a69d-e3c52b018e80.jpg",
                            IsDeleted = false,
                            Name = "Tatli",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = 0,
                            Description = "Hem doyuruculuğu hem de lezzetiyle sofraların vazgeçilmezi olan çorbalar, hemen hemen her öğünde damaklarımızı şenlendiriyor.",
                            ImageUrl = "https://localhost:7056/Images/22e74683-6324-405e-b56c-708f6daa1a2e.jpg",
                            IsDeleted = false,
                            Name = "Corba",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = 0,
                            Description = "Mutfakta tecrübeniz olmasa da hiç vakit kaybetmeden, kolaylıkla hazırlayabileceğiniz en lezzetli tavuk yemekleri tarifleri sofralarınızda! ",
                            ImageUrl = "https://localhost:7056/Images/72af10ba-47ff-47a6-b5a0-b7b649963450.jpg",
                            IsDeleted = false,
                            Name = "Tavuk",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = 0,
                            Description = "Hazırladığınız et yemeklerin herkesin beğenisini kazanması için sayfalarımıza göz atmanın tam zamanı! Evde kebap yapımı gibi zorlu yemekleri yapmanın kolay ve pratik yollarını kim öğrenmek istemez?",
                            ImageUrl = "https://localhost:7056/Images/55f13044-d2e4-40c8-a98e-ec97c0072c05.jpg",
                            IsDeleted = false,
                            Name = "Et",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = 0,
                            Description = "Türk mutfağının vazgeçilmez yemekleri arasında olan pilavın yapımı, birkaç püf noktayla oldukça kolaylaşır.",
                            ImageUrl = "https://localhost:7056/Images/91a1f4cc-8023-430c-9731-e6c8a58dcf6d.jpg",
                            IsDeleted = false,
                            Name = "Pilav",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = 0,
                            Description = "Oldukça kolay ve pratik bir şekilde hazırlanan makarnalar, mutfaktaki kurtarıcınız oluyor.",
                            ImageUrl = "https://localhost:7056/Images/05f58fef-a481-4875-8d9c-99b4bac3c84f.jpg",
                            IsDeleted = false,
                            Name = "Makarna",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = 0,
                            Description = "Her yemeğin yanına yakışan, sofralarınıza renk katan, damaklarda muhteşem lezzetler bırakan salata tarifleri, sadece bir tık kadar yakınınızda. ",
                            ImageUrl = "https://localhost:7056/Images/cad8a1d6-4033-4f65-bd37-4a0c5d9e16d1.jpg",
                            IsDeleted = false,
                            Name = "Salata",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = 0,
                            Description = "Balık ile ilgili farklı lezzetler arayanlar, birbirinden pratik balık tarifleri ile sofralarına ayrı bir tat katabilir.",
                            ImageUrl = "https://localhost:7056/Images/af4d177c-494e-4955-9252-0719026d9cdd.jpg",
                            IsDeleted = false,
                            Name = "Balik",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 9,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = 0,
                            Description = "Çeşit çeşit malzemelerle hazırlayabileceğiniz onlarca sulu yemek tarifi keşfetmeye hazır mısınız? ",
                            ImageUrl = "https://localhost:7056/Images/fcd6b7bd-a184-402e-8fa6-b96131308ad1.jpg",
                            IsDeleted = false,
                            Name = "Sulu Yemek",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 10,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = 0,
                            Description = "İster yumuşacık ister kıyır kıyır olsun, sıcacık bir poğaçaya kim hayır diyebilir ki? Görünümüyle iştah kabartan, lezzetiyle damak çatlatan börek tarifleri sizi bekliyor. zümlü, portakallı, cevizli, tarçınlı, havuçlu ve kakaolu gibi onlarca çeşidi bulunan kekler iştah kabartan kokularıyla bütün evi etkisi altına alacak.",
                            ImageUrl = "https://localhost:7056/Images/82f508e6-2823-408e-8e8f-2a2339dfd5fc.jpg",
                            IsDeleted = false,
                            Name = "Hamur Isi",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 0
                        });
                });

            modelBuilder.Entity("Recipe.Entities.RecipeDescriptionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RecipeDescriptions");
                });

            modelBuilder.Entity("Recipe.Entities.RecipeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("CookingTime")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfPeople")
                        .HasColumnType("int");

                    b.Property<int>("PreparetionTime")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("Recipe.Entities.RecipeIngredientsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("AmountTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RecipeIngredients");
                });

            modelBuilder.Entity("Recipe.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AccessTokenExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AuthToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RetryCount")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessTokenExpireDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AuthToken = "",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = 0,
                            Email = "ebc@gmail.com",
                            ImageUrl = "",
                            IsDeleted = false,
                            Password = "1234",
                            RetryCount = 0,
                            Role = "Admin",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 0,
                            UserName = "Admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
