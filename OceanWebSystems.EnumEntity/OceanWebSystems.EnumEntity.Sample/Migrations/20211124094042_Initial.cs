using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OceanWebSystems.EnumEntity.Sample.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdministrativeRegion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministrativeRegion", x => x.Id);
                    table.UniqueConstraint("AK_AdministrativeRegion_Value", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "ProgrammeClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammeClass", x => x.Id);
                    table.UniqueConstraint("AK_ProgrammeClass_Value", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "Programme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgrammeClass = table.Column<int>(type: "int", nullable: false),
                    AdministrativeRegion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programme_AdministrativeRegion_AdministrativeRegion",
                        column: x => x.AdministrativeRegion,
                        principalTable: "AdministrativeRegion",
                        principalColumn: "Value");
                    table.ForeignKey(
                        name: "FK_Programme_ProgrammeClass_ProgrammeClass",
                        column: x => x.ProgrammeClass,
                        principalTable: "ProgrammeClass",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AdministrativeRegion",
                columns: new[] { "Id", "Description", "Name", "Order", "Value" },
                values: new object[,]
                {
                    { 1, null, "West", null, 1 },
                    { 2, null, "South East", null, 2 },
                    { 3, null, "East", null, 3 },
                    { 4, null, "North", null, 4 }
                });

            migrationBuilder.InsertData(
                table: "ProgrammeClass",
                columns: new[] { "Id", "Description", "Name", "Order", "Value" },
                values: new object[,]
                {
                    { 1, null, "Medical", 1, 1 },
                    { 2, null, "Dental", 2, 2 },
                    { 3, null, "Healthcare Science", 8, 3 },
                    { 4, null, "Psychology", 4, 4 },
                    { 5, null, "Pharmacy", 3, 5 },
                    { 6, null, "Social Care", 7, 6 },
                    { 7, null, "General", 9, 7 },
                    { 8, null, "Optometry", 5, 8 },
                    { 9, null, "Covid", 11, 9 },
                    { 10, null, "Nursing", 6, 10 },
                    { 11, null, "Dental SQA Activity", 10, 11 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Programme_AdministrativeRegion",
                table: "Programme",
                column: "AdministrativeRegion");

            migrationBuilder.CreateIndex(
                name: "IX_Programme_ProgrammeClass",
                table: "Programme",
                column: "ProgrammeClass");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programme");

            migrationBuilder.DropTable(
                name: "AdministrativeRegion");

            migrationBuilder.DropTable(
                name: "ProgrammeClass");
        }
    }
}
