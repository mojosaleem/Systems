using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManegmentSystems.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CapitalShare",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    amount = table.Column<decimal>(type: "money", nullable: false),
                    partner_ID = table.Column<int>(nullable: false),
                    PartnerId = table.Column<int>(nullable: true),
                    PartnerId1 = table.Column<string>(nullable: true),
                    dateADD = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapitalShare", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CapitalShare_partner_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "partner",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CapitalShare_AspNetUsers_PartnerId1",
                        column: x => x.PartnerId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CapitalShare_PartnerId",
                table: "CapitalShare",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_CapitalShare_PartnerId1",
                table: "CapitalShare",
                column: "PartnerId1");
        }
    }
}
