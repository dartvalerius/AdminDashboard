using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AD.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RATES",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    DATE_SET = table.Column<string>(type: "TEXT", nullable: false),
                    CURRENT_RATE = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RATES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USER_PROFILES",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    NAME = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    BALANCE = table.Column<decimal>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_PROFILES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ACCOUNTS",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    EMAIL = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    PASSWORD_HASH = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 128, nullable: false),
                    SALT = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 128, nullable: false),
                    ROLE = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACCOUNTS_USER_PROFILES_ID",
                        column: x => x.ID,
                        principalTable: "USER_PROFILES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PAYMENTS",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    DATE_TIME = table.Column<string>(type: "TEXT", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "TEXT", nullable: false),
                    UserProfileId = table.Column<string>(type: "TEXT", nullable: false),
                    RateId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYMENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PAYMENTS_RATES_RateId",
                        column: x => x.RateId,
                        principalTable: "RATES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PAYMENTS_USER_PROFILES_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "USER_PROFILES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNTS_EMAIL",
                table: "ACCOUNTS",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PAYMENTS_RateId",
                table: "PAYMENTS",
                column: "RateId");

            migrationBuilder.CreateIndex(
                name: "IX_PAYMENTS_UserProfileId",
                table: "PAYMENTS",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_PROFILES_NAME",
                table: "USER_PROFILES",
                column: "NAME",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACCOUNTS");

            migrationBuilder.DropTable(
                name: "PAYMENTS");

            migrationBuilder.DropTable(
                name: "RATES");

            migrationBuilder.DropTable(
                name: "USER_PROFILES");
        }
    }
}
