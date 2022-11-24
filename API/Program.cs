using API.Helpers;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();

builder.Services.AddDbContext<NetworkContext>(x =>
  {
    x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
  });

builder.Services.AddSwaggerGen(c =>
  {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
  });

builder.Services.AddCors(opt =>
  {
    opt.AddPolicy("AllowOrigin", options => options.AllowAnyHeader().AllowAnyMethod().AllowCredentials()
    .WithOrigins("http://localhost:3000"));
  });

using var scope = builder.Services.BuildServiceProvider().CreateScope();
var services = scope.ServiceProvider;
try
{
  var context = services.GetRequiredService<NetworkContext>();
  await context.Database.MigrateAsync();

}
catch (System.Exception ex)
{
  var logger = services.GetRequiredService<ILogger<Program>>();
  logger.LogError(ex, "An error occurred while migrating the database.");
}


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

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
