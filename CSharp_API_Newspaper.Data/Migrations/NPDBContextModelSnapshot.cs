﻿// <auto-generated />
using System;
using CSharp_API_Newspaper.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CSharp_API_Newspaper.Data.Migrations
{
    [DbContext(typeof(NPDBContext))]
    partial class NPDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("CSharp_API_Newspaper.Data.Data.Entities.NP_Admin", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Account")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime>("Birth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<bool>("Permission")
                        .HasColumnType("boolean");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Position")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Admin");

                    b.HasData(
                        new
                        {
                            ID = new Guid("fa8d69e6-fc66-4dc1-a2e2-0cdd9a712b6d"),
                            Account = "hoangtv",
                            Address = "Lộc Điền, Phú Lộc, TT Huế",
                            Birth = new DateTime(1999, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "vanhoangtran241199@gmail.com",
                            FullName = "Trần Văn Hoàng",
                            Password = "hoangtv123",
                            Permission = true,
                            Phone = "0963913111",
                            Position = "Nhân viên"
                        },
                        new
                        {
                            ID = new Guid("5d2542d5-52f4-4424-a8db-eedd987e8753"),
                            Account = "k_admin",
                            Address = "TT Huế",
                            Birth = new DateTime(2000, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "kadmin123@gmail.com",
                            FullName = "khách hàng",
                            Password = "kadmin123",
                            Permission = false,
                            Phone = "0963913112",
                            Position = "Nhân viên"
                        },
                        new
                        {
                            ID = new Guid("8896f4db-ea03-47aa-bc45-9384d3791646"),
                            Account = "admin",
                            Address = "Đà Nẵng",
                            Birth = new DateTime(2000, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@gmail.com",
                            FullName = "admin",
                            Password = "admin!00",
                            Permission = true,
                            Phone = "0963913113",
                            Position = "Tổng giám đốc"
                        });
                });

            modelBuilder.Entity("CSharp_API_Newspaper.Data.Data.Entities.NP_Category", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            ID = new Guid("e6ba1629-2f58-4528-8066-d3b34a4ee5a5"),
                            Description = "Gồm những tin tức hot nhất trong ngày",
                            Name = "Thời Sự"
                        },
                        new
                        {
                            ID = new Guid("4da58900-b069-4b3b-9831-8be609cca87f"),
                            Description = "Những tin tức nóng nhất trên thế giới",
                            Name = "Thế Giới"
                        },
                        new
                        {
                            ID = new Guid("7fb65791-a074-4695-8d86-ed893cfa2f80"),
                            Description = "Cập nhật tình hình kinh tế trong nước và ngoài nước",
                            Name = "Kinh Tế"
                        },
                        new
                        {
                            ID = new Guid("54decd2f-5d6d-41e1-bc5a-483f93927357"),
                            Description = "kỷ năng sống sức khỏe và đời sống tinh thần",
                            Name = "Đời Sống"
                        },
                        new
                        {
                            ID = new Guid("3dacdafa-f036-4906-95ea-bd94663a3c1e"),
                            Description = "thông tin xu hướng và phong cách sống của giới trẻ",
                            Name = "Giới trẻ"
                        });
                });

            modelBuilder.Entity("CSharp_API_Newspaper.Data.Data.Entities.NP_Comment", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("NP_MemberID")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("NP_PostID")
                        .HasColumnType("uuid");

                    b.HasKey("ID");

                    b.HasIndex("NP_MemberID");

                    b.HasIndex("NP_PostID");

                    b.ToTable("Comment");

                    b.HasData(
                        new
                        {
                            ID = new Guid("d2d3181c-43ea-4c8b-be36-51b6c483e1a2"),
                            Content = "quá xuất sắc",
                            Date = new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NP_MemberID = new Guid("e0cd6dd2-c907-450d-951f-39811874b619"),
                            NP_PostID = new Guid("9ed5e91c-9563-4b83-9bd5-5d9828523fd5")
                        },
                        new
                        {
                            ID = new Guid("f7551118-4382-4470-a93f-4260597fe383"),
                            Content = "tuyệt vời quá",
                            Date = new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NP_MemberID = new Guid("e0cd6dd2-c907-450d-951f-39811874b619"),
                            NP_PostID = new Guid("9ed5e91c-9563-4b83-9bd5-5d9828523fd5")
                        },
                        new
                        {
                            ID = new Guid("47ad8837-e461-4fda-9802-913f15edd483"),
                            Content = "nhất thế giới rồi",
                            Date = new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NP_MemberID = new Guid("2634f601-3b65-45a5-9ab5-141743931b60"),
                            NP_PostID = new Guid("9ed5e91c-9563-4b83-9bd5-5d9828523fd5")
                        },
                        new
                        {
                            ID = new Guid("81530e04-1e9d-4e2f-b475-174a6ce8864b"),
                            Content = "hết nước chấm",
                            Date = new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NP_MemberID = new Guid("2634f601-3b65-45a5-9ab5-141743931b60"),
                            NP_PostID = new Guid("a444644f-1b0b-4dfc-8d5d-d27dbdda2800")
                        },
                        new
                        {
                            ID = new Guid("2f6b27c4-9f72-4249-91eb-d685cdc8676d"),
                            Content = "bạn là tuyệt vời nhất",
                            Date = new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NP_MemberID = new Guid("2634f601-3b65-45a5-9ab5-141743931b60"),
                            NP_PostID = new Guid("a444644f-1b0b-4dfc-8d5d-d27dbdda2800")
                        },
                        new
                        {
                            ID = new Guid("be72860c-e97c-4c3a-bfb7-3acdce6ee679"),
                            Content = "tôi rất hài lòng",
                            Date = new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NP_MemberID = new Guid("74c1d59c-4ee5-4127-9ccf-37c878d3515d"),
                            NP_PostID = new Guid("cb939b09-c048-4a78-8eed-ad3988695e80")
                        });
                });

            modelBuilder.Entity("CSharp_API_Newspaper.Data.Data.Entities.NP_Interactive", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateSeen")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Like")
                        .HasColumnType("boolean");

                    b.Property<Guid>("MenberID")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("NP_AdminID")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("NP_MemberID")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("NP_PostID")
                        .HasColumnType("uuid");

                    b.Property<long>("NumberShare")
                        .HasColumnType("bigint");

                    b.Property<long>("Numberseen")
                        .HasColumnType("bigint");

                    b.Property<Guid>("PostID")
                        .HasColumnType("uuid");

                    b.Property<int>("Star")
                        .HasColumnType("integer");

                    b.Property<bool>("StatusSeen")
                        .HasColumnType("boolean");

                    b.HasKey("ID");

                    b.HasIndex("NP_AdminID");

                    b.HasIndex("NP_MemberID");

                    b.HasIndex("NP_PostID");

                    b.ToTable("Interactive");
                });

            modelBuilder.Entity("CSharp_API_Newspaper.Data.Data.Entities.NP_Member", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Account")
                        .HasColumnType("text");

                    b.Property<string>("Aliases")
                        .HasColumnType("text");

                    b.Property<DateTime>("Birth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<Guid?>("NP_AdminID")
                        .HasColumnType("uuid");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<bool>("Permission")
                        .HasColumnType("boolean");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("NP_AdminID");

                    b.ToTable("Member");

                    b.HasData(
                        new
                        {
                            ID = new Guid("e0cd6dd2-c907-450d-951f-39811874b619"),
                            Account = "hoangtv",
                            Aliases = "HoangTV",
                            Birth = new DateTime(1999, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "vanhoangtran241199@gmail.com",
                            FirstName = "Văn Hoàng",
                            LastName = "Trần",
                            NP_AdminID = new Guid("fa8d69e6-fc66-4dc1-a2e2-0cdd9a712b6d"),
                            Password = "hoangtv123",
                            Permission = true,
                            Phone = "0961523111"
                        },
                        new
                        {
                            ID = new Guid("74c1d59c-4ee5-4127-9ccf-37c878d3515d"),
                            Account = "kuser",
                            Aliases = "kuser",
                            Birth = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "",
                            FirstName = "user",
                            LastName = "K",
                            NP_AdminID = new Guid("fa8d69e6-fc66-4dc1-a2e2-0cdd9a712b6d"),
                            Password = "kuser123",
                            Permission = false,
                            Phone = "0961523112"
                        },
                        new
                        {
                            ID = new Guid("2634f601-3b65-45a5-9ab5-141743931b60"),
                            Account = "asuer",
                            Aliases = "Auser",
                            Birth = new DateTime(2002, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "",
                            FirstName = "user",
                            LastName = "A",
                            NP_AdminID = new Guid("8896f4db-ea03-47aa-bc45-9384d3791646"),
                            Password = "auser123",
                            Permission = true,
                            Phone = "0961523113"
                        });
                });

            modelBuilder.Entity("CSharp_API_Newspaper.Data.Data.Entities.NP_Post", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Link")
                        .HasColumnType("text");

                    b.Property<Guid?>("NP_AdminID")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("NP_CategoryID")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("NP_MemberID")
                        .HasColumnType("uuid");

                    b.Property<bool>("Permission")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("NP_AdminID");

                    b.HasIndex("NP_CategoryID");

                    b.HasIndex("NP_MemberID");

                    b.ToTable("Post");

                    b.HasData(
                        new
                        {
                            ID = new Guid("9ed5e91c-9563-4b83-9bd5-5d9828523fd5"),
                            Content = "",
                            Date = new DateTime(2022, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Link = "",
                            NP_AdminID = new Guid("fa8d69e6-fc66-4dc1-a2e2-0cdd9a712b6d"),
                            NP_CategoryID = new Guid("e6ba1629-2f58-4528-8066-d3b34a4ee5a5"),
                            NP_MemberID = new Guid("e0cd6dd2-c907-450d-951f-39811874b619"),
                            Permission = true,
                            Title = "tin thời sự trong nước"
                        },
                        new
                        {
                            ID = new Guid("a444644f-1b0b-4dfc-8d5d-d27dbdda2800"),
                            Content = "",
                            Date = new DateTime(2022, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Link = "",
                            NP_AdminID = new Guid("fa8d69e6-fc66-4dc1-a2e2-0cdd9a712b6d"),
                            NP_CategoryID = new Guid("e6ba1629-2f58-4528-8066-d3b34a4ee5a5"),
                            NP_MemberID = new Guid("e0cd6dd2-c907-450d-951f-39811874b619"),
                            Permission = true,
                            Title = "Thời sự và tôi"
                        },
                        new
                        {
                            ID = new Guid("cb939b09-c048-4a78-8eed-ad3988695e80"),
                            Content = "",
                            Date = new DateTime(2022, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Link = "",
                            NP_AdminID = new Guid("8896f4db-ea03-47aa-bc45-9384d3791646"),
                            NP_CategoryID = new Guid("e6ba1629-2f58-4528-8066-d3b34a4ee5a5"),
                            NP_MemberID = new Guid("2634f601-3b65-45a5-9ab5-141743931b60"),
                            Permission = true,
                            Title = "yêu thời sự"
                        },
                        new
                        {
                            ID = new Guid("b33e945d-ef96-47c5-b3a5-e28f68ae8ec1"),
                            Content = "",
                            Date = new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Link = "",
                            NP_AdminID = new Guid("8896f4db-ea03-47aa-bc45-9384d3791646"),
                            NP_CategoryID = new Guid("4da58900-b069-4b3b-9831-8be609cca87f"),
                            NP_MemberID = new Guid("2634f601-3b65-45a5-9ab5-141743931b60"),
                            Permission = true,
                            Title = "thế giới muôn màu"
                        },
                        new
                        {
                            ID = new Guid("4a0a6417-bd1e-4225-b201-d2c0ebee0b93"),
                            Content = "",
                            Date = new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Link = "",
                            NP_AdminID = new Guid("8896f4db-ea03-47aa-bc45-9384d3791646"),
                            NP_CategoryID = new Guid("7fb65791-a074-4695-8d86-ed893cfa2f80"),
                            NP_MemberID = new Guid("2634f601-3b65-45a5-9ab5-141743931b60"),
                            Permission = true,
                            Title = "Kinh tế và sự phát triển chung"
                        });
                });

            modelBuilder.Entity("CSharp_API_Newspaper.Data.Data.Entities.NP_Comment", b =>
                {
                    b.HasOne("CSharp_API_Newspaper.Data.Data.Entities.NP_Member", "NP_Members")
                        .WithMany("NP_Comments")
                        .HasForeignKey("NP_MemberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSharp_API_Newspaper.Data.Data.Entities.NP_Post", "NP_Posts")
                        .WithMany("NP_Comments")
                        .HasForeignKey("NP_PostID");
                });

            modelBuilder.Entity("CSharp_API_Newspaper.Data.Data.Entities.NP_Interactive", b =>
                {
                    b.HasOne("CSharp_API_Newspaper.Data.Data.Entities.NP_Admin", null)
                        .WithMany("NP_Interactives")
                        .HasForeignKey("NP_AdminID");

                    b.HasOne("CSharp_API_Newspaper.Data.Data.Entities.NP_Member", "NP_Members")
                        .WithMany()
                        .HasForeignKey("NP_MemberID");

                    b.HasOne("CSharp_API_Newspaper.Data.Data.Entities.NP_Post", "NP_Posts")
                        .WithMany()
                        .HasForeignKey("NP_PostID");
                });

            modelBuilder.Entity("CSharp_API_Newspaper.Data.Data.Entities.NP_Member", b =>
                {
                    b.HasOne("CSharp_API_Newspaper.Data.Data.Entities.NP_Admin", "NP_Admins")
                        .WithMany("NP_Members")
                        .HasForeignKey("NP_AdminID");
                });

            modelBuilder.Entity("CSharp_API_Newspaper.Data.Data.Entities.NP_Post", b =>
                {
                    b.HasOne("CSharp_API_Newspaper.Data.Data.Entities.NP_Admin", "NP_Admins")
                        .WithMany("NP_Posts")
                        .HasForeignKey("NP_AdminID");

                    b.HasOne("CSharp_API_Newspaper.Data.Data.Entities.NP_Category", "NP_Categorys")
                        .WithMany("NP_Posts")
                        .HasForeignKey("NP_CategoryID");

                    b.HasOne("CSharp_API_Newspaper.Data.Data.Entities.NP_Member", "NP_Members")
                        .WithMany("NP_Posts")
                        .HasForeignKey("NP_MemberID");
                });
#pragma warning restore 612, 618
        }
    }
}
