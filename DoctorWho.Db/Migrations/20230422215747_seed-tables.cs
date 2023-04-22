using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class seedtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorName" },
                values: new object[,]
                {
                    { 1, "Minato" },
                    { 2, "Minato" },
                    { 3, "Minato" },
                    { 4, "Jiraya" },
                    { 5, "Tsunadi" }
                });

            migrationBuilder.InsertData(
                table: "Companions",
                columns: new[] { "CompanionId", "CompanionName", "WhoPlayed" },
                values: new object[,]
                {
                    { 1, "c1", "p1" },
                    { 2, "c2", "p2" },
                    { 3, "c3", "p3" },
                    { 4, "c4", "p4" },
                    { 5, "c5", "p5" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "BirthDate", "DoctorName", "DoctorNumber", "FirstEpisodDate", "LastEpisodDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Minato", 564841, new DateTime(2011, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "demon", 51654, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2005, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "pain", 5154, new DateTime(2014, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2006, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "kakashi", 2, new DateTime(2013, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2008, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "shikamaro", 3, new DateTime(2012, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Enemies",
                columns: new[] { "EnemyId", "Description", "EnemyName" },
                values: new object[,]
                {
                    { 1, "destroy the word", "pain" },
                    { 2, "waking madara up", "obito" },
                    { 3, "tsokoyome", "Madara" },
                    { 4, "eat the forbidden fruit", "Kaguya" },
                    { 5, "destroy Naruto anime", "Boruto" }
                });

            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "EpisodeId", "AuthorId", "DoctorId", "EpisodDate", "EpisodNumber", "EpisodType", "Notes", "SeriesNumber", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "a", "ddd", 2, "vv" },
                    { 2, 3, 2, new DateTime(2030, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "b", "aaa", 1, "vva" },
                    { 3, 2, 5, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "c", "fdsfds", 3, "va" },
                    { 4, 5, 3, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "d", " ", 4, "aavv" },
                    { 5, 4, 4, new DateTime(2005, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "f", "dsfdsf", 5, "ddas" }
                });

            migrationBuilder.InsertData(
                table: "CompanionEpisode",
                columns: new[] { "CompanionsCompanionId", "EpisodesEpisodeId" },
                values: new object[,]
                {
                    { 1, 4 },
                    { 2, 5 },
                    { 3, 4 },
                    { 4, 1 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "EnemyEpisode",
                columns: new[] { "EnemiesEnemyId", "EpisodesEpisodeId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 4 },
                    { 3, 4 },
                    { 4, 1 },
                    { 5, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CompanionEpisode",
                keyColumns: new[] { "CompanionsCompanionId", "EpisodesEpisodeId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "CompanionEpisode",
                keyColumns: new[] { "CompanionsCompanionId", "EpisodesEpisodeId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "CompanionEpisode",
                keyColumns: new[] { "CompanionsCompanionId", "EpisodesEpisodeId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "CompanionEpisode",
                keyColumns: new[] { "CompanionsCompanionId", "EpisodesEpisodeId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "CompanionEpisode",
                keyColumns: new[] { "CompanionsCompanionId", "EpisodesEpisodeId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "EnemyEpisode",
                keyColumns: new[] { "EnemiesEnemyId", "EpisodesEpisodeId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "EnemyEpisode",
                keyColumns: new[] { "EnemiesEnemyId", "EpisodesEpisodeId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "EnemyEpisode",
                keyColumns: new[] { "EnemiesEnemyId", "EpisodesEpisodeId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "EnemyEpisode",
                keyColumns: new[] { "EnemiesEnemyId", "EpisodesEpisodeId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "EnemyEpisode",
                keyColumns: new[] { "EnemiesEnemyId", "EpisodesEpisodeId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 4);
        }
    }
}
