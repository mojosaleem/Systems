using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ManegmentSystems.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CapitalShare",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    amount = table.Column<decimal>(type: "money", nullable: false),
                    AspNetUsersId = table.Column<string>(type: "nvarchar(450)", nullable: true),

                    dateADD = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapitalShare", x => x.ID);
                   
                    table.ForeignKey(
                        name: "FK_CapitalShare_AspNetUsersId",
                        column: x => x.AspNetUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CapitalShare_AspNetUsersId",
                table: "CapitalShare",
                column: "AspNetUsersId");
            


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
