using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharp_API_Newspaper.Data.Migrations
{
    public partial class Initail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Account = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Birth = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Permission = table.Column<bool>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Aliases = table.Column<string>(nullable: true),
                    Account = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Birth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Permission = table.Column<bool>(nullable: false),
                    NP_AdminID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Member_Admin_NP_AdminID",
                        column: x => x.NP_AdminID,
                        principalTable: "Admin",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Permission = table.Column<bool>(nullable: false),
                    NP_MemberID = table.Column<Guid>(nullable: true),
                    NP_CategoryID = table.Column<Guid>(nullable: true),
                    NP_AdminID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Post_Admin_NP_AdminID",
                        column: x => x.NP_AdminID,
                        principalTable: "Admin",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_Category_NP_CategoryID",
                        column: x => x.NP_CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_Member_NP_MemberID",
                        column: x => x.NP_MemberID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    NP_PostID = table.Column<Guid>(nullable: true),
                    NP_MemberID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comment_Member_NP_MemberID",
                        column: x => x.NP_MemberID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_Post_NP_PostID",
                        column: x => x.NP_PostID,
                        principalTable: "Post",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Interactive",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Like = table.Column<bool>(nullable: false),
                    NumberShare = table.Column<long>(nullable: false),
                    StatusSeen = table.Column<bool>(nullable: false),
                    DateSeen = table.Column<DateTime>(nullable: false),
                    Numberseen = table.Column<long>(nullable: false),
                    Star = table.Column<int>(nullable: false),
                    MenberID = table.Column<Guid>(nullable: false),
                    PostID = table.Column<Guid>(nullable: false),
                    NP_MemberID = table.Column<Guid>(nullable: true),
                    NP_PostID = table.Column<Guid>(nullable: true),
                    NP_AdminID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interactive", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Interactive_Admin_NP_AdminID",
                        column: x => x.NP_AdminID,
                        principalTable: "Admin",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Interactive_Member_NP_MemberID",
                        column: x => x.NP_MemberID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Interactive_Post_NP_PostID",
                        column: x => x.NP_PostID,
                        principalTable: "Post",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "ID", "Account", "Address", "Birth", "Email", "FullName", "Password", "Permission", "Phone", "Position" },
                values: new object[,]
                {
                    { new Guid("fa8d69e6-fc66-4dc1-a2e2-0cdd9a712b6d"), "hoangtv", "Lộc Điền, Phú Lộc, TT Huế", new DateTime(1999, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "vanhoangtran241199@gmail.com", "Trần Văn Hoàng", "hoangtv123", true, "0963913111", "Nhân viên" },
                    { new Guid("5d2542d5-52f4-4424-a8db-eedd987e8753"), "k_admin", "TT Huế", new DateTime(2000, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "kadmin123@gmail.com", "khách hàng", "kadmin123", false, "0963913112", "Nhân viên" },
                    { new Guid("8896f4db-ea03-47aa-bc45-9384d3791646"), "admin", "Đà Nẵng", new DateTime(2000, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", "admin", "admin!00", true, "0963913113", "Tổng giám đốc" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("e6ba1629-2f58-4528-8066-d3b34a4ee5a5"), "Gồm những tin tức hot nhất trong ngày", "Thời Sự" },
                    { new Guid("4da58900-b069-4b3b-9831-8be609cca87f"), "Những tin tức nóng nhất trên thế giới", "Thế Giới" },
                    { new Guid("7fb65791-a074-4695-8d86-ed893cfa2f80"), "Cập nhật tình hình kinh tế trong nước và ngoài nước", "Kinh Tế" },
                    { new Guid("54decd2f-5d6d-41e1-bc5a-483f93927357"), "kỷ năng sống sức khỏe và đời sống tinh thần", "Đời Sống" },
                    { new Guid("3dacdafa-f036-4906-95ea-bd94663a3c1e"), "thông tin xu hướng và phong cách sống của giới trẻ", "Giới trẻ" }
                });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "ID", "Account", "Aliases", "Birth", "Email", "FirstName", "LastName", "NP_AdminID", "Password", "Permission", "Phone" },
                values: new object[,]
                {
                    { new Guid("e0cd6dd2-c907-450d-951f-39811874b619"), "hoangtv", "HoangTV", new DateTime(1999, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "vanhoangtran241199@gmail.com", "Văn Hoàng", "Trần", new Guid("fa8d69e6-fc66-4dc1-a2e2-0cdd9a712b6d"), "hoangtv123", true, "0961523111" },
                    { new Guid("74c1d59c-4ee5-4127-9ccf-37c878d3515d"), "kuser", "kuser", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "user", "K", new Guid("fa8d69e6-fc66-4dc1-a2e2-0cdd9a712b6d"), "kuser123", false, "0961523112" },
                    { new Guid("2634f601-3b65-45a5-9ab5-141743931b60"), "asuer", "Auser", new DateTime(2002, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "user", "A", new Guid("8896f4db-ea03-47aa-bc45-9384d3791646"), "auser123", true, "0961523113" }
                });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "ID", "Content", "Date", "Link", "NP_AdminID", "NP_CategoryID", "NP_MemberID", "Permission", "Title" },
                values: new object[,]
                {
                    { new Guid("9ed5e91c-9563-4b83-9bd5-5d9828523fd5"), "", new DateTime(2022, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("fa8d69e6-fc66-4dc1-a2e2-0cdd9a712b6d"), new Guid("e6ba1629-2f58-4528-8066-d3b34a4ee5a5"), new Guid("e0cd6dd2-c907-450d-951f-39811874b619"), true, "tin thời sự trong nước" },
                    { new Guid("a444644f-1b0b-4dfc-8d5d-d27dbdda2800"), "", new DateTime(2022, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("fa8d69e6-fc66-4dc1-a2e2-0cdd9a712b6d"), new Guid("e6ba1629-2f58-4528-8066-d3b34a4ee5a5"), new Guid("e0cd6dd2-c907-450d-951f-39811874b619"), true, "Thời sự và tôi" },
                    { new Guid("cb939b09-c048-4a78-8eed-ad3988695e80"), "", new DateTime(2022, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("8896f4db-ea03-47aa-bc45-9384d3791646"), new Guid("e6ba1629-2f58-4528-8066-d3b34a4ee5a5"), new Guid("2634f601-3b65-45a5-9ab5-141743931b60"), true, "yêu thời sự" },
                    { new Guid("b33e945d-ef96-47c5-b3a5-e28f68ae8ec1"), "", new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("8896f4db-ea03-47aa-bc45-9384d3791646"), new Guid("4da58900-b069-4b3b-9831-8be609cca87f"), new Guid("2634f601-3b65-45a5-9ab5-141743931b60"), true, "thế giới muôn màu" },
                    { new Guid("4a0a6417-bd1e-4225-b201-d2c0ebee0b93"), "", new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("8896f4db-ea03-47aa-bc45-9384d3791646"), new Guid("7fb65791-a074-4695-8d86-ed893cfa2f80"), new Guid("2634f601-3b65-45a5-9ab5-141743931b60"), true, "Kinh tế và sự phát triển chung" }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "ID", "Content", "Date", "NP_MemberID", "NP_PostID" },
                values: new object[,]
                {
                    { new Guid("d2d3181c-43ea-4c8b-be36-51b6c483e1a2"), "quá xuất sắc", new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e0cd6dd2-c907-450d-951f-39811874b619"), new Guid("9ed5e91c-9563-4b83-9bd5-5d9828523fd5") },
                    { new Guid("f7551118-4382-4470-a93f-4260597fe383"), "tuyệt vời quá", new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e0cd6dd2-c907-450d-951f-39811874b619"), new Guid("9ed5e91c-9563-4b83-9bd5-5d9828523fd5") },
                    { new Guid("47ad8837-e461-4fda-9802-913f15edd483"), "nhất thế giới rồi", new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2634f601-3b65-45a5-9ab5-141743931b60"), new Guid("9ed5e91c-9563-4b83-9bd5-5d9828523fd5") },
                    { new Guid("81530e04-1e9d-4e2f-b475-174a6ce8864b"), "hết nước chấm", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2634f601-3b65-45a5-9ab5-141743931b60"), new Guid("a444644f-1b0b-4dfc-8d5d-d27dbdda2800") },
                    { new Guid("2f6b27c4-9f72-4249-91eb-d685cdc8676d"), "bạn là tuyệt vời nhất", new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2634f601-3b65-45a5-9ab5-141743931b60"), new Guid("a444644f-1b0b-4dfc-8d5d-d27dbdda2800") },
                    { new Guid("be72860c-e97c-4c3a-bfb7-3acdce6ee679"), "tôi rất hài lòng", new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("74c1d59c-4ee5-4127-9ccf-37c878d3515d"), new Guid("cb939b09-c048-4a78-8eed-ad3988695e80") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_NP_MemberID",
                table: "Comment",
                column: "NP_MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_NP_PostID",
                table: "Comment",
                column: "NP_PostID");

            migrationBuilder.CreateIndex(
                name: "IX_Interactive_NP_AdminID",
                table: "Interactive",
                column: "NP_AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Interactive_NP_MemberID",
                table: "Interactive",
                column: "NP_MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Interactive_NP_PostID",
                table: "Interactive",
                column: "NP_PostID");

            migrationBuilder.CreateIndex(
                name: "IX_Member_NP_AdminID",
                table: "Member",
                column: "NP_AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Post_NP_AdminID",
                table: "Post",
                column: "NP_AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Post_NP_CategoryID",
                table: "Post",
                column: "NP_CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Post_NP_MemberID",
                table: "Post",
                column: "NP_MemberID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Interactive");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Admin");
        }
    }
}
