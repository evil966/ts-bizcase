using Microsoft.EntityFrameworkCore.Migrations;

namespace TsBizcase.Infrastructure.Migrations
{
    public partial class AddPerformanceScript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROC sp_GetAppUserById(@UID INT) AS SELECT * FROM AppUsers WHERE Id = @UID");
            migrationBuilder.Sql(@"CREATE PROC sp_GetTenderById(@TID INT) AS SELECT * FROM Tenders WHERE Id = @TID");
            migrationBuilder.Sql(@"CREATE PROC sp_GetAppUserByEmailAndPassword(@EMAIL NVARCHAR(MAX), @PASSWORD NVARCHAR(MAX)) AS SELECT * FROM AppUsers WHERE Email = @EMAIL AND HashedPassword = @PASSWORD");
            migrationBuilder.Sql(@"CREATE PROC sp_GetAllTenders AS SELECT * FROM Tenders");
            migrationBuilder.Sql(@"CREATE PROC sp_CreateTender(@NAME NVARCHAR(MAX), @REFERENCENUMBER NVARCHAR(MAX), @RELEASEDATE DATETIME2(7), @CLOSINGDATE DATETIME2(7), @DESCRIPTION NVARCHAR(MAX), @CREATORID INT)                       
                                        AS BEGIN
                                            INSERT INTO Tenders (Name, ReferenceNumber, ReleaseDate, ClosingDate, Description, CreatorId) 
                                            VALUES (@NAME, @REFERENCENUMBER, @RELEASEDATE, @CLOSINGDATE, @DESCRIPTION, @CREATORID);
                                            SELECT * FROM Tenders WHERE Id=SCOPE_IDENTITY();
                                        END");
            migrationBuilder.Sql(@"CREATE PROC sp_UpdateTender(@ID INT, @NAME NVARCHAR(MAX), @REFERENCENUMBER NVARCHAR(MAX), @RELEASEDATE DATETIME2(7), @CLOSINGDATE DATETIME2(7), @DESCRIPTION NVARCHAR(MAX), @CREATORID INT)                       
                                        AS BEGIN
                                            UPDATE Tenders SET Name=@NAME, ReferenceNumber=@REFERENCENUMBER, ReleaseDate=@RELEASEDATE, ClosingDate=@CLOSINGDATE, Description=@DESCRIPTION, CreatorId=@CREATORID
                                            WHERE Id=@ID;
                                            SELECT * FROM Tenders WHERE Id=@ID;
                                        END");
            migrationBuilder.Sql(@"CREATE PROC sp_DeleteTender(@ID INT)      
                                        AS BEGIN
                                            DELETE FROM Tenders WHERE Id=@ID;
                                            SELECT @@ROWCOUNT AS RECORDSAFFECTED;
                                        END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROC sp_GetAppUserById");
            migrationBuilder.Sql(@"DROP PROC sp_GetTenderById");
            migrationBuilder.Sql(@"DROP PROC sp_GetAppUserByEmailAndPassword");
            migrationBuilder.Sql(@"DROP PROC sp_GetAllTenders");
            migrationBuilder.Sql(@"DROP PROC sp_CreateTender");
            migrationBuilder.Sql(@"DROP PROC sp_UpdateTender");
            migrationBuilder.Sql(@"DROP PROC sp_DeletedTender");
        }
    }
}
