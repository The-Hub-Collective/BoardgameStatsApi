using boardgameStats.Options;
using boardgameStats.Services;
using Microsoft.AspNetCore.Builder;
using static boardgameStats.Services.BoardgameService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBoardgameService, BoardgamesService>();
builder.Services.AddScoped<IDatabaseService, DatabaseService>();
builder.Services.Configure<DatabaseOptions>( builder.Configuration.GetSection( "DatabaseOptions" ) );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();

app.UseSwaggerUI();

app.Run();
