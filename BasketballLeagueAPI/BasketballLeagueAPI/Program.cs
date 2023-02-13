using BasketballLeagueAPI.Data;
using BasketballLeagueAPI.Extensions;
using BasketballLeagueAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BasketballLeagueDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options => options.AddPolicy(name: "BasketballLeagueOrigins", policy =>
{ 
    policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod(); 
}));

builder.Services.AddMemoryCache();

builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<ITeamService, TeamService>();

var app = builder.Build();

app.PrepareDataBase();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("BasketballLeagueOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
