using FlaschenpostTestWebAPI.Interface;
using FlaschenpostTestWebAPI.Model;
using FlaschenpostTestxUnit.Item;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaschenpostTestxUnit.ServiceTest
{
    public class TodoItemServiceTests : IClassFixture<TestServiceProviderFixture>
    {
        private readonly IService<TodoItem> _todoItemService;

        public TodoItemServiceTests(TestServiceProviderFixture fixture)
        {
            var scope = fixture.ServiceProvider.CreateScope();
            _todoItemService = scope.ServiceProvider.GetRequiredService<IService<TodoItem>>();
        }

        [Fact]
        public async Task GetAllAsync_TodoItems()
        {
            // Act
            var result = await _todoItemService.GetAllAsync();
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetByIdAsync_TodoItems()
        {
            // Act
            var item = await _todoItemService.AddAsync(StaticItem.TodoItem);
            var res = await _todoItemService.Save();
            var result = await _todoItemService.GetByIdAsync(item.Id);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task AddAsync_TodoItems()
        {
            // Act
            var item = await _todoItemService.AddAsync(StaticItem.TodoItem);
            var result = await _todoItemService.Save();
            // Assert
            Assert.True(result);
        }
        [Fact]
        public async Task UpdateAsync_TodoItems()
        {
            // Act
            await _todoItemService.Update(StaticItem.TodoItem);
            var result = await _todoItemService.Save();
            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteAsync_TodoItems()
        {
            // Act
            var item = await _todoItemService.AddAsync(StaticItem.TodoItem);
            var result1 = await _todoItemService.Save();
            await _todoItemService.Delete(item);
            var result2 = await _todoItemService.Save();

            // Assert
            Assert.True(result2);
        }
    }
}
