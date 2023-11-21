using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GlobalTeknoloji.Data.Assess.Migeration
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "tblMarketInfo",
                newName: "CoinPrice");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tblMarketInfo",
                newName: "CoinName");

            migrationBuilder.RenameColumn(
                name: "Label",
                table: "tblMarketInfo",
                newName: "CoinLabel");

            migrationBuilder.AddColumn<string>(
                name: "CoinDate",
                table: "tblMarketInfo",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CoinTime",
                table: "tblMarketInfo",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "tblUserInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserInfo", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblUserInfo");

            migrationBuilder.DropColumn(
                name: "CoinDate",
                table: "tblMarketInfo");

            migrationBuilder.DropColumn(
                name: "CoinTime",
                table: "tblMarketInfo");

            migrationBuilder.RenameColumn(
                name: "CoinPrice",
                table: "tblMarketInfo",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "CoinName",
                table: "tblMarketInfo",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CoinLabel",
                table: "tblMarketInfo",
                newName: "Label");
        }
    }
}
