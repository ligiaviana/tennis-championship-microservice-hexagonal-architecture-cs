using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TennisChampionshipMicroservice.Adapters.SqliteAdapters;
using TennisChampionshipMicroservice.Cores;
using TennisChampionshipMicroservice.Ports.Ins;
using TennisChampionshipMicroservice.Ports.Outs;
using TennisChampionshipMicroservice.UseCases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IRegisterPlayerUseCase, RegisterPlayerUseCase>();
builder.Services.AddScoped<ILoginPlayerUseCase, LoginPlayerUseCase>();
builder.Services.AddScoped<IRegisterRacketUseCase, RegisterRacketUseCase>();
builder.Services.AddScoped<ICreateLaundryUseCase, CreateLaundryUseCase>();
builder.Services.AddScoped<IRegisterCourtUseCase, RegisterCourtUseCase>();
builder.Services.AddScoped<IDeleteCourtUseCase, DeleteCourtUseCase>();
builder.Services.AddScoped<IDeleteLaundryUseCase, DeleteLaundryUseCase>();
builder.Services.AddScoped<IDeletePlayerUseCase, DeletePlayerUseCase>();
builder.Services.AddScoped<IDeleteRacketUseCase, DeleteRacketUseCase>();
builder.Services.AddScoped<IPlayerCore, PlayerCore>();
builder.Services.AddScoped<IRacketCore, RacketCore>();
builder.Services.AddScoped<ILaundryCore, LaundryCore>();
builder.Services.AddScoped<IPlayerLogCore, PlayerLogCore>();
builder.Services.AddScoped<ICourtCore, CourtCore>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IRacketRepository, RacketRepository>();
builder.Services.AddScoped<ILaundryRepository, LaundryRepository>();
builder.Services.AddScoped<ICourtRepository, CourtRepository>();

// Load configuration
IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

var key = configuration.GetValue<string>("Jwt:Key");
var issuer = configuration.GetValue<string>("Jwt:Issuer");

var jwtCore = new JwtCore(configuration);
builder.Services.AddScoped<IJwtCore>(_ => jwtCore);

builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
        };
    });

// Add DbContext
builder.Services.AddDbContext<PlayerDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<RacketDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<LaundryDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<CourtDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseAuthentication();

app.UseAuthorization();

app.Run();
