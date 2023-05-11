﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMGDb.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Platforms = table.Column<int>(type: "INTEGER", nullable: false),
                    Cast = table.Column<string>(type: "TEXT", nullable: false),
                    Crew = table.Column<string>(type: "TEXT", nullable: false),
                    Directors = table.Column<string>(type: "TEXT", nullable: false),
                    Writers = table.Column<string>(type: "TEXT", nullable: false),
                    Genre = table.Column<int>(type: "INTEGER", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Runtime = table.Column<string>(type: "TEXT", nullable: false),
                    Cast = table.Column<string>(type: "TEXT", nullable: false),
                    Crew = table.Column<string>(type: "TEXT", nullable: false),
                    Directors = table.Column<string>(type: "TEXT", nullable: false),
                    Writers = table.Column<string>(type: "TEXT", nullable: false),
                    Genre = table.Column<int>(type: "INTEGER", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
