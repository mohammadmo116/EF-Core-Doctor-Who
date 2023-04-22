using DoctorWho.Db.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class create_enemies_function : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION dbo.fnEnemies(@EpisodeId int)
                                    RETURNS varchar(MAX) AS
                                  BEGIN
                                    DECLARE @return_value varchar(MAX);
                                    set @return_value = (
                                    SELECT STRING_AGG(E.EnemyName, ', ') WITHIN GROUP(ORDER BY  E.EnemyName ASC)
                                    FROM Enemies E
                                    INNER JOIN EnemyEpisode EE
                                    ON EE.EnemiesEnemyId = E.EnemyId
                                    where EE.EpisodesEpisodeId = @EpisodeId)
                                      RETURN @return_value
                                  END;");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION dbo.fnEnemies");
        }
    }
}
