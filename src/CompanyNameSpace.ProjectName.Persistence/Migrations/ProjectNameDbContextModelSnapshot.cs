﻿// <auto-generated />
using System;
using CompanyNameSpace.ProjectName.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CompanyNameSpace.ProjectName.Persistence.Migrations
{
    [DbContext(typeof(ProjectNameDbContext))]
    partial class ProjectNameDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CompanyNameSpace.ProjectName.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Concerts"
                        },
                        new
                        {
                            CategoryId = new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Musicals"
                        },
                        new
                        {
                            CategoryId = new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Plays"
                        },
                        new
                        {
                            CategoryId = new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Conferences"
                        });
                });

            modelBuilder.Entity("CompanyNameSpace.ProjectName.Domain.Entities.EntityOne", b =>
                {
                    b.Property<int>("EntityOneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EntityOneId"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(38, 18)
                        .HasColumnType("decimal(38,18)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("EntityOneId");

                    b.ToTable("EntityOne");

                    b.HasData(
                        new
                        {
                            EntityOneId = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "First Item",
                            Name = "One",
                            Price = 1.23m,
                            TypeId = 1
                        },
                        new
                        {
                            EntityOneId = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Second Item",
                            Name = "Two",
                            Price = 1.24m,
                            TypeId = 2
                        },
                        new
                        {
                            EntityOneId = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Third Item",
                            Name = "Three",
                            Price = 1.25m,
                            TypeId = 2
                        },
                        new
                        {
                            EntityOneId = 4,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Fourth Item",
                            Name = "Four",
                            Price = 1.26m,
                            TypeId = 4
                        },
                        new
                        {
                            EntityOneId = 5,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Fifth Item",
                            Name = "Five",
                            Price = 1.27m,
                            TypeId = 4
                        },
                        new
                        {
                            EntityOneId = 6,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Sixth Item",
                            Name = "Six",
                            Price = 1.28m,
                            TypeId = 4
                        });
                });

            modelBuilder.Entity("CompanyNameSpace.ProjectName.Domain.Entities.Event", b =>
                {
                    b.Property<Guid>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<string>("Artist")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("EventId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            EventId = new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                            Artist = "Taylor Swift",
                            CategoryId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2025, 4, 17, 3, 8, 49, 152, DateTimeKind.Local).AddTicks(5739),
                            Description = "The Eras Tour is the ongoing sixth concert tour by the American singer-songwriter Taylor Swift. It commenced on March 17, 2023, in Glendale, Arizona, and is set to conclude on December 8, 2024, in Vancouver, consisting of 149 shows that span five continents.",
                            ImageUrl = "https://somewhere.org/images/TaylorSwift.jpg",
                            Name = "The Eras Tour",
                            Price = 65
                        },
                        new
                        {
                            EventId = new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                            Artist = "Chappell Roan",
                            CategoryId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2025, 7, 17, 3, 8, 49, 152, DateTimeKind.Local).AddTicks(5798),
                            Description = "Kayleigh Rose Amstutz, known professionally as Chappell Roan, is an American singer and songwriter. Working with collaborator Dan Nigro, the majority of her music is inspired by 1980s synth-pop and early 2000s pop hits.",
                            ImageUrl = "https://somewhere.org/images/chappellroan.jpg",
                            Name = "Chappell Roan Night",
                            Price = 85
                        },
                        new
                        {
                            EventId = new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                            Artist = "Daft Punk",
                            CategoryId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2025, 2, 17, 3, 8, 49, 152, DateTimeKind.Local).AddTicks(5813),
                            Description = "Daft Punk were a French electronic music duo formed in 1993 in Paris by Thomas Bangalter and Guy-Manuel de Homem-Christo. ",
                            ImageUrl = "https://somewhere.org/images/dj.jpg",
                            Name = "Clash of the Punks",
                            Price = 85
                        },
                        new
                        {
                            EventId = new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                            Artist = "Beyonce",
                            CategoryId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2025, 2, 17, 3, 8, 49, 152, DateTimeKind.Local).AddTicks(5827),
                            Description = "Beyoncé Giselle Knowles-Carter is an American singer, songwriter, and businesswoman. Nicknamed 'Queen Bey', she is regarded as an influential cultural figure of the 21st century.",
                            ImageUrl = "https://somewhere.org/images/Beyonce.jpg",
                            Name = "The Beyonce Tour",
                            Price = 25
                        },
                        new
                        {
                            EventId = new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                            Artist = "Pink Floyd",
                            CategoryId = new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2025, 8, 17, 3, 8, 49, 152, DateTimeKind.Local).AddTicks(5842),
                            Description = "Pink Floyd earliest shows were performed in 1965. They included Bob Klose as a member of the band, which at first played mainly RnB covers. Klose left the band after 1965.",
                            ImageUrl = "https://somewhere.org/images/conf.jpg",
                            Name = "The Dark Side of the Moon",
                            Price = 400
                        },
                        new
                        {
                            EventId = new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                            Artist = "The Rolling Stones",
                            CategoryId = new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2025, 6, 17, 3, 8, 49, 152, DateTimeKind.Local).AddTicks(5859),
                            Description = "Since forming in 1962, the English rock band the Rolling Stones have performed more than two thousand concerts around the world, becoming one of the world's most popular live music attractions in the process.",
                            ImageUrl = "https://somewhere.org/images/RollingStones.jpg",
                            Name = "Licks Tour",
                            Price = 135
                        });
                });

            modelBuilder.Entity("CompanyNameSpace.ProjectName.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("OrderPaid")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OrderPlaced")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderTotal")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderPaid = true,
                            OrderPlaced = new DateTime(2024, 10, 17, 3, 8, 49, 152, DateTimeKind.Local).AddTicks(5875),
                            OrderTotal = 400,
                            UserId = new Guid("a441eb40-9636-4ee6-be49-a66c5ec1330b")
                        },
                        new
                        {
                            OrderId = new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderPaid = true,
                            OrderPlaced = new DateTime(2024, 10, 17, 3, 8, 49, 152, DateTimeKind.Local).AddTicks(5891),
                            OrderTotal = 135,
                            UserId = new Guid("ac3cfaf5-34fd-4e4d-bc04-ad1083ddc340")
                        },
                        new
                        {
                            OrderId = new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderPaid = true,
                            OrderPlaced = new DateTime(2024, 10, 17, 3, 8, 49, 152, DateTimeKind.Local).AddTicks(5902),
                            OrderTotal = 85,
                            UserId = new Guid("d97a15fc-0d32-41c6-9ddf-62f0735c4c1c")
                        },
                        new
                        {
                            OrderId = new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderPaid = true,
                            OrderPlaced = new DateTime(2024, 10, 17, 3, 8, 49, 152, DateTimeKind.Local).AddTicks(5914),
                            OrderTotal = 245,
                            UserId = new Guid("4ad901be-f447-46dd-bcf7-dbe401afa203")
                        },
                        new
                        {
                            OrderId = new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderPaid = true,
                            OrderPlaced = new DateTime(2024, 10, 17, 3, 8, 49, 152, DateTimeKind.Local).AddTicks(5925),
                            OrderTotal = 142,
                            UserId = new Guid("7aeb2c01-fe8e-4b84-a5ba-330bdf950f5c")
                        },
                        new
                        {
                            OrderId = new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderPaid = true,
                            OrderPlaced = new DateTime(2024, 10, 17, 3, 8, 49, 152, DateTimeKind.Local).AddTicks(5937),
                            OrderTotal = 40,
                            UserId = new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923")
                        },
                        new
                        {
                            OrderId = new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderPaid = true,
                            OrderPlaced = new DateTime(2024, 10, 17, 3, 8, 49, 152, DateTimeKind.Local).AddTicks(5949),
                            OrderTotal = 116,
                            UserId = new Guid("7aeb2c01-fe8e-4b84-a5ba-330bdf950f5c")
                        });
                });

            modelBuilder.Entity("CompanyNameSpace.ProjectName.Domain.Entities.Event", b =>
                {
                    b.HasOne("CompanyNameSpace.ProjectName.Domain.Entities.Category", "Category")
                        .WithMany("Events")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CompanyNameSpace.ProjectName.Domain.Entities.Category", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
