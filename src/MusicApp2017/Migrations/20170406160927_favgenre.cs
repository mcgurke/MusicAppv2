using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicApp2017.Migrations
{
    public partial class favgenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FavoriteGenreGenreID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FavoriteGenreGenreID",
                table: "AspNetUsers",
                column: "FavoriteGenreGenreID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Genres_FavoriteGenreGenreID",
                table: "AspNetUsers",
                column: "FavoriteGenreGenreID",
                principalTable: "Genres",
                principalColumn: "GenreID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Genres_FavoriteGenreGenreID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FavoriteGenreGenreID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FavoriteGenreGenreID",
                table: "AspNetUsers");
        }
    }
}
