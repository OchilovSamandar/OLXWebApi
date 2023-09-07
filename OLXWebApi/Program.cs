using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OLXWebApi.Data.DbContexts;
using OLXWebApi.Data.IRepositories;
using OLXWebApi.Data.Repositories;
using OLXWebApi.Extensions;
using OLXWebApi.Middlewares;
using OLXWebApi.Services.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OlxDbContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddCustomService();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureCors();
builder.Services.AddJwtService(builder.Configuration);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", p => p.RequireRole("Admin"));
    options.AddPolicy("User", p => p.RequireRole("User"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
