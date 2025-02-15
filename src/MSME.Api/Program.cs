using MSME.Core;
using MSME.Core.Abstractions;
using MSME.Core.Domain;
using MSME.Infrastructure;


var Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IServiceManager,ServiceManager>();
builder.Services.AddTransient<IJsonHandler,JsonHandler>();
builder.Services.Configure<AppSettings>(Configuration);
builder.Services.AddTransient<IPokemonDataAccess,PokemonDataAccess>();
builder.Services.AddSingleton<MSME.Core.Abstractions.ILogger, Logger>();
builder.Services.AddSingleton<ICacheManager, CacheManager>();
builder.Services.AddTransient<IPokemonRuleEngine,PokemonRuleEngine>();

HttpClient httpClient = new HttpClient();

builder.Services.AddSingleton(httpClient);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



