using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zip.Backend.Migrations
{
  public partial class InitialCreate : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "guest_book",
          columns: table => new
          {
            id = table.Column<Guid>(nullable: false),
            first_name = table.Column<string>(nullable: true),
            last_name = table.Column<string>(nullable: true),
            created = table.Column<DateTime>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("pk_guest_book", x => x.id);
          });
      migrationBuilder.CreateTable(
         name: "Dogs_RandomPictures",
         columns: table => new
         {
           id = table.Column<Guid>(nullable: false),
           filesizebytes = table.Column<long>(nullable: true),
           picture_url = table.Column<string>(nullable: true),
           created = table.Column<DateTime>(nullable: false)
         },
         constraints: table =>
         {
           table.PrimaryKey("pk_Random_Pictures_ID", x => x.id);
         });
    }
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(name: "guest_book");
      migrationBuilder.DropTable(name: "Dogs_RandomPictures");
    }
  }
}
