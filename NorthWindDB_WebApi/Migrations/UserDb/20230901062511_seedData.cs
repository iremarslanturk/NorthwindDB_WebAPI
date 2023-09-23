using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NorthWindDB_WebApi.Migrations.UserDb
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
            migrationBuilder.InsertData(
       table: "Users",
       columns: new[] { "Name", "Password" },
       values: new object[,]
       {
            { "User1", "Password1" },
            { "User2", "Password2" },
           // Daha fazla kullanıcı ekleyin
       });


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
