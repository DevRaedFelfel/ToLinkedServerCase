using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication6.Migrations
{
    public partial class Converting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE Products DROP CONSTRAINT FK_Products_Categories_CategoryId;
                GO
                DROP TABLE CATEGORIES;
                GO
                CREATE VIEW Categories AS (
	                SELECT * FROM [LOCALORACLE]..[TESTING].[CATEGORIES]
                );
                GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
