using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HrisApi.Context.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeCustomSchedule",
                columns: table => new
                {
                    IDNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    
                    EmployeeCode = table.Column<string>(nullable: true),
                    ShiftCode = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
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
                    table.PrimaryKey("PK_EmployeeCustomSchedule", x => x.IDNo);
                });

            migrationBuilder.CreateTable(
                name: "ShiftWeekly",
                columns: table => new
                {
                    IDNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    
                    ShiftCode = table.Column<string>(nullable: true),
                    Day = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_ShiftWeekly", x => x.IDNo);
                });

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

            migrationBuilder.InsertData(
                table: "EmployeeCustomSchedule",
                columns: new[] { "IDNo", "CreatedBy", "CreatedOn", "Date", "DeletedBy", "DeletedOn", "EmployeeCode", "IsActive", "ShiftCode", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 1, "webadmin", new DateTime(2020, 12, 7, 8, 38, 42, 65, DateTimeKind.Local).AddTicks(5366), new DateTime(2020, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "1", true, "TAYTAYS1", null, null });

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

            migrationBuilder.InsertData(
                table: "ShiftWeekly",
                columns: new[] { "IDNo", "CreatedBy", "CreatedOn", "Day", "DeletedBy", "DeletedOn", "IsActive", "ShiftCode", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 1, "webadmin", new DateTime(2020, 12, 7, 8, 38, 42, 65, DateTimeKind.Local).AddTicks(213), 1, null, null, true, "1", null, null });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeCustomSchedule");

            migrationBuilder.DropTable(
                name: "ShiftWeekly");

            migrationBuilder.UpdateData(
                table: "Access",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 11, 30, 8, 16, 41, 993, DateTimeKind.Local).AddTicks(1891));

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 11, 30, 8, 16, 42, 2, DateTimeKind.Local).AddTicks(4470));

            migrationBuilder.UpdateData(
                table: "CivilStatus",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 11, 30, 8, 16, 42, 14, DateTimeKind.Local).AddTicks(5441));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 11, 30, 8, 16, 42, 3, DateTimeKind.Local).AddTicks(3554));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 11, 30, 8, 16, 42, 4, DateTimeKind.Local).AddTicks(1062));

            migrationBuilder.UpdateData(
                table: "EducationInfo",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 11, 30, 8, 16, 42, 13, DateTimeKind.Local).AddTicks(2930));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "IDNo",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DateHired" },
                values: new object[] { new DateTime(2020, 11, 30, 8, 16, 42, 8, DateTimeKind.Local).AddTicks(6432), new DateTime(2020, 11, 30, 8, 16, 42, 8, DateTimeKind.Local).AddTicks(3563) });

            migrationBuilder.UpdateData(
                table: "EmployeeType",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 11, 30, 8, 16, 42, 6, DateTimeKind.Local).AddTicks(8850));

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 11, 30, 8, 16, 42, 13, DateTimeKind.Local).AddTicks(9381));

            migrationBuilder.UpdateData(
                table: "Holiday",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 11, 30, 8, 16, 42, 18, DateTimeKind.Local).AddTicks(3180));

            migrationBuilder.UpdateData(
                table: "HolidayType",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 11, 30, 8, 16, 42, 19, DateTimeKind.Local).AddTicks(1958));

            migrationBuilder.UpdateData(
                table: "PersonalInfo",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 11, 30, 8, 16, 42, 10, DateTimeKind.Local).AddTicks(5422));

            migrationBuilder.UpdateData(
                table: "Position",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 11, 30, 8, 16, 42, 5, DateTimeKind.Local).AddTicks(519));

            migrationBuilder.UpdateData(
                table: "Shift",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 11, 30, 8, 16, 42, 16, DateTimeKind.Local).AddTicks(7786));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 11, 30, 8, 16, 42, 5, DateTimeKind.Local).AddTicks(7283));

            migrationBuilder.UpdateData(
                table: "UserAccess",
                keyColumn: "IDNo",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 11, 30, 8, 16, 42, 6, DateTimeKind.Local).AddTicks(2439));
        }
    }
}
