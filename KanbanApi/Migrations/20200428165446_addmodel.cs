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
                name: "TB_M_Board",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(nullable: true),
                    DeleteDate = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Board", x => x.Id);
                });

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
                    Name = table.Column<string>(nullable: true),
                    Board_Id = table.Column<int>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(nullable: true),
                    DeleteDate = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_Status_List", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_T_Status_List_TB_M_Board_Board_Id",
                        column: x => x.Board_Id,
                        principalTable: "TB_M_Board",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_User_Team",
                columns: table => new
                {
                    User_Id = table.Column<int>(nullable: false),
                    Team_Id = table.Column<int>(nullable: false),
                    Board_Id = table.Column<int>(nullable: false),
                    Role_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_User_Team", x => new { x.User_Id, x.Role_Id, x.Board_Id, x.Team_Id });
                    table.ForeignKey(
                        name: "FK_TB_T_User_Team_TB_M_Board_Board_Id",
                        column: x => x.Board_Id,
                        principalTable: "TB_M_Board",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_T_User_Team_TB_M_Role_Role_Id",
                        column: x => x.Role_Id,
                        principalTable: "TB_M_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    IsDelete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(nullable: true),
                    DeleteDate = table.Column<DateTimeOffset>(nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_Card_StatusList_Id",
                table: "TB_T_Card",
                column: "StatusList_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_Status_List_Board_Id",
                table: "TB_T_Status_List",
                column: "Board_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_User_Team_Board_Id",
                table: "TB_T_User_Team",
                column: "Board_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_User_Team_Role_Id",
                table: "TB_T_User_Team",
                column: "Role_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_User_Team_Team_Id",
                table: "TB_T_User_Team",
                column: "Team_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_T_Card");

            migrationBuilder.DropTable(
                name: "TB_T_User_Team");

            migrationBuilder.DropTable(
                name: "TB_T_Status_List");

            migrationBuilder.DropTable(
                name: "TB_M_Role");

            migrationBuilder.DropTable(
                name: "TB_M_Team");

            migrationBuilder.DropTable(
                name: "TB_M_User");

            migrationBuilder.DropTable(
                name: "TB_M_Board");
        }
    }
}
