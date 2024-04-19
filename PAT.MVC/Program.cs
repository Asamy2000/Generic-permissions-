using Microsoft.EntityFrameworkCore;
using PAT.Provider.Info.Repos.IRepos;
using PAT.Provider.Info.Repos;
using PAT.Provider.Info.Service;
using PAT.AccessModel.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using PAT.Service;

namespace PAT.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
            builder.Services.AddAutoMapper(typeof(Provider.Info.InfoMappingConfig).Assembly);
            builder.Services.AddHealthChecks();
            // builder.Services.AddSwaggerGen();

            // connetcion string from the appsettings.json file
            builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(builder.Configuration["DefaultConnection3"], b => b.MigrationsAssembly("PAT.MVC")));

            // Set port to listen on
            builder.WebHost.UseUrls($"http://*:{builder.Configuration["HostPort"]}");




            //Registering the services and repositories
            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddScoped<IHelperRepo, HelperRepo>();
            builder.Services.AddScoped<IGovernment, GovernmentRepo>();
            builder.Services.AddScoped<IPositionRepo, PositionRepo>();
            builder.Services.AddScoped<IEducitionalAdministration, EducitionalAdministrationRepo>();
            builder.Services.AddScoped<IUserDetailsRepo, UserDetailsRepo>();
            builder.Services.AddScoped<IBranchRepo, BranchRepo>();
            builder.Services.AddScoped<IMinisterialEmploymentDescisionsRepo, MinisterialEmploymentDescisionsRepo>();
            builder.Services.AddScoped<IContactRepo, ContactRepo>();
            builder.Services.AddScoped<IFAQRepo, FAQRepo>();
            builder.Services.AddScoped<IAccreditedCenter, AccreditedCenterRepo>();
            builder.Services.AddScoped<ITeamMembersRepo, TeamMembersRepo>();
            builder.Services.AddScoped<IAcademyNews, AcademyNewsRepo>();
            builder.Services.AddScoped<IAboutPATRepo, AboutPATRepo>();
            builder.Services.AddScoped<IMonthesRepo, MonthesRepo>();
            builder.Services.AddScoped<ITermsRepo, TermsRepo>();
            builder.Services.AddScoped<IMagazineRepo, MagazineRepo>();
            builder.Services.AddScoped<IPATManagerRepo, PATManagerRepo>();
            builder.Services.AddScoped<ICarousalRepo, CarousalRepo>();
            builder.Services.AddScoped<ISocialRepo, SocialRepo>();
            builder.Services.AddScoped<ICertificateProcedure, CertificateProcedureRepo>();
            builder.Services.AddScoped<IAccreditationProcedureRepo, AccreditationProcedureRepo>();
            builder.Services.AddScoped<IAccreditationProcedureCategoryRepo, AccreditationProcedureCategoryRepo>();
            builder.Services.AddScoped<IUserCertificateRequestRepo, UserCertificateRequestRepo>();
            builder.Services.AddScoped<IUserCertificatesRepo, UserCertificatesRepo>();


            builder.Services.AddScoped<MinisterialEmploymentDescisionsService>();
            builder.Services.AddScoped<Provider.Info.Service.UserService>();
            builder.Services.AddScoped<PositionService>();
            builder.Services.AddScoped<EducitionalAdministrationService>();
            builder.Services.AddScoped<GovernmentService>();
            builder.Services.AddScoped<BranchService>();
            builder.Services.AddScoped<ContactService>();


            builder.Services.AddControllers(options =>
            {
                var jsonInputFormatter = options.InputFormatters
                                    .OfType<Microsoft.AspNetCore.Mvc.Formatters.SystemTextJsonInputFormatter>()
                                    .Single();
                jsonInputFormatter.SupportedMediaTypes.Add("application/csp-report");
            }
            );

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.RequireHttpsMetadata = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = builder.Configuration["JwtSettings:Audience"],
                    ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
                };
            });

            builder.Services.AddAuthorization();
            var app = builder.Build();
            #region Migrate database

            using var scope = app.Services.CreateScope();

            var services = scope.ServiceProvider;

            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {

                var dbContext = services.GetRequiredService<DBContext>();

                dbContext.Database.Migrate();

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, ex.Message);
            }

            #endregion

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}