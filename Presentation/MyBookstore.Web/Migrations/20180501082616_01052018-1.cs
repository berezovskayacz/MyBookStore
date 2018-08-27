using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyBookstore.Web.Migrations
{
    public partial class _010520181 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PictureName",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Books");

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureName",
                table: "Books",
                nullable: true);
        }
    }
}
