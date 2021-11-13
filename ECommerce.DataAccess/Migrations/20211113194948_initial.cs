using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.DataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "users",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TokenExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 11, 13, 22, 49, 47, 506, DateTimeKind.Local).AddTicks(9599)),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "users",
                columns: new[] { "Id", "Address", "CreatedDate", "CreatedUserId", "DateOfBirth", "Email", "FirstName", "Gender", "LastName", "Password", "PhoneNumber", "Token", "TokenExpireDate", "UpdatedDate", "UpdatedUserId", "UserName" },
                values: new object[] { 1, "İSTANBUL", new DateTime(2021, 11, 13, 22, 49, 47, 532, DateTimeKind.Local).AddTicks(9084), 1, new DateTime(1996, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "burak@gmail.com", "Burak", true, "Kural", "12345", null, null, null, null, null, "burakkural" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users",
                schema: "dbo");
        }
    }
}
