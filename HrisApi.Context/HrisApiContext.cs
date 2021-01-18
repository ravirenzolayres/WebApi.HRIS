using HrisApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrisApi.Context
{
    public class HrisApiContext : DbContext
    {
        public HrisApiContext()
        {
        }

        public HrisApiContext(DbContextOptions db) :base(db)
        {

        }

        public DbSet<Access> Access { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserAccess> UserAccess { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeType> EmployeeType { get; set; }
        public DbSet<PersonalInfo> PersonalInfo { get; set; }
        public DbSet<EducationInfo> EducationInfo { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<CivilStatus> CivilStatus { get; set; }
        public DbSet<Shift> Shift { get; set; }
        public DbSet<Holiday> HolidayCalendar { get; set; }
        public DbSet<HolidayType> HolidayType { get; set; }
        public DbSet<ShiftWeekly> ShiftWeekly { get; set; }
        public DbSet<EmployeeCustomSchedule> EmployeeCustomSchedule { get; set; }
        public DbSet<BioLogs> BioLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Access>().HasData(
                new Access
                {
                    IDNo = 1,
                    AccessCode = "AC01",
                    AccessName = "ALL-ACCESS",
                    IsActive = true,
                    CreatedBy = "webadmin",
                    CreatedOn = DateTime.Now
                });

            mb.Entity<Branch>().HasData(
               new Branch
               {
                   IDNo = 1,
                   BranchCode = "TAY01",
                   BranchName = "TAYTAY",
                   IsActive = true,
                   CreatedBy = "webadmin",
                   CreatedOn = DateTime.Now
               });

            mb.Entity<Company>().HasData(
               new Company
               {
                   IDNo = 1,
                   CompanyCode = "RRGO1",
                   CompanyName = "RRGO INC.",
                   CompanyAddress = "TAYTAY",
                   ContactNumber = "123456789",
                   IsActive = true,
                   CreatedBy = "webadmin",
                   CreatedOn = DateTime.Now
               });

            mb.Entity<Department>().HasData(
               new Department
               {
                   IDNo = 1,
                   DepartmentCode = "IT01",
                   DepartmentName = "IT-SOFTWARE",
                   IsActive = true,
                   CreatedBy = "webadmin",
                   CreatedOn = DateTime.Now
               });

            mb.Entity<Position>().HasData(
              new Position
              {
                  IDNo = 1,
                  PositionCode = "SOFTDEV",
                  PositionName = "SOFTWARE DEVELOPER",
                  IsActive = true,
                  CreatedBy = "webadmin",
                  CreatedOn = DateTime.Now
              });

            mb.Entity<User>().HasData(
              new User
              {
                  IDNo = 1,
                  Username = "webadmin",
                  Password = "masterpassword",
                  IsActive = true,
                  CreatedBy = "webadmin",
                  CreatedOn = DateTime.Now
              });

            mb.Entity<UserAccess>().HasData(
             new UserAccess
             {
                 IDNo = 1,
                 Username = "webadmin", 
                 AccessCode = "1",
                 CreatedBy = "webadmin",
                 CreatedOn = DateTime.Now
             });

            mb.Entity<EmployeeType>().HasData(
             new EmployeeType
             {
                 IDNo = 1,
                 EmployeeTypeCode = "R",
                 EmployeeTypeName = "REGULAR",
                 IsActive = true,
                 CreatedBy = "webadmin",
                 CreatedOn = DateTime.Now
             });

            mb.Entity<Employee>().HasData(
             new Employee
             {
                 IDNo = 1,
                 EmployeeCode = "1",
                 BioId = 101,
                 CompanyCode = "RRGO1",
                 BranchCode = "TAY01",
                 DepartmentCode = "IT01",
                 PositionCode = "SOFTDEV",
                 EmployeeTypeCode = "R",
                 PersonalInfoId = 1,
                 EducationInfoId = 1,
                 Username = "webadmin",
                 DateHired = DateTime.Now,
                 IsActive = true,
                 CreatedBy = "webadmin",
                 CreatedOn = DateTime.Now
             });

            mb.Entity<PersonalInfo>().HasData(
             new PersonalInfo
             {
                 IDNo = 1,
                 EmployeeCode = "1",
                 LastName = "OLAYRES",
                 FirstName = "RAVI RENZ",
                 MiddleName = "GONZAGA",
                 GenderCode = "M",
                 CivilStatusCode = "S",
                 Address = "TAYTAY RIZAl",
                 Mobile = "09352863548",
                 CreatedBy = "webadmin",
                 CreatedOn = DateTime.Now
             });

            mb.Entity<EducationInfo>().HasData(
            new EducationInfo
            {
                IDNo = 1,
                EmployeeCode = "1",
                ESName = "ROSARIO OCAMPO ELEM. SCHOOL",
                HSName = "JUAN SUMULONG MEMORIAL JR. COLLEGE",
                VSName = "ACLC COLLEGE OF TAYTAY",
                CSName = "STI COLLEGE ORTIGAS - CAINTA",

                ESAddress = "TAYTAY, RIZAL",
                HSAddress = "TAYTAY, RIZAL",
                VSAddress =  "TAYTAY, RIZAL",
                CSAddress = "TAYTAY, RIZAL",

                CSCourse = "BS IN INFORMATION TECHNOLOGY",
                VSCourse = "CSDP",

                ESInclusiveStartYear = "2002",
                HSInclusiveStartYear = "2008",
                VSInclusiveStartYear = "2012",
                CSInclusiveStartYear = "2014",

                ESInclusiveEndYear = "2008",
                HSInclusiveEndYear = "2012",
                VSInclusiveEndYear = "2014",
                CSInclusiveEndYear = "2018",

                CreatedBy = "webadmin",
                CreatedOn = DateTime.Now
            });

            mb.Entity<Gender>().HasData(
            new Gender
            {
                IDNo = 1,
                GenderCode = "M",
                GenderName = "MALE",
                IsActive = true,
                CreatedBy = "webadmin",
                CreatedOn = DateTime.Now
            });

           mb.Entity<CivilStatus>().HasData(
           new CivilStatus
           {
               IDNo = 1,
               CivilStatusCode = "S",
               CivilStatusName = "SINGLE",
               IsActive = true,
               CreatedBy = "webadmin",
               CreatedOn = DateTime.Now
           });

            mb.Entity<Shift>().HasData(
              new Shift
              {
                  IDNo = 1,
                  ShiftCode = "TAYTAYS1",
                  ShiftName = "TAYTAY 08:00AM - 05:00PM",
                  ShiftIn = "08:00",
                  ShiftOut = "17:00",
                  ND1ShiftIn = "18:00",
                  ND1ShiftOut = "22:00",
                  ND2ShiftIn = "22:00",
                  ND2ShiftOut = "02:00",
                  ND3ShiftIn = "02:00",
                  ND3ShiftOut = "06:00",
                  HoursWork = 8.00M,
                  GracePeriod = 15.00M,
                  Brk = 60.00M,
                  IsRestday = false,
                  IsActive = true,
                  CreatedBy = "webadmin",
                  CreatedOn = DateTime.Now
              });

            mb.Entity<Holiday>().HasData(
            new Holiday
            {
                IDNo = 1,
                HolidayCode = "1",
                HolidayName = "CHRISTMAS DAY",
                Date = new DateTime(2020,12,25),
                IsFixed = true,
                IsActive = true,
                CreatedBy = "webadmin",
                CreatedOn = DateTime.Now
            });

            mb.Entity<HolidayType>().HasData(
            new HolidayType
            {
                IDNo = 1,
                HolidayTypeCode = "REGHOL",
                HolidayTypeName = "REGULAR HOLIDAY",
                IsActive = true,
                CreatedBy = "webadmin",
                CreatedOn = DateTime.Now
            });

            mb.Entity<ShiftWeekly>().HasData(
            new ShiftWeekly
            {
               IDNo = 1,
               ShiftCode = "1",
               Day = 1,
               CreatedBy = "webadmin",
               CreatedOn = DateTime.Now,
               IsActive = true
            });

            mb.Entity<EmployeeCustomSchedule>().HasData(
            new EmployeeCustomSchedule
            {
                IDNo = 1,
                EmployeeCode = "1",
                ShiftCode = "TAYTAYS1",
                Date = new DateTime(2020, 12, 04),
                CreatedBy = "webadmin",
                CreatedOn = DateTime.Now,
                IsActive = true
            });

            mb.Entity<BioLogs>().HasData(
           new BioLogs
           {
               IDNo = 1,
               EmployeeCode = "1",
               BioId = 101,
               Date = new DateTime(2020, 12, 04),
               Time = DateTime.Now.ToShortTimeString(),
               LogType = 0,
               CreatedBy = "webadmin",
               CreatedOn = DateTime.Now,
               IsActive = true
           });




        }

    }
}
