using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class create_summarise_procedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE spSummariseEpisodes
                                    AS
                                    SELECT TOP 3 E.Title, count(CE.EpisodesEpisodeId) As CompanionsCount
                                    FROM CompanionEpisode CE
                                    INNER JOIN Episodes E
                                    ON E.EpisodeId= CE.EpisodesEpisodeId
                                    GROUP BY E.Title
                                    ORDER BY CompanionsCount DESC 
                                    
                                    SELECT TOP 3 E.Title, COUNT(EE.EnemiesEnemyId) AS EnemiesCount
                                    FROM  EnemyEpisode EE
                                    INNER JOIN Episodes E 
                                    ON EE.EpisodesEpisodeId = E.EpisodeId 
                                    GROUP BY E.Title 
                                    ORDER BY EnemiesCount DESC 
                                    ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE spSummariseEpisodes");
        }
    }
}
