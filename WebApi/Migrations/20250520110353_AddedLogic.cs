using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedLogic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTests",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    TestId = table.Column<int>(type: "integer", nullable: false),
                    DueTime = table.Column<string>(type: "text", nullable: true),
                    Result = table.Column<int>(type: "integer", nullable: false),
                    QuestionsCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTests", x => new { x.UserId, x.TestId });
                    table.ForeignKey(
                        name: "FK_UserTests_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserQuestions",
                columns: table => new
                {
                    UserTestId = table.Column<int>(type: "integer", nullable: false),
                    QuestionId = table.Column<int>(type: "integer", nullable: false),
                    UserTestUserId = table.Column<int>(type: "integer", nullable: false),
                    UserTestTestId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQuestions", x => new { x.UserTestId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_UserQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserQuestions_UserTests_UserTestUserId_UserTestTestId",
                        columns: x => new { x.UserTestUserId, x.UserTestTestId },
                        principalTable: "UserTests",
                        principalColumns: new[] { "UserId", "TestId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOptions",
                columns: table => new
                {
                    UserQuestionId = table.Column<int>(type: "integer", nullable: false),
                    OptionId = table.Column<int>(type: "integer", nullable: false),
                    UserQuestionUserTestId = table.Column<int>(type: "integer", nullable: false),
                    UserQuestionQuestionId = table.Column<int>(type: "integer", nullable: false),
                    CorrectOptionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOptions", x => new { x.UserQuestionId, x.OptionId });
                    table.ForeignKey(
                        name: "FK_UserOptions_Options_CorrectOptionId",
                        column: x => x.CorrectOptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOptions_Options_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOptions_UserQuestions_UserQuestionUserTestId_UserQuesti~",
                        columns: x => new { x.UserQuestionUserTestId, x.UserQuestionQuestionId },
                        principalTable: "UserQuestions",
                        principalColumns: new[] { "UserTestId", "QuestionId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserOptions_CorrectOptionId",
                table: "UserOptions",
                column: "CorrectOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOptions_OptionId",
                table: "UserOptions",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOptions_UserQuestionUserTestId_UserQuestionQuestionId",
                table: "UserOptions",
                columns: new[] { "UserQuestionUserTestId", "UserQuestionQuestionId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserQuestions_QuestionId",
                table: "UserQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQuestions_UserTestUserId_UserTestTestId",
                table: "UserQuestions",
                columns: new[] { "UserTestUserId", "UserTestTestId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserTests_TestId",
                table: "UserTests",
                column: "TestId");
        }
    }
}
