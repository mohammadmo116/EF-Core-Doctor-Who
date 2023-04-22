using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class create_EpisodesView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW viewEpisodes 
                                   AS
                                   SELECT A.AuthorName ,D.DoctorName  ,dbo.fnCompanions(E.EpisodeId) As CompanionName,
                                   dbo.fnEnemies(E.EpisodeId) As EnemiesName, E.*
                                   FROM Episodes E
                                   INNER JOIN Doctors D
                                   ON E.DoctorId=D.DoctorId 
                                   INNER JOIN Authors A 
                                   ON E.AuthorId =A.AuthorId ;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW viewEpisodes ");
        }
    }
}
