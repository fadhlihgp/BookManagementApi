using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookAuthorManagementApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    PublicationYear = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    AuthorId = table.Column<string>(type: "text", nullable: false),
                    PublisherId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Publisher_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Address", "BirthDate", "FullName", "IsDeleted", "Phone" },
                values: new object[,]
                {
                    { "722e680a-cd6d-4e76-9c26-7211d0715389", "Jalan Raya, Pasar Rebo, Jakarta Timur", new DateTime(1990, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rangga Duta", false, "08988838388" },
                    { "bf238d0a-386b-4728-a570-62f41b654548", "Jalan Palembang, Bekasi", new DateTime(1983, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arya Samudra", false, "08378723" },
                    { "d7238d0a-386b-4728-a570-62f41b654549", "Jalan Sudirman, Jakarta Selatan", new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Budi Santoso", false, "081234567890" },
                    { "e8238d0a-386b-4728-a570-62f41b654550", "Jalan Gatot Subroto, Bandung", new DateTime(1992, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dewi Putri", false, "087654321098" },
                    { "f9238d0a-386b-4728-a570-62f41b654551", "Jalan Ahmad Yani, Surabaya", new DateTime(1988, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eko Prasetyo", false, "089876543210" }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Address", "IsDeleted", "Name", "Phone" },
                values: new object[,]
                {
                    { "b6e5cb17-7758-4cdf-ac9f-5bf12cb4086e", "Jakarta Pusat", false, "Gramedia", "021-00309944" },
                    { "c8e5cb17-7758-4cdf-ac9f-5bf12cb4086f", "Jakarta Selatan", false, "Erlangga", "021-77309944" },
                    { "d9e5cb17-7758-4cdf-ac9f-5bf12cb4086g", "Bandung", false, "Mizan", "022-88309944" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { "4f2da188-4413-41f9-863a-4ce2f0b53bb4", "$2a$11$zSdBBZ89jkFefsFrZt5RlOCn292ZH0GGMUkaZYg2Z9uYN58simzgO", "Administrator", "admin2" },
                    { "fa5d042a-9fe5-4cac-867f-339e1cf7e183", "$2a$11$l3hfzLeFyzDpIu6jn6bJxOgZ5Nb8uJ3bptbotMUiP45xB9JKqqMHi", "Administrator", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "Description", "PublicationYear", "PublisherId", "Title" },
                values: new object[,]
                {
                    { "4ef010ae-5996-47c3-b367-7a6f93b2c605", "e8238d0a-386b-4728-a570-62f41b654550", "Buku tentang petualangan seorang penjaga langit yang menjadi saksi dari kejadian misterius di langit.", 2017, "c8e5cb17-7758-4cdf-ac9f-5bf12cb4086f", "Sang Penjaga Langit" },
                    { "5ef010ae-5996-47c3-b367-7a6f93b2c606", "e8238d0a-386b-4728-a570-62f41b654550", "Sebuah novel petualangan tentang ekspedisi ke pulau misterius yang menyimpan banyak rahasia.", 2019, "b6e5cb17-7758-4cdf-ac9f-5bf12cb4086e", "Rahasia Pulau Tersembunyi" },
                    { "6ef010ae-5996-47c3-b367-7a6f93b2c607", "f9238d0a-386b-4728-a570-62f41b654551", "Buku fiksi ilmiah yang mengisahkan kehidupan manusia di tahun 2150.", 2020, "d9e5cb17-7758-4cdf-ac9f-5bf12cb4086g", "Kisah dari Masa Depan" },
                    { "7ef010ae-5996-47c3-b367-7a6f93b2c608", "e8238d0a-386b-4728-a570-62f41b654550", "Memoar seorang penulis terkenal yang mengungkap perjalanan hidupnya dalam dunia literasi.", 2018, "c8e5cb17-7758-4cdf-ac9f-5bf12cb4086f", "Jejak Sang Penulis" },
                    { "8ef010ae-5996-47c3-b367-7a6f93b2c609", "f9238d0a-386b-4728-a570-62f41b654551", "Buku yang membahas berbagai aspek filosofis dalam kehidupan sehari-hari.", 2021, "b6e5cb17-7758-4cdf-ac9f-5bf12cb4086e", "Filosofi Kehidupan" },
                    { "9ef010ae-5996-47c3-b367-7a6f93b2c610", "e8238d0a-386b-4728-a570-62f41b654550", "Novel misteri yang mengungkap rahasia gelap sebuah kota tua yang terlupakan.", 2022, "d9e5cb17-7758-4cdf-ac9f-5bf12cb4086g", "Misteri Kota Tua" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_PublisherId",
                table: "Book",
                column: "PublisherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Publisher");
        }
    }
}
