using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyBookstore.Web.Migrations
{
    public partial class _2018042601 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Pictures");

            migrationBuilder.AddColumn<bool>(
                name: "Main",
                table: "Pictures",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Main",
                table: "Pictures");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Pictures",
                nullable: true);
        }
    }
}
