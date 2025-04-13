using FlaschenpostTestDAL.Context;
using FlaschenpostTestDAL.Data;
using FlaschenpostTestDAL.Entities;
using FlaschenpostTestDAL.Interface;
using FlaschenpostTestDAL.Repositories;
using FlaschenpostTestWebAPI;
using FlaschenpostTestWebAPI.Interface;
using FlaschenpostTestWebAPI.Model;
using FlaschenpostTestWebAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbContext,AppDbContext>(options =>
            options.UseInMemoryDatabase("InMemoryDb"));

builder.Services.AddScoped<IRepository<CategoryDB>, CategoryDBRepository>();
builder.Services.AddScoped<IService<Category>, CategoryService>();

builder.Services.AddScoped<IRepository<TodoItemDB>, TodoItemDBRepository>();
builder.Services.AddScoped<IService<TodoItem>, TodoItemService>();

builder.Services.AddScoped<IRepository<ProjectDB>, ProjectDBRepository>();
builder.Services.AddScoped<IService<Project>, ProjectService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.WebHost.ConfigureKestrel(options =>
//{
//    options.ListenAnyIP(5000);

//});
var app = builder.Build();
app.UseAuthorization();

app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated(); 
    DbInitializer.Seed(db);
}
app.Run();
public partial class Program 
{ 
}