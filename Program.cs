using Nest;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var elasticUri = builder.Configuration["Elasticsearch:Uri"];
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
builder.Host.UseSerilog();

var settings = new ConnectionSettings(new Uri(elasticUri!))
    .DefaultIndex(builder.Configuration["Elasticsearch:Index"]);
var client = new ElasticClient(settings);

//verificar se a conexão foi bem sucedida
var pingResponse = client.Ping();

builder.Services.AddSingleton<IElasticClient>(client);

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.MapControllers();
app.UseHttpsRedirection();


app.Run();

