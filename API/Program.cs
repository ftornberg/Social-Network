using API.ErrorResponse;
using API.Helpers;
using Entity.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddControllers();

builder.Services.AddDbContext<NetworkContext>(x =>
  {
    x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"),
        x => x.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
  });

builder.Services.AddSwaggerGen(c =>
  {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
  });

builder.Services.AddCors(opt =>
  {
    opt.AddPolicy("CorsPolicy", options => options.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));
  });

var scope = builder.Services.BuildServiceProvider().CreateScope();

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

builder.Services.Configure<ApiBehaviorOptions>(options =>
  {
    options.InvalidModelStateResponseFactory = actionContext =>
    {
      var errors = actionContext.ModelState
        .Where(e => e.Value.Errors.Count > 0)
        .SelectMany(x => x.Value.Errors)
        .Select(x => x.ErrorMessage).ToArray();

      var errorResponse = new ApiValidationErrorResponse
      {
        Errors = errors
      };

      return new BadRequestObjectResult(errorResponse);
    };
  });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var contextLogger = services.GetRequiredService<ILogger<Program>>();
try
{
    var context = services.GetRequiredService<NetworkContext>();
    await context.Database.MigrateAsync();
    await NetworkContextSeed.SeedAsync(context);

}
catch (Exception ex)
{
    contextLogger.LogError(ex, "Something wrong happened during migration");

}

app.Run();
