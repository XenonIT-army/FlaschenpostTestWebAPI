using FlaschenpostTestWebAPI.Model;
using FlaschenpostTestxUnit.Item;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FlaschenpostTestxUnit.ControllerTest
{
    public class TodoControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public TodoControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/todoitem/")]
        public async Task Get_TodoItem(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.True(response.IsSuccessStatusCode);
        }

        [Theory]
        [InlineData("/api/todoitem/1")]
        public async Task GetById_TodoItem(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            var res = false;
            if(response.StatusCode == System.Net.HttpStatusCode.NotFound || response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                res = true;
            }
            Assert.True(res);
        }

        [Theory]
        [InlineData("/api/todoitem/")]
        public async Task Post_TodoItem(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var jsonString = JsonConvert.SerializeObject(StaticItem.TodoItem);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.True(response.IsSuccessStatusCode);
        }

        [Theory]
        [InlineData("/api/todoitem/")]
        public async Task Put_TodoItem(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act

            var jsonString = JsonConvert.SerializeObject(StaticItem.TodoItem);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(url, content);

            // Assert
            var res = false;
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound || response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                res = true;
            }
            Assert.True(res);
        }
        [Theory]
        [InlineData("http://localhost:5173/api/todoitem/")]
        public async Task Delete_TodoItem(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var jsonString = JsonConvert.SerializeObject(StaticItem.TodoItem);
            var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(url),
                    Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
                };
            var response = await client.SendAsync(request);

            // Assert
            var res = false;
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound || response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                res = true;
            }
            Assert.True(res);
        }
    }

}
