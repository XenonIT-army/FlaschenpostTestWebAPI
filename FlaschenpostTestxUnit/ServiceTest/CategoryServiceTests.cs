using FlaschenpostTestWebAPI.Interface;
using FlaschenpostTestWebAPI.Model;
using FlaschenpostTestxUnit.Item;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FlaschenpostTestxUnit.ServiceTest
{
    public class CategoryServiceTests : IClassFixture<TestServiceProviderFixture>
    {
        private readonly IService<Category> _categoryService;

        public CategoryServiceTests(TestServiceProviderFixture fixture)
        {
            var scope = fixture.ServiceProvider.CreateScope();
            _categoryService = scope.ServiceProvider.GetRequiredService<IService<Category>>();
        }

        [Fact]
        public async Task GetAllAsync_Categories()
        {
            // Act
            var result = await _categoryService.GetAllAsync();
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetByIdAsync_Categories()
        {
            // Act
            var item = await _categoryService.AddAsync(StaticItem.Category);
            var res = await _categoryService.Save();
            var result = await _categoryService.GetByIdAsync(item.Id);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task AddAsync_Categories()
        {
            // Act
            var item = await _categoryService.AddAsync(StaticItem.Category);
            var result = await _categoryService.Save();
            // Assert
            Assert.True(result); 
        }
        [Fact]
        public async Task UpdateAsync_Categories()
        {
            // Act
            await _categoryService.Update(StaticItem.Category);
            var result = await _categoryService.Save();
            // Assert
            Assert.True(result); 
        }

        [Fact]
        public async Task DeleteAsync_Categories()
        {
            // Act
            var item = await _categoryService.AddAsync(StaticItem.Category);
            var result1 = await _categoryService.Save();
            await _categoryService.Delete(item);
            var result2 = await _categoryService.Save();

            // Assert
            Assert.True(result2);
        }
    }

}
