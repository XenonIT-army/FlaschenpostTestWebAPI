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
    public class ProjectServiceTests : IClassFixture<TestServiceProviderFixture>
    {
        private readonly IService<Project> _projectService;

        public ProjectServiceTests(TestServiceProviderFixture fixture)
        {
            var scope = fixture.ServiceProvider.CreateScope();
            _projectService = scope.ServiceProvider.GetRequiredService<IService<Project>>();
        }

        [Fact]
        public async Task GetAllAsync_Categories()
        {
            // Act
            var result = await _projectService.GetAllAsync();
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetByIdAsync_Categories()
        {
            // Act
            var item = await _projectService.AddAsync(StaticItem.Project);
            var res = await _projectService.Save();
            var result = await _projectService.GetByIdAsync(item.Id);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task AddAsync_Categories()
        {
            // Act
            var item = await _projectService.AddAsync(StaticItem.Project);
            var result = await _projectService.Save();
            // Assert
            Assert.True(result);
        }
        [Fact]
        public async Task UpdateAsync_Categories()
        {
            // Act
            await _projectService.Update(StaticItem.Project);
            var result = await _projectService.Save();
            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteAsync_Categories()
        {
            // Act
            var item = await _projectService.AddAsync(StaticItem.Project);
            var result1 = await _projectService.Save();
            await _projectService.Delete(item);
            var result2 = await _projectService.Save();

            // Assert
            Assert.True(result2);
        }
    }
}
