using FlaschenpostTestDAL.Context;
using FlaschenpostTestDAL.Entities;
using FlaschenpostTestDAL.Interface;
using FlaschenpostTestDAL.Repositories;
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

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
app.UseAuthorization();

app.MapControllers();

app.Run();
public partial class Program { }