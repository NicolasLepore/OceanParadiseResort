using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OceanParadiseResort.Customers.Data;
using OceanParadiseResort.Customers.Models;
using OceanParadiseResort.Customers.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var connectionString = builder.Configuration.GetConnectionString("DbConnectionString");

builder.Services.AddDbContext<AppUserContext>(opt =>
{
    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services
    .AddIdentity<Customer, IdentityRole>()
    .AddEntityFrameworkStores<AppUserContext>()
    .AddDefaultTokenProviders();


builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireUppercase = false;
});

builder.Services.AddScoped<RegisterCustomer>();
builder.Services.AddScoped<SignInCustomer>();
builder.Services.AddScoped<TokenService>();

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SymmetricKey"]!)),
        ValidateAudience = false,
        ValidateIssuer = false,      
        ClockSkew = TimeSpan.Zero
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
