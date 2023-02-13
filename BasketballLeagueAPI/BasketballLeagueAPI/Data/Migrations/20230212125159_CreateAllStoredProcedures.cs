using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasketballLeagueAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateAllStoredProcedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string spGetAllGames = @"CREATE PROCEDURE [dbo].[spGetAllGames]
                                    (
	                                    @PageNumber INT,
		                                @PageSize INT
                                    )
                                    AS
                                    BEGIN

		                            DECLARE @StartRow INT = (@PageNumber - 1) * @PageSize + 1;
		                            DECLARE @EndRow INT = @PageNumber * @PageSize;
		                            
		                            WITH Page AS(
		                            SELECT
		                            ROW_NUMBER() OVER (ORDER BY g.Id) AS RowNum,
                                     	[t].[Name] AS HomeTeamName, 
                                     	[t0].[Name] AS AwayTeamName, 
                                     	CONCAT([g].[HomeTeamScore],':',[g].[AwayTeamScore]) AS Score
                                     	FROM [Games] AS [g]
                                     	INNER JOIN [Teams] AS [t] ON [g].[HomeTeamId] = [t].[Id]
                                     	INNER JOIN [Teams] AS [t0] ON [g].[AwayTeamId] = [t0].[Id]
		                            )
                                    SELECT 
		                            p.HomeTeamName,
		                            p.AwayTeamName,
		                            p.Score
		                            FROM Page AS p
		                            WHERE p.RowNum BETWEEN @StartRow AND @EndRow;
                                    END";

            migrationBuilder.Sql(spGetAllGames);
            
            string spGetAllTeams = @"CREATE PROCEDURE [dbo].[spGetAllTeams]
                                    (
                                        @PageNumber INT,
                                        @PageSize INT,
                                        @SearchName NVARCHAR(50) = NULL
                                    )
                                    AS
                                    BEGIN
                                    	DECLARE @StartRow INT = (@PageNumber - 1) * @PageSize + 1;
                                        DECLARE @EndRow INT = @PageNumber * @PageSize;

                                        WITH Page AS (
                                            SELECT ROW_NUMBER() OVER (ORDER BY t.Name) AS RowNum, t.Name
                                            FROM Teams t
                                            WHERE (@SearchName IS NULL OR (@SearchName LIKE N'%' + t.Name + N'%') OR CHARINDEX(@SearchName, t.Name) > 0)
                                        )
                                        SELECT 
	                                    p.Name
                                        FROM Page AS p
                                        WHERE p.RowNum BETWEEN @StartRow AND @EndRow;
                                    END";

            migrationBuilder.Sql(spGetAllTeams);
            
            string spGetHighlightMatch = @"CREATE PROCEDURE [dbo].[spGetHighlightMatch]
                                    AS
                                    BEGIN
                                    	SELECT TOP (1)
                                    	[t].[Name] AS HomeTeamName, 
                                    	[t0].[Name] AS AwayTeamName, 
                                    	CONCAT([g].[HomeTeamScore],':',[g].[AwayTeamScore]) AS Score
                                    	FROM Games AS g
                                    	INNER JOIN Teams AS t ON g.HomeTeamId = t.Id 
                                    	INNER JOIN Teams AS t0 ON g.AwayTeamId = t0.Id
                                    	ORDER BY HomeTeamScore + AwayTeamScore DESC
                                    END";

            migrationBuilder.Sql(spGetHighlightMatch);
            
            string spGetTopFiveDefensiveTeams = @"CREATE PROCEDURE [dbo].[spGetTopFiveDefensiveTeams]
                                            AS
                                            BEGIN
                                            	SELECT TOP 5 
                                            	t.Name
                                            	FROM Teams AS t
                                            	INNER JOIN Games AS g ON t.Id = g.HomeTeamID OR t.Id = g.AwayTeamID
                                            	GROUP BY t.Id, t.Name
                                            	ORDER BY SUM(CASE WHEN t.Id = g.HomeTeamID THEN g.AwayTeamScore ELSE g.HomeTeamScore END) ASC
                                            END";

            migrationBuilder.Sql(spGetTopFiveDefensiveTeams);
            
            string spGetTopFiveOffensiveTeams = @"CREATE PROCEDURE [dbo].[spGetTopFiveOffensiveTeams]
                                                AS
                                                BEGIN
                                                	SELECT TOP 5  
                                                	t.Name
                                                	FROM Teams AS t
                                                	INNER JOIN Games AS g ON t.Id = g.HomeTeamID OR t.Id = g.AwayTeamID
                                                	GROUP BY t.Id, t.Name
                                                	ORDER BY SUM(g.HomeTeamScore + g.AwayTeamScore) DESC
                                                END";

            migrationBuilder.Sql(spGetTopFiveOffensiveTeams);
            
            string spGetTotalGames = @"CREATE PROCEDURE [dbo].[spGetTotalGames]
                                        AS
                                        BEGIN
                                        	SELECT 
                                        	COUNT(*) AS TotalCount
                                            FROM Games
                                        END";

            migrationBuilder.Sql(spGetTotalGames);
            
            string spGetTotalTeams = @"CREATE PROCEDURE [dbo].[spGetTotalTeams]
                                        (
                                            @SearchName NVARCHAR(50) = NULL
                                        )
                                        AS
                                        BEGIN
                                        	SELECT 
                                        	COUNT(*) AS TotalCount
                                            FROM Teams t
                                            WHERE (@SearchName IS NULL OR (@SearchName LIKE N'%' + t.Name + N'%') OR CHARINDEX(@SearchName, t.Name) > 0)
                                        END";

            migrationBuilder.Sql(spGetTotalTeams);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string spGetAllGames = @"DROP PROCEDURE [dbo].[spGetAllGames]";

            migrationBuilder.Sql(spGetAllGames);

            string spGetAllTeams = @"DROP PROCEDURE [dbo].[spGetAllTeams]";

            migrationBuilder.Sql(spGetAllTeams);

            string spGetHighlightMatch = @"DROP PROCEDURE [dbo].[spGetHighlightMatch]";

            migrationBuilder.Sql(spGetHighlightMatch);

            string spGetTopFiveDefensiveTeams = @"DROP PROCEDURE [dbo].[spGetTopFiveDefensiveTeams]";

            migrationBuilder.Sql(spGetTopFiveDefensiveTeams);

            string spGetTopFiveOffensiveTeams = @"DROP PROCEDURE [dbo].[spGetTopFiveOffensiveTeams]";

            migrationBuilder.Sql(spGetTopFiveOffensiveTeams);
            
            string spGetTotalGames = @"DROP PROCEDURE [dbo].[spGetTotalGames]";

            migrationBuilder.Sql(spGetTotalGames);
            
            string spGetTotalTeams = @"DROP PROCEDURE [dbo].[spGetTotalTeams]";

            migrationBuilder.Sql(spGetTotalTeams);
        }
    }
}
