using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SmileDirect.SpaceXProxyService.Controllers;
using SmileDirect.SpaceXProxyService.Services;
using SmileDirect.SpaceXProxyService.DTOs;
using System.Collections.Generic;
using Xunit;


namespace SmileDirect.SpaceXProxyServiceTest
{
    public class LaunchPadControllerTests
    {      
        LaunchPadController _controller;
        Mock<ILogger<LaunchPadController>> _logger;
        ISpaceXService _service;

        public LaunchPadControllerTests()
        {
            _service = new SpaceXServiceFake();
            _logger = new Mock<ILogger<LaunchPadController>>();
            _controller = new LaunchPadController(_service, _logger.Object);
        }

        [Fact]
        public void Get_Returns_200()
        {
            var okResult = _controller.Get();
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_Returns_Data()
        {
            var okResult = _controller.Get().Result as OkObjectResult;

            var launches = Assert.IsType<List<LaunchPad>>(okResult.Value);
            Assert.Equal(3, launches.Count);
        }

        [Fact]
        public void Get_Returns_Data_by_id_When_Present()
        {
            var okResult = _controller.Get(1701).Result as OkObjectResult;

            var launch = Assert.IsType<LaunchPad>(okResult.Value);
            Assert.Equal(1701.ToString(), (okResult.Value as LaunchPad).Id);
        }

        [Fact]
        public void Get_Returns_404_by_id_When_not_Present()
        {
            var notFoundObjectResult = _controller.Get(-1).Result as NotFoundObjectResult;
            Assert.Equal(404, notFoundObjectResult.StatusCode);      
        }

    }
}

