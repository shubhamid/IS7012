using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreCrud.Migrations
{
    public partial class AddDataAnnotationsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DestinationName",
                table: "Destination",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CityAgentCellPhone",
                table: "Destination",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CityAgentEmailAddress",
                table: "Destination",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CityInstagramProfile",
                table: "Destination",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Country",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityAgentCellPhone",
                table: "Destination");

            migrationBuilder.DropColumn(
                name: "CityAgentEmailAddress",
                table: "Destination");

            migrationBuilder.DropColumn(
                name: "CityInstagramProfile",
                table: "Destination");

            migrationBuilder.AlterColumn<string>(
                name: "DestinationName",
                table: "Destination",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Country",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }
    }
}
