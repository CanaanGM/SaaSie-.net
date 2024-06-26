using GoodHabits.Database;
using GoodHabits.HabitService;
using Microsoft.AspNetCore.Mvc.Versioning;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c=>c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo {Title="GoodHabits.HabitService",Version="v1"}));
builder.Services.AddTransient<ITenantService, TenantService>();
builder.Services.AddTransient<IHabitService, HabitService>();
builder.Services.Configure<TenantSettings>(builder.Configuration.GetSection(nameof(TenantSettings)));
builder.Services.AddAndMigrateDatabases(builder.Configuration);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning(opt =>
{
  opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
  opt.AssumeDefaultVersionWhenUnspecified = true;
  opt.ReportApiVersions = true;
  opt.ApiVersionReader = ApiVersionReader.Combine(
    new UrlSegmentApiVersionReader()
    , new HeaderApiVersionReader("X-api-version")
    , new MediaTypeApiVersionReader("X-api-version")
    );
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json","GoodHabits.HabitService v1"));
  app.UseCors(policy =>
  policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
        );
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
