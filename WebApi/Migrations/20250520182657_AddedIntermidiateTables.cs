using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
	/// <inheritdoc />
	public partial class AddedIntermidiateTables : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "DueTime",
				table: "UserTests");

			migrationBuilder.DropColumn(
				name: "QuestionsCount",
				table: "UserTests");

			migrationBuilder.AlterColumn<int>(
				name: "Result",
				table: "UserTests",
				type: "integer",
				nullable: true,
				oldClrType: typeof(int),
				oldType: "integer");

			migrationBuilder.AddColumn<DateTime>(
				name: "CompletedAt",
				table: "UserTests",
				type: "timestamp with time zone",
				nullable: true);

			migrationBuilder.AddColumn<TimeSpan>(
				name: "ElapsedTime",
				table: "UserTests",
				type: "interval",
				nullable: true);

			migrationBuilder.AddColumn<DateTime>(
				name: "StartedAt",
				table: "UserTests",
				type: "timestamp with time zone",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

			migrationBuilder.AddColumn<string>(
				name: "Explanation",
				table: "UserOptions",
				type: "text",
				nullable: true);


			migrationBuilder.CreateTable(
				name: "UserLessons",
				columns: table => new
				{
					LessonId = table.Column<int>(type: "integer", nullable: false),
					UserId = table.Column<int>(type: "integer", nullable: false),
					CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UserLessons", x => new { x.UserId, x.LessonId });
					table.ForeignKey(
						name: "FK_UserLessons_Lessons_LessonId",
						column: x => x.LessonId,
						principalTable: "Lessons",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_UserLessons_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "UserPractices",
				columns: table => new
				{
					PracticeId = table.Column<int>(type: "integer", nullable: false),
					UserId = table.Column<int>(type: "integer", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UserPractices", x => new { x.UserId, x.PracticeId });
					table.ForeignKey(
						name: "FK_UserPractices_Practices_PracticeId",
						column: x => x.PracticeId,
						principalTable: "Practices",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_UserPractices_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_UserLessons_LessonId",
				table: "UserLessons",
				column: "LessonId");

			migrationBuilder.CreateIndex(
				name: "IX_UserPractices_PracticeId",
				table: "UserPractices",
				column: "PracticeId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "UserLessons");

			migrationBuilder.DropTable(
				name: "UserPractices");

			migrationBuilder.DropColumn(
				name: "CompletedAt",
				table: "UserTests");

			migrationBuilder.DropColumn(
				name: "ElapsedTime",
				table: "UserTests");

			migrationBuilder.DropColumn(
				name: "StartedAt",
				table: "UserTests");

			migrationBuilder.DropColumn(
				name: "Explanation",
				table: "UserOptions");

			migrationBuilder.AlterColumn<int>(
				name: "Result",
				table: "UserTests",
				type: "integer",
				nullable: false,
				defaultValue: 0,
				oldClrType: typeof(int),
				oldType: "integer",
				oldNullable: true);

			migrationBuilder.AddColumn<string>(
				name: "DueTime",
				table: "UserTests",
				type: "text",
				nullable: true);

			migrationBuilder.AddColumn<int>(
				name: "QuestionsCount",
				table: "UserTests",
				type: "integer",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AlterColumn<string>(
				name: "Duration",
				table: "Tests",
				type: "text",
				nullable: true,
				oldClrType: typeof(TimeSpan),
				oldType: "interval");

			migrationBuilder.AlterColumn<string>(
				name: "Duration",
				table: "Practices",
				type: "text",
				nullable: true,
				oldClrType: typeof(TimeSpan),
				oldType: "interval",
				oldNullable: true);
		}
	}
}
