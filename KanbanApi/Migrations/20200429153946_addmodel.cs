using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KanbanApi.Migrations
{
    public partial class addmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_M_Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Team",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_Status_List",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_Status_List", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Board",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Team_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Board", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Board_TB_M_Team_Team_Id",
                        column: x => x.Team_Id,
                        principalTable: "TB_M_Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_User_Role",
                columns: table => new
                {
                    User_Id = table.Column<int>(nullable: false),
                    Role_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_User_Role", x => new { x.User_Id, x.Role_Id });
                    table.ForeignKey(
                        name: "FK_TB_T_User_Role_TB_M_Role_Role_Id",
                        column: x => x.Role_Id,
                        principalTable: "TB_M_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_T_User_Role_TB_M_User_User_Id",
                        column: x => x.User_Id,
                        principalTable: "TB_M_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_User_Team",
                columns: table => new
                {
                    User_Id = table.Column<int>(nullable: false),
                    Team_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_User_Team", x => new { x.User_Id, x.Team_Id });
                    table.ForeignKey(
                        name: "FK_TB_T_User_Team_TB_M_Team_Team_Id",
                        column: x => x.Team_Id,
                        principalTable: "TB_M_Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_T_User_Team_TB_M_User_User_Id",
                        column: x => x.User_Id,
                        principalTable: "TB_M_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_Card",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTimeOffset>(nullable: false),
                    FinishDate = table.Column<DateTimeOffset>(nullable: false),
                    StatusList_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_Card", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_T_Card_TB_T_Status_List_StatusList_Id",
                        column: x => x.StatusList_Id,
                        principalTable: "TB_T_Status_List",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_Board_Card",
                columns: table => new
                {
                    Board_Id = table.Column<int>(nullable: false),
                    Card_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_Board_Card", x => new { x.Board_Id, x.Card_Id });
                    table.ForeignKey(
                        name: "FK_TB_T_Board_Card_TB_M_Board_Board_Id",
                        column: x => x.Board_Id,
                        principalTable: "TB_M_Board",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_T_Board_Card_TB_T_Card_Card_Id",
                        column: x => x.Card_Id,
                        principalTable: "TB_T_Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Board_Team_Id",
                table: "TB_M_Board",
                column: "Team_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_Board_Card_Card_Id",
                table: "TB_T_Board_Card",
                column: "Card_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_Card_StatusList_Id",
                table: "TB_T_Card",
                column: "StatusList_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_User_Role_Role_Id",
                table: "TB_T_User_Role",
                column: "Role_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_User_Team_Team_Id",
                table: "TB_T_User_Team",
                column: "Team_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_T_Board_Card");

            migrationBuilder.DropTable(
                name: "TB_T_User_Role");

            migrationBuilder.DropTable(
                name: "TB_T_User_Team");

            migrationBuilder.DropTable(
                name: "TB_M_Board");

            migrationBuilder.DropTable(
                name: "TB_T_Card");

            migrationBuilder.DropTable(
                name: "TB_M_Role");

            migrationBuilder.DropTable(
                name: "TB_M_User");

            migrationBuilder.DropTable(
                name: "TB_M_Team");

            migrationBuilder.DropTable(
                name: "TB_T_Status_List");
        }
    }
}
