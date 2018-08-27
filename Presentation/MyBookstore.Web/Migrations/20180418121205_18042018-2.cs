using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyBookstore.Web.Migrations
{
    public partial class _180420182 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Books");

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "Books",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Books");

            migrationBuilder.AddColumn<byte[]>(
                name: "Cover",
                table: "Books",
                nullable: true);
        }
    }
}
