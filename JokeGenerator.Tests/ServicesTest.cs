using JokeGenerator.Interfaces;
using JokeGenerator.Models;
using JokeGenerator.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace JokeGenerator.Tests
{
    /// <summary>
    /// Unit test class for .
    /// </summary>
    public class ServicesTest
    {
        #region Mock objects
        private readonly Mock<INameService> _mockNameService;
        private readonly Mock<IJokeService> _mockJokeService;
        #endregion



        #region Ctor
        public ServicesTest()
        {
            _mockNameService = new Mock<INameService>();
            _mockJokeService = new Mock<IJokeService>();
        }
        #endregion

        #region Unit Tests
        [Fact(DisplayName = "Success - GetRandomName")]
        public async Task Success_GetRandomName()
        {

            // Arrange
            _mockNameService.Setup(x => x.GetRandomName()).Returns(Task.FromResult(new NameData() {  Name= "Dan", SurName="Jhonson"}));

            // Act
            var result = await _mockNameService.Object.GetRandomName();


            // Assert
            Assert.Equal("Dan", result.Name);
            Assert.Equal("Jhonson", result.SurName);
        }

        [Fact(DisplayName = "Failure - GetRandomName")]
        public async Task Failure_GetRandomName()
        {

            // Arrange
            _mockNameService.Setup(x => x.GetRandomName()).Throws(new Exception("Failure"));

            // Act
            var resultException = await Record.ExceptionAsync(async () => await _mockNameService.Object.GetRandomName());


            // Assert
            Assert.Equal("Failure", resultException.Message);
        }


        [Fact(DisplayName = "Success - GetCategories")]
        public async Task Success_GetCategories()
        {

            // Arrange
            IDictionary<int, string> dict = new Dictionary<int, string>() { { 1, "news" } };
            _mockJokeService.Setup(x => x.GetCategories()).Returns(Task.FromResult(dict));

            // Act
            var result = await _mockJokeService.Object.GetCategories();


            // Assert
            Assert.Equal("news", result[1]);            
        }

        [Fact(DisplayName = "Failure - GetCategories")]
        public async Task Failure_GetCategories()
        {

            // Arrange
            _mockJokeService.Setup(x => x.GetCategories()).Throws(new Exception("Failure"));

            // Act
            var resultException = await Record.ExceptionAsync(async () => await _mockJokeService.Object.GetCategories());


            // Assert
            Assert.Equal("Failure", resultException.Message);
        }

        [Theory(DisplayName = "Success - GetJoke")]
        [InlineData("animal")]
        [InlineData("career")]
        [InlineData("celebrity")]
        [InlineData("dev")]
        [InlineData("explicit")]
        public async Task Success_GetJoke(string category)
        {

            // Arrange            
            _mockJokeService.Setup(x => x.GetJoke(category)).Returns(Task.FromResult("Chuck Norris roundhouse kicked this fact."));

            // Act
            var result = await _mockJokeService.Object.GetJoke(category);


            // Assert
            Assert.Equal("Chuck Norris roundhouse kicked this fact.", result);
        }

        [Theory(DisplayName = "Failure - GetJoke")]
        [InlineData("animal")]
        [InlineData("career")]
        [InlineData("celebrity")]
        [InlineData("dev")]
        [InlineData("explicit")]
        public async Task Failure_GetJoke(string category)
        {

            // Arrange
            _mockJokeService.Setup(x => x.GetJoke(category)).Throws(new Exception("Failure"));

            // Act
            var resultException = await Record.ExceptionAsync(async () => await _mockJokeService.Object.GetJoke(category));


            // Assert
            Assert.Equal("Failure", resultException.Message);
        }
        #endregion
    }
}
