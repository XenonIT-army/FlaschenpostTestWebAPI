using FlaschenpostTestDAL.Context;
using FlaschenpostTestDAL.Entities;
using FlaschenpostTestDAL.Interface;
using FlaschenpostTestDAL.Repositories;
using FlaschenpostTestWebAPI.Interface;
using FlaschenpostTestWebAPI.Model;
using FlaschenpostTestWebAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaschenpostTestxUnit
{
    public class TestServiceProviderFixture : IDisposable
    {
        public ServiceProvider ServiceProvider { get; }

        public TestServiceProviderFixture()
        {
            var services = new ServiceCollection();
            services.AddDbContext<DbContext, AppDbContext>(options =>
           options.UseInMemoryDatabase("InMemoryTestDb"));

            services.AddScoped<IRepository<CategoryDB>, CategoryDBRepository>();
            services.AddScoped<IService<Category>, CategoryService>();
            services.AddScoped<IRepository<TodoItemDB>, TodoItemDBRepository>();
            services.AddScoped<IService<TodoItem>, TodoItemService>();

            ServiceProvider = services.BuildServiceProvider();
        }

        public void Dispose()
        {
            ServiceProvider.Dispose();
        }
    }
}
