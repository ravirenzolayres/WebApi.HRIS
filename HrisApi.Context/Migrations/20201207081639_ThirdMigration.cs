using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HrisApi.Context.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BioLogs",
                columns: table => new
                {
                    IDNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                   
                    EmployeeCode = table.Column<string>(nullable: true),
                    BioId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<string>(nullable: true),
                    LogType = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),

                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BioLogs", x => x.IDNo);
                });

            migrationBuilder.UpdateData(
                table: "Access",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 16, 16, 38, 86, DateTimeKind.Local).AddTicks(1983));

            migrationBuilder.InsertData(
                table: "BioLogs",
                columns: new[] { "IDNo", "BioId", "CreatedBy", "CreatedOn", "Date", "DeletedBy", "DeletedOn", "EmployeeCode", "IsActive", "LogType", "Time", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 1, 101, "webadmin", new DateTime(2020, 12, 7, 16, 16, 38, 106, DateTimeKind.Local).AddTicks(8486), new DateTime(2020, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "1", true, 0, "4:16 PM", null, null });

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 16, 16, 38, 90, DateTimeKind.Local).AddTicks(6665));

            migrationBuilder.UpdateData(
                table: "CivilStatus",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 16, 16, 38, 98, DateTimeKind.Local).AddTicks(1786));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 16, 16, 38, 91, DateTimeKind.Local).AddTicks(2931));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 16, 16, 38, 91, DateTimeKind.Local).AddTicks(7860));

            migrationBuilder.UpdateData(
                table: "EducationInfo",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 16, 16, 38, 97, DateTimeKind.Local).AddTicks(2871));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "IDNo",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DateHired" },
                values: new object[] { new DateTime(2020, 12, 7, 16, 16, 38, 94, DateTimeKind.Local).AddTicks(7892), new DateTime(2020, 12, 7, 16, 16, 38, 94, DateTimeKind.Local).AddTicks(5794) });

            migrationBuilder.UpdateData(
                table: "EmployeeCustomSchedule",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 16, 16, 38, 103, DateTimeKind.Local).AddTicks(786));

            migrationBuilder.UpdateData(
                table: "EmployeeType",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 16, 16, 38, 93, DateTimeKind.Local).AddTicks(4644));

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 16, 16, 38, 97, DateTimeKind.Local).AddTicks(7553));

            migrationBuilder.UpdateData(
                table: "Holiday",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 16, 16, 38, 101, DateTimeKind.Local).AddTicks(322));

            migrationBuilder.UpdateData(
                table: "HolidayType",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 16, 16, 38, 101, DateTimeKind.Local).AddTicks(6641));

            migrationBuilder.UpdateData(
                table: "PersonalInfo",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 16, 16, 38, 95, DateTimeKind.Local).AddTicks(6227));

            migrationBuilder.UpdateData(
                table: "Position",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 16, 16, 38, 92, DateTimeKind.Local).AddTicks(2354));

            migrationBuilder.UpdateData(
                table: "Shift",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 16, 16, 38, 100, DateTimeKind.Local).AddTicks(751));

            migrationBuilder.UpdateData(
                table: "ShiftWeekly",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 16, 16, 38, 102, DateTimeKind.Local).AddTicks(2192));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 16, 16, 38, 92, DateTimeKind.Local).AddTicks(6868));

            migrationBuilder.UpdateData(
                table: "UserAccess",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 16, 16, 38, 93, DateTimeKind.Local).AddTicks(385));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BioLogs");

            migrationBuilder.UpdateData(
                table: "Access",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 8, 38, 42, 46, DateTimeKind.Local).AddTicks(9725));

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 8, 38, 42, 52, DateTimeKind.Local).AddTicks(4790));

            migrationBuilder.UpdateData(
                table: "CivilStatus",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 8, 38, 42, 62, DateTimeKind.Local).AddTicks(2494));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 8, 38, 42, 53, DateTimeKind.Local).AddTicks(1896));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 8, 38, 42, 53, DateTimeKind.Local).AddTicks(6367));

            migrationBuilder.UpdateData(
                table: "EducationInfo",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 8, 38, 42, 61, DateTimeKind.Local).AddTicks(3667));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "IDNo",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DateHired" },
                values: new object[] { new DateTime(2020, 12, 7, 8, 38, 42, 58, DateTimeKind.Local).AddTicks(6759), new DateTime(2020, 12, 7, 8, 38, 42, 58, DateTimeKind.Local).AddTicks(1880) });

            migrationBuilder.UpdateData(
                table: "EmployeeCustomSchedule",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 8, 38, 42, 65, DateTimeKind.Local).AddTicks(5366));

            migrationBuilder.UpdateData(
                table: "EmployeeType",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 8, 38, 42, 56, DateTimeKind.Local).AddTicks(222));

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 8, 38, 42, 61, DateTimeKind.Local).AddTicks(8165));

            migrationBuilder.UpdateData(
                table: "Holiday",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 8, 38, 42, 64, DateTimeKind.Local).AddTicks(2540));

            migrationBuilder.UpdateData(
                table: "HolidayType",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 8, 38, 42, 64, DateTimeKind.Local).AddTicks(6794));

            migrationBuilder.UpdateData(
                table: "PersonalInfo",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 8, 38, 42, 59, DateTimeKind.Local).AddTicks(6732));

            migrationBuilder.UpdateData(
                table: "Position",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 8, 38, 42, 54, DateTimeKind.Local).AddTicks(645));

            migrationBuilder.UpdateData(
                table: "Shift",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 8, 38, 42, 63, DateTimeKind.Local).AddTicks(6370));

            migrationBuilder.UpdateData(
                table: "ShiftWeekly",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 8, 38, 42, 65, DateTimeKind.Local).AddTicks(213));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 8, 38, 42, 54, DateTimeKind.Local).AddTicks(4912));

            migrationBuilder.UpdateData(
                table: "UserAccess",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 7, 8, 38, 42, 54, DateTimeKind.Local).AddTicks(8343));
        }
    }
}
