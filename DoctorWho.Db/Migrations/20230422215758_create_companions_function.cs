using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class create_companions_function : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION dbo.fnCompanions(@EpisodeId int)
                                       RETURNS varchar(MAX) AS
                                    BEGIN
                                        DECLARE @return_value varchar(MAX)
                                        set @return_value = (
                                        SELECT STRING_AGG(C.CompanionName, ', ') WITHIN GROUP(ORDER BY  C.CompanionName DESC)
                                        FROM Companions C
                                        INNER JOIN CompanionEpisode CE
                                        ON CE.CompanionsCompanionId = C.CompanionId
                                        where CE.EpisodesEpisodeId = @EpisodeId)
                                        RETURN @return_value
                                    END;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION dbo.fnCompanions");
        }
    }
}
