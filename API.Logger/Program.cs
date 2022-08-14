using API.Logger.MIddlewares;
using API.Logger.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAppSettings();
builder.Services.AddDbClients();
builder.Services.AddCustomMiddlewares();
builder.Services.AddCorsPolicy();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseMiddleware<ErrorHeandlingMiddelware>();
app.UseHttpsRedirection();
app.UseCors(Constans.CustomCorsPolicy.AllowAll);

app.UseAuthorization();

app.MapControllers();

app.Run();
