using Infrastructure.Data;
using Infrastructure.Services.ChallengeServices;
using Infrastructure.Services.GroupServices;
using Infrastructure.Services.LocationServices;
using Infrastructure.Services.ParticipantServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var connection = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<DataContext>(conf=>conf.UseNpgsql(connection));

builder.Services.AddScoped<IGroupService,GroupService>();

builder.Services.AddScoped<IChallengeService,ChallengeService>();
builder.Services.AddScoped<IParticipantService,ParticipantService>();
builder.Services.AddScoped<ILocationService,LocationService>();

// builder.Services.AddDbContext<Infrastructure.Data.DataContext>(options =>
//     options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();

