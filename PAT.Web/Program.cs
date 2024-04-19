using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PAT.AccessModel.Models;
using PAT.Provider.Info.Repos;
using PAT.Provider.Info.Repos.IRepos;
using PAT.Provider.Info.Service;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers().AddApplicationPart(typeof(PAT.Provider.Info.Controllers.UserController).Assembly);
builder.Services.AddControllers().AddApplicationPart(typeof(PAT.Web.Controllers.UserMVCController).Assembly);
builder.Services.AddControllersWithViews().AddApplicationPart(typeof(PAT.Web.Controllers.UserMVCController).Assembly);
builder.Services.AddAutoMapper(typeof(PAT.Provider.Info.InfoMappingConfig).Assembly);
builder.Services.AddHealthChecks();
// builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer("Data Source=DESKTOP-51AF734;Initial Catalog=TestDB;Persist Security Info=True;User ID=SCTracker;Password=SCTracker@123;MultipleActiveResultSets=True;TrustServerCertificate=True;", b => b.MigrationsAssembly("PAT.Web")));

//Registering the services and repositories
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserDetailsRepo, UserDetailsRepo>();
builder.Services.AddScoped<UserService>();

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


//builder
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    // app.UseSwagger();
    // app.UseSwaggerUI();
}

app.UseHealthChecks("/health");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapRazorPages();
app.MapControllers();
app.MapControllerRoute(
				name: "default",
				pattern: "{controller=UserMVC}/{action=Login}");
app.Run();
