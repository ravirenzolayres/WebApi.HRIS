using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HrisApi.Context.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Access",
                columns: table => new
                {
                    IDNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    
                    AccessCode = table.Column<string>(nullable: true),
                    AccessName = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_Access", x => x.IDNo);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    IDNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    
                    BranchCode = table.Column<string>(nullable: true),
                    BranchName = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_Branch", x => x.IDNo);
                });

            migrationBuilder.CreateTable(
                name: "CivilStatus",
                columns: table => new
                {
                    IDNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    
                    CivilStatusCode = table.Column<string>(nullable: true),
                    CivilStatusName = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_CivilStatus", x => x.IDNo);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    IDNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    
                    CompanyCode = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    CompanyAddress = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_Company", x => x.IDNo);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    IDNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    
                    DepartmentCode = table.Column<string>(nullable: true),
                    DepartmentName = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_Department", x => x.IDNo);
                });

            migrationBuilder.CreateTable(
                name: "EducationInfo",
                columns: table => new
                {
                    IDNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    
                    EmployeeCode = table.Column<string>(nullable: true),
                    ESName = table.Column<string>(nullable: true),
                    HSName = table.Column<string>(nullable: true),
                    VSName = table.Column<string>(nullable: true),
                    CSName = table.Column<string>(nullable: true),
                    PGSName = table.Column<string>(nullable: true),
                    ESAddress = table.Column<string>(nullable: true),
                    HSAddress = table.Column<string>(nullable: true),
                    VSAddress = table.Column<string>(nullable: true),
                    CSAddress = table.Column<string>(nullable: true),
                    PGSAddress = table.Column<string>(nullable: true),
                    ESInclusiveStartYear = table.Column<string>(nullable: true),
                    HSInclusiveStartYear = table.Column<string>(nullable: true),
                    VSInclusiveStartYear = table.Column<string>(nullable: true),
                    CSInclusiveStartYear = table.Column<string>(nullable: true),
                    PGSInclusiveStartYear = table.Column<string>(nullable: true),
                    ESInclusiveEndYear = table.Column<string>(nullable: true),
                    HSInclusiveEndYear = table.Column<string>(nullable: true),
                    VSInclusiveEndYear = table.Column<string>(nullable: true),
                    CSInclusiveEndYear = table.Column<string>(nullable: true),
                    PGSInclusiveEndYear = table.Column<string>(nullable: true),
                    CSCourse = table.Column<string>(nullable: true),
                    VSCourse = table.Column<string>(nullable: true),
                    PGSCourse = table.Column<string>(nullable: true),

                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationInfo", x => x.IDNo);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    IDNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    
                    EmployeeCode = table.Column<string>(nullable: true),
                    BioId = table.Column<int>(nullable: false),
                    CompanyCode = table.Column<string>(nullable: true),
                    BranchCode = table.Column<string>(nullable: true),
                    DepartmentCode = table.Column<string>(nullable: true),
                    PositionCode = table.Column<string>(nullable: true),
                    EmployeeTypeCode = table.Column<string>(nullable: true),
                    PersonalInfoId = table.Column<int>(nullable: false),
                    EducationInfoId = table.Column<int>(nullable: false),
                    ProfileImg = table.Column<string>(nullable: true),
                    DefaultShiftCode = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    DateHired = table.Column<DateTime>(nullable: true),
                    DateRegularized = table.Column<DateTime>(nullable: true),
                    DateResigned = table.Column<DateTime>(nullable: true),
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
                    table.PrimaryKey("PK_Employee", x => x.IDNo);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeType",
                columns: table => new
                {
                    IDNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    
                    EmployeeTypeCode = table.Column<string>(nullable: true),
                    EmployeeTypeName = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_EmployeeType", x => x.IDNo);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    IDNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    
                    GenderCode = table.Column<string>(nullable: true),
                    GenderName = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_Gender", x => x.IDNo);
                });

            migrationBuilder.CreateTable(
                name: "Holiday",
                columns: table => new
                {
                    IDNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    
                    HolidayCode = table.Column<string>(nullable: true),
                    HolidayName = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    IsFixed = table.Column<bool>(nullable: false),
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
                    table.PrimaryKey("PK_Holiday", x => x.IDNo);
                });

            migrationBuilder.CreateTable(
                name: "HolidayType",
                columns: table => new
                {
                    IDNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    
                    HolidayTypeCode = table.Column<string>(nullable: true),
                    HolidayTypeName = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_HolidayType", x => x.IDNo);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInfo",
                columns: table => new
                {
                    IDNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    
                    EmployeeCode = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    GenderCode = table.Column<string>(nullable: true),
                    CivilStatusCode = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),

                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInfo", x => x.IDNo);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    IDNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    
                    PositionCode = table.Column<string>(nullable: true),
                    PositionName = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_Position", x => x.IDNo);
                });

            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    IDNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    
                    ShiftCode = table.Column<string>(nullable: true),
                    ShiftName = table.Column<string>(nullable: true),
                    ShiftIn = table.Column<string>(nullable: true),
                    ShiftOut = table.Column<string>(nullable: true),
                    ND1ShiftIn = table.Column<string>(nullable: true),
                    ND1ShiftOut = table.Column<string>(nullable: true),
                    ND2ShiftIn = table.Column<string>(nullable: true),
                    ND2ShiftOut = table.Column<string>(nullable: true),
                    ND3ShiftIn = table.Column<string>(nullable: true),
                    ND3ShiftOut = table.Column<string>(nullable: true),
                    HoursWork = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GracePeriod = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Brk = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsRestday = table.Column<bool>(nullable: false),
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
                    table.PrimaryKey("PK_Shift", x => x.IDNo);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IDNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_User", x => x.IDNo);
                });

            migrationBuilder.CreateTable(
                name: "UserAccess",
                columns: table => new
                {
                    IDNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                   
                    Username = table.Column<string>(nullable: true),
                    AccessCode = table.Column<string>(nullable: true),

                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccess", x => x.IDNo);
                });

            migrationBuilder.InsertData(
                table: "Access",
                columns: new[] { "IDNo", "AccessCode", "AccessName", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IsActive", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 1, "AC01", "ALL-ACCESS", "webadmin", new DateTime(2020, 11, 30, 8, 16, 41, 993, DateTimeKind.Local).AddTicks(1891), null, null, true, null, null });

            migrationBuilder.InsertData(
                table: "Branch",
                columns: new[] { "IDNo", "BranchCode", "BranchName", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IsActive", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 1, "TAY01", "TAYTAY", "webadmin", new DateTime(2020, 11, 30, 8, 16, 42, 2, DateTimeKind.Local).AddTicks(4470), null, null, true, null, null });

            migrationBuilder.InsertData(
                table: "CivilStatus",
                columns: new[] { "IDNo", "CivilStatusCode", "CivilStatusName", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IsActive", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 1, "S", "SINGLE", "webadmin", new DateTime(2020, 11, 30, 8, 16, 42, 14, DateTimeKind.Local).AddTicks(5441), null, null, true, null, null });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "IDNo", "CompanyAddress", "CompanyCode", "CompanyName", "ContactNumber", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IsActive", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 1, "TAYTAY", "RRGO1", "RRGO INC.", "123456789", "webadmin", new DateTime(2020, 11, 30, 8, 16, 42, 3, DateTimeKind.Local).AddTicks(3554), null, null, true, null, null });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "IDNo", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "DepartmentCode", "DepartmentName", "IsActive", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 1, "webadmin", new DateTime(2020, 11, 30, 8, 16, 42, 4, DateTimeKind.Local).AddTicks(1062), null, null, "IT01", "IT-SOFTWARE", true, null, null });

            migrationBuilder.InsertData(
                table: "EducationInfo",
                columns: new[] { "IDNo", "CSAddress", "CSCourse", "CSInclusiveEndYear", "CSInclusiveStartYear", "CSName", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "ESAddress", "ESInclusiveEndYear", "ESInclusiveStartYear", "ESName", "EmployeeCode", "HSAddress", "HSInclusiveEndYear", "HSInclusiveStartYear", "HSName", "PGSAddress", "PGSCourse", "PGSInclusiveEndYear", "PGSInclusiveStartYear", "PGSName", "UpdatedBy", "UpdatedOn", "VSAddress", "VSCourse", "VSInclusiveEndYear", "VSInclusiveStartYear", "VSName" },
                values: new object[] { 1, "TAYTAY, RIZAL", "BS IN INFORMATION TECHNOLOGY", "2018", "2014", "STI COLLEGE ORTIGAS - CAINTA", "webadmin", new DateTime(2020, 11, 30, 8, 16, 42, 13, DateTimeKind.Local).AddTicks(2930), null, null, "TAYTAY, RIZAL", "2008", "2002", "ROSARIO OCAMPO ELEM. SCHOOL", "1", "TAYTAY, RIZAL", "2012", "2008", "JUAN SUMULONG MEMORIAL JR. COLLEGE", null, null, null, null, null, null, null, "TAYTAY, RIZAL", "CSDP", "2014", "2012", "ACLC COLLEGE OF TAYTAY" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "IDNo", "BioId", "BranchCode", "CompanyCode", "CreatedBy", "CreatedOn", "DateHired", "DateRegularized", "DateResigned", "DefaultShiftCode", "DeletedBy", "DeletedOn", "DepartmentCode", "EducationInfoId", "EmployeeCode", "EmployeeTypeCode", "IsActive", "PersonalInfoId", "PositionCode", "ProfileImg", "UpdatedBy", "UpdatedOn", "Username" },
                values: new object[] { 1, 101, "TAY01", "RRGO1", "webadmin", new DateTime(2020, 11, 30, 8, 16, 42, 8, DateTimeKind.Local).AddTicks(6432), new DateTime(2020, 11, 30, 8, 16, 42, 8, DateTimeKind.Local).AddTicks(3563), null, null, null, null, null, "IT01", 1, "1", "R", true, 1, "SOFTDEV", null, null, null, "webadmin" });

            migrationBuilder.InsertData(
                table: "EmployeeType",
                columns: new[] { "IDNo", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "EmployeeTypeCode", "EmployeeTypeName", "IsActive", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 1, "webadmin", new DateTime(2020, 11, 30, 8, 16, 42, 6, DateTimeKind.Local).AddTicks(8850), null, null, "R", "REGULAR", true, null, null });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "IDNo", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "GenderCode", "GenderName", "IsActive", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 1, "webadmin", new DateTime(2020, 11, 30, 8, 16, 42, 13, DateTimeKind.Local).AddTicks(9381), null, null, "M", "MALE", true, null, null });

            migrationBuilder.InsertData(
                table: "Holiday",
                columns: new[] { "IDNo", "CreatedBy", "CreatedOn", "Date", "DeletedBy", "DeletedOn", "HolidayCode", "HolidayName", "IsActive", "IsFixed", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 1, "webadmin", new DateTime(2020, 11, 30, 8, 16, 42, 18, DateTimeKind.Local).AddTicks(3180), new DateTime(2020, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "1", "CHRISTMAS DAY", true, true, null, null });

            migrationBuilder.InsertData(
                table: "HolidayType",
                columns: new[] { "IDNo", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "HolidayTypeCode", "HolidayTypeName", "IsActive", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 1, "webadmin", new DateTime(2020, 11, 30, 8, 16, 42, 19, DateTimeKind.Local).AddTicks(1958), null, null, "REGHOL", "REGULAR HOLIDAY", true, null, null });

            migrationBuilder.InsertData(
                table: "PersonalInfo",
                columns: new[] { "IDNo", "Address", "CivilStatusCode", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "EmployeeCode", "FirstName", "GenderCode", "LastName", "MiddleName", "Mobile", "Telephone", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 1, "TAYTAY RIZAl", "S", "webadmin", new DateTime(2020, 11, 30, 8, 16, 42, 10, DateTimeKind.Local).AddTicks(5422), null, null, "1", "RAVI RENZ", "M", "OLAYRES", "GONZAGA", "09352863548", null, null, null });

            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "IDNo", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IsActive", "PositionCode", "PositionName", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 1, "webadmin", new DateTime(2020, 11, 30, 8, 16, 42, 5, DateTimeKind.Local).AddTicks(519), null, null, true, "SOFTDEV", "SOFTWARE DEVELOPER", null, null });

            migrationBuilder.InsertData(
                table: "Shift",
                columns: new[] { "IDNo", "Brk", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "GracePeriod", "HoursWork", "IsActive", "IsRestday", "ND1ShiftIn", "ND1ShiftOut", "ND2ShiftIn", "ND2ShiftOut", "ND3ShiftIn", "ND3ShiftOut", "ShiftCode", "ShiftIn", "ShiftName", "ShiftOut", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 1, 60.00m, "webadmin", new DateTime(2020, 11, 30, 8, 16, 42, 16, DateTimeKind.Local).AddTicks(7786), null, null, 15.00m, 8.00m, true, false, "18:00", "22:00", "22:00", "02:00", "02:00", "06:00", "TAYTAYS1", "08:00", "TAYTAY 08:00AM - 05:00PM", "17:00", null, null });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "IDNo", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IsActive", "Password", "UpdatedBy", "UpdatedOn", "Username" },
                values: new object[] { 1, "webadmin", new DateTime(2020, 11, 30, 8, 16, 42, 5, DateTimeKind.Local).AddTicks(7283), null, null, true, "masterpassword", null, null, "webadmin" });

            migrationBuilder.InsertData(
                table: "UserAccess",
                columns: new[] { "IDNo", "AccessCode", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "UpdatedBy", "UpdatedOn", "Username" },
                values: new object[] { 1, "1", "webadmin", new DateTime(2020, 11, 30, 8, 16, 42, 6, DateTimeKind.Local).AddTicks(2439), null, null, null, null, "webadmin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Access");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "CivilStatus");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "EducationInfo");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "EmployeeType");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Holiday");

            migrationBuilder.DropTable(
                name: "HolidayType");

            migrationBuilder.DropTable(
                name: "PersonalInfo");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserAccess");
        }
    }
}
