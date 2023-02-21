using CSharp_API_Newspaper.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TimekeeperAPI.Common.Utils;

namespace CSharp_API_Newspaper.Data.Data
{
    public class NPDBContext : DbContext
    {
        public NPDBContext(DbContextOptions<NPDBContext> options) : base(options) { }

        public DbSet<NP_Category> NP_Categories { get; set; }
        public DbSet<NP_Admin> NP_Admins { get; set; }
        public DbSet<NP_Member> NP_Members { get; set; }
        public DbSet<NP_Post> NP_Posts { get; set; }
        public DbSet<NP_Comment> NP_Comments { get; set; }
        public DbSet<NP_Interactive> NP_Interactives { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Category
            modelBuilder.Entity<NP_Category>().HasData(
                new NP_Category()
                {
                    ID = Guid.Parse("e6ba1629-2f58-4528-8066-d3b34a4ee5a5"),
                    Name = "Thời Sự",
                    Description = "Gồm những tin tức hot nhất trong ngày"
                },

                new NP_Category()
                {
                    ID = Guid.Parse("4da58900-b069-4b3b-9831-8be609cca87f"),
                    Name = "Thế Giới",
                    Description = "Những tin tức nóng nhất trên thế giới"
                },

                new NP_Category()
                {
                    ID = Guid.Parse("7fb65791-a074-4695-8d86-ed893cfa2f80"),
                    Name = "Kinh Tế",
                    Description = "Cập nhật tình hình kinh tế trong nước và ngoài nước"
                },

                new NP_Category()
                {
                    ID = Guid.Parse("54decd2f-5d6d-41e1-bc5a-483f93927357"),
                    Name = "Đời Sống",
                    Description = "kỷ năng sống sức khỏe và đời sống tinh thần"
                },
                
                new NP_Category()
                { 
                    ID = Guid.Parse("3dacdafa-f036-4906-95ea-bd94663a3c1e"),
                    Name = "Giới trẻ",
                    Description = "thông tin xu hướng và phong cách sống của giới trẻ"
                });
            #endregion Category 

            #region Admin
            modelBuilder.Entity<NP_Admin>().HasData(
                new NP_Admin()
                {
                    ID = Guid.Parse("fa8d69e6-fc66-4dc1-a2e2-0cdd9a712b6d"),
                    Account = "hoangtv",
                    Password = "hoangtv123",
                    FullName = "Trần Văn Hoàng",
                    Birth = new DateTime(1999, 11, 24),
                    Address = "Lộc Điền, Phú Lộc, TT Huế",
                    Position = "Nhân viên",
                    Permission = true,
                    Phone = "0963913111",
                    Email = "vanhoangtran241199@gmail.com"
                },

                new NP_Admin()
                {
                    ID = Guid.Parse("5d2542d5-52f4-4424-a8db-eedd987e8753"),
                    Account = "k_admin",
                    Password = "kadmin123",
                    FullName = "khách hàng",
                    Birth = new DateTime(2000, 01, 20),
                    Address = "TT Huế",
                    Position = "Nhân viên",
                    Permission = false,
                    Phone = "0963913112",
                    Email = "kadmin123@gmail.com"
                },

                new NP_Admin()
                {
                    ID = Guid.Parse("8896f4db-ea03-47aa-bc45-9384d3791646"),
                    Account = "admin",
                    Password = "admin!00",
                    FullName = "admin",
                    Birth = new DateTime(2000, 05, 21),
                    Address = "Đà Nẵng",
                    Position = "Tổng giám đốc",
                    Permission = true,
                    Phone = "0963913113",
                    Email = "admin@gmail.com"
                });
            #endregion Admin

            #region Member
            modelBuilder.Entity<NP_Member>().HasData(
                new NP_Member()
                {
                    ID = Guid.Parse("e0cd6dd2-c907-450d-951f-39811874b619"),
                    LastName = "Trần",
                    FirstName = "Văn Hoàng",
                    Aliases = "HoangTV",
                    Account = "hoangtv",
                    Password = "hoangtv123",
                    Birth = new DateTime(1999, 11, 24),
                    Email = "vanhoangtran241199@gmail.com",
                    Phone = "0961523111",
                    Permission = true,
                    NP_AdminID = Guid.Parse("fa8d69e6-fc66-4dc1-a2e2-0cdd9a712b6d")
                },

                new NP_Member()
                {
                    ID = Guid.Parse("74c1d59c-4ee5-4127-9ccf-37c878d3515d"),
                    LastName = "K",
                    FirstName = "user",
                    Aliases = "kuser",
                    Account = "kuser",
                    Password = "kuser123",
                    Birth = new DateTime(2000, 01, 01),
                    Email = "",
                    Phone = "0961523112",
                    Permission = false,
                    NP_AdminID = Guid.Parse("fa8d69e6-fc66-4dc1-a2e2-0cdd9a712b6d"),
                },

                new NP_Member() { 
                    ID = Guid.Parse("2634f601-3b65-45a5-9ab5-141743931b60"),
                    LastName = "A",
                    FirstName = "user",
                    Aliases = "Auser",
                    Account = "asuer",
                    Password = "auser123",
                    Birth = new DateTime(2002, 05, 01),
                    Email = "",
                    Phone = "0961523113",
                    Permission = true,
                    NP_AdminID = Guid.Parse("8896f4db-ea03-47aa-bc45-9384d3791646")
                });
            #endregion Member

            #region Post
            modelBuilder.Entity<NP_Post>().HasData(

                // hoàng
                new NP_Post()
                {
                    ID = Guid.Parse("9ed5e91c-9563-4b83-9bd5-5d9828523fd5"),
                    Title = "tin thời sự trong nước",
                    Content = "",
                    Link = "",
                    Date = new DateTime(2022, 08, 07),
                    Permission = true,
                    NP_AdminID = Guid.Parse("fa8d69e6-fc66-4dc1-a2e2-0cdd9a712b6d"),
                    NP_CategoryID = Guid.Parse("e6ba1629-2f58-4528-8066-d3b34a4ee5a5"),
                    NP_MemberID = Guid.Parse("e0cd6dd2-c907-450d-951f-39811874b619"),
                },

                // hoàng
                new NP_Post()
                {
                    ID = Guid.Parse("a444644f-1b0b-4dfc-8d5d-d27dbdda2800"),
                    Title = "Thời sự và tôi",
                    Content = "",
                    Link = "",
                    Date = new DateTime(2022, 10, 23),
                    Permission = true,
                    NP_AdminID = Guid.Parse("fa8d69e6-fc66-4dc1-a2e2-0cdd9a712b6d"),
                    NP_CategoryID = Guid.Parse("e6ba1629-2f58-4528-8066-d3b34a4ee5a5"),
                    NP_MemberID = Guid.Parse("e0cd6dd2-c907-450d-951f-39811874b619"),
                },

                // admin
                new NP_Post()
                {
                    ID = Guid.Parse("cb939b09-c048-4a78-8eed-ad3988695e80"),
                    Title = "yêu thời sự",
                    Content = "",
                    Link = "",
                    Date = new DateTime(2022, 05, 09),
                    Permission = true,
                    NP_AdminID = Guid.Parse("8896f4db-ea03-47aa-bc45-9384d3791646"),
                    NP_CategoryID = Guid.Parse("e6ba1629-2f58-4528-8066-d3b34a4ee5a5"),
                    NP_MemberID = Guid.Parse("2634f601-3b65-45a5-9ab5-141743931b60"),
                },

                // admin
                new NP_Post()
                {
                    ID = Guid.Parse("b33e945d-ef96-47c5-b3a5-e28f68ae8ec1"),
                    Title = "thế giới muôn màu",
                    Content = "",
                    Link = "",
                    Date = new DateTime(2022, 12, 12),
                    Permission = true,
                    NP_AdminID = Guid.Parse("8896f4db-ea03-47aa-bc45-9384d3791646"),
                    NP_CategoryID = Guid.Parse("4da58900-b069-4b3b-9831-8be609cca87f"),
                    NP_MemberID = Guid.Parse("2634f601-3b65-45a5-9ab5-141743931b60"),
                },

                // admin
                new NP_Post() { 
                    ID = Guid.Parse("4a0a6417-bd1e-4225-b201-d2c0ebee0b93"),
                    Title = "Kinh tế và sự phát triển chung",
                    Content = "",
                    Link = "",
                    Date = new DateTime(2022, 01, 12),
                    Permission = true,
                    NP_AdminID = Guid.Parse("8896f4db-ea03-47aa-bc45-9384d3791646"),
                    NP_CategoryID = Guid.Parse("7fb65791-a074-4695-8d86-ed893cfa2f80"),
                    NP_MemberID = Guid.Parse("2634f601-3b65-45a5-9ab5-141743931b60"),
                });
            #endregion Post

            #region Comment
            modelBuilder.Entity<NP_Comment>().HasData(
                new NP_Comment()
                {
                    ID = Guid.Parse("d2d3181c-43ea-4c8b-be36-51b6c483e1a2"),
                    Content = "quá xuất sắc",
                    Date = new DateTime(2023, 01, 12),
                    NP_PostID = Guid.Parse("9ed5e91c-9563-4b83-9bd5-5d9828523fd5"),
                    NP_MemberID = Guid.Parse("e0cd6dd2-c907-450d-951f-39811874b619")
                },

                new NP_Comment()
                {
                    ID = Guid.Parse("f7551118-4382-4470-a93f-4260597fe383"),
                    Content = "tuyệt vời quá",
                    Date = new DateTime(2023, 01, 12),
                    NP_PostID = Guid.Parse("9ed5e91c-9563-4b83-9bd5-5d9828523fd5"),
                    NP_MemberID = Guid.Parse("e0cd6dd2-c907-450d-951f-39811874b619")
                },

                new NP_Comment()
                {
                    ID = Guid.Parse("47ad8837-e461-4fda-9802-913f15edd483"),
                    Content = "nhất thế giới rồi",
                    Date = new DateTime(2023, 01, 11),
                    NP_PostID = Guid.Parse("9ed5e91c-9563-4b83-9bd5-5d9828523fd5"),
                    NP_MemberID = Guid.Parse("2634f601-3b65-45a5-9ab5-141743931b60")
                },

                new NP_Comment()
                {
                    ID = Guid.Parse("81530e04-1e9d-4e2f-b475-174a6ce8864b"),
                    Content = "hết nước chấm",
                    Date = new DateTime(2023, 01, 15),
                    NP_PostID = Guid.Parse("a444644f-1b0b-4dfc-8d5d-d27dbdda2800"),
                    NP_MemberID = Guid.Parse("2634f601-3b65-45a5-9ab5-141743931b60")
                },

                new NP_Comment()
                {
                    ID = Guid.Parse("2f6b27c4-9f72-4249-91eb-d685cdc8676d"),
                    Content = "bạn là tuyệt vời nhất",
                    Date = new DateTime(2022, 12, 12),
                    NP_PostID = Guid.Parse("a444644f-1b0b-4dfc-8d5d-d27dbdda2800"),
                    NP_MemberID = Guid.Parse("2634f601-3b65-45a5-9ab5-141743931b60")
                },


                new NP_Comment() { 
                    ID = Guid.Parse("be72860c-e97c-4c3a-bfb7-3acdce6ee679"),
                    Content = "tôi rất hài lòng",
                    Date = new DateTime(2023, 01, 12),
                    NP_PostID = Guid.Parse("cb939b09-c048-4a78-8eed-ad3988695e80"),
                    NP_MemberID = Guid.Parse("74c1d59c-4ee5-4127-9ccf-37c878d3515d")
                });
            #endregion Comment


            modelBuilder.Entity<NP_Interactive>();
            

            base.OnModelCreating(modelBuilder);
        }

    }
}
