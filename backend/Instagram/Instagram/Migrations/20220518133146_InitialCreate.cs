﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Instagram.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    commentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(nullable: false),
                    username = table.Column<string>(nullable: true),
                    profile = table.Column<string>(nullable: true),
                    text = table.Column<string>(nullable: true),
                    postId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.commentId);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    likeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(nullable: false),
                    postId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.likeId);
                });

            migrationBuilder.CreateTable(
                name: "Savedpost",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(nullable: false),
                    postId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Savedpost", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    profile = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    link = table.Column<string>(nullable: true),
                    caption = table.Column<string>(nullable: true),
                    likeCount = table.Column<int>(nullable: false),
                    commentCount = table.Column<int>(nullable: false),
                    location = table.Column<string>(nullable: true),
                    commentStatus = table.Column<int>(nullable: false),
                    likeCountStatus = table.Column<int>(nullable: false),
                    timeStamp = table.Column<DateTime>(nullable: false),
                    userid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_userid",
                table: "Posts",
                column: "userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Savedpost");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
