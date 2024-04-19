using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PAT.MVC.Migrations
{
    public partial class RequestType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestType",
                table: "userCertificateRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestType",
                table: "userCertificateRequests");
        }
    }
}
