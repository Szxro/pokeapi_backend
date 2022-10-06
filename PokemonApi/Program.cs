using Data;
using Microsoft.EntityFrameworkCore;
using PokemonApi.Services.PokemonService;
using PokemonApi.Services.UrlService;
using PokemonApi.Services.HttpServices;
using PokemonApi.Services.PokeSplits;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IPokeService, PokeService>();
builder.Services.AddScoped<IUrlService, UrlService>();
builder.Services.AddScoped<IHttpService, HttpService>();
builder.Services.AddScoped<IPokeSplit, PokeSplit>();
builder.Services.AddDbContext<PokeContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});

var app = builder.Build();
app.UseCors(m => 
{
    m.AllowAnyHeader();
    m.AllowAnyOrigin();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
