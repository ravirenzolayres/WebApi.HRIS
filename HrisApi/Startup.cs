using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrisApi.Context;
using HrisApi.Data;
using HrisApi.Data.Interface;
using HrisApi.Function;
using HrisApi.Function.Interface;
using HrisApi.Function.JWTManager;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace HrisApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddDbContext<HrisApiContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DevConn")));

            #region Function
            services.AddScoped<IFAccess,FAccess>();
            services.AddScoped<IFBranch, FBranch>();
            services.AddScoped<IFCivilStatus, FCivilStatus>();
            services.AddScoped<IFCompany, FCompany>();
            services.AddScoped<IFDepartment, FDepartment>();
            services.AddScoped<IFEducationInfo, FEducationInfo>();
            services.AddScoped<IFEmployee, FEmployee>();
            services.AddScoped<IFEmployeeType, FEmployeeType>();
            services.AddScoped<IFGender, FGender>();
            services.AddScoped<IFPersonalInfo, FPersonalInfo>();
            services.AddScoped<IFPosition, FPosition>();
            services.AddScoped<IFShift, FShift>();
            services.AddScoped<IFUserAccess, FUserAccess>();
            services.AddScoped<IFUser, FUser>();
            services.AddScoped<IFHoliday, FHoliday>();
            services.AddScoped<IFHolidayType, FHolidayType>();
            services.AddScoped<IFShift, FShift>();
            services.AddScoped<IFShiftWeekly, FShiftWeekly>();


            #endregion

            #region Data
            services.AddScoped<IDAccess, DAccess>();
            services.AddScoped<IDBranch, DBranch>();
            services.AddScoped<IDCivilStatus, DCivilStatus>();
            services.AddScoped<IDCompany, DCompany>();
            services.AddScoped<IDDepartment, DDepartment>();
            services.AddScoped<IDEducationInfo, DEducationInfo>();
            services.AddScoped<IDEmployee, DEmployee>();
            services.AddScoped<IDEmployeeType, DEmployeeType>();
            services.AddScoped<IDGender, DGender>();
            services.AddScoped<IDPersonalInfo, DPersonalInfo>();
            services.AddScoped<IDPosition, DPosition>();
            services.AddScoped<IDShift, DShift>();
            services.AddScoped<IDUserAccess, DUserAccess>();
            services.AddScoped<IDUser, DUser>();
            services.AddScoped<IDHoliday, DHoliday>();
            services.AddScoped<IDHolidayType, DHolidayType>();
            services.AddScoped<IDShift, DShift>();
            services.AddScoped<IDShiftWeekly, DShiftWeekly>();


            #endregion

            services.AddScoped<IJwtManager, JwtManager>();

            services.AddHttpContextAccessor();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
