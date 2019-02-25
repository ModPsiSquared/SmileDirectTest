using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SmileDirect.SpaceXProxyService.Controllers;
using SmileDirect.SpaceXProxyService.Services;
using SmileDirect.SpaceXProxyService.DTOs;
using System.Collections.Generic;
using Xunit;
using Microsoft.Extensions.Logging.Internal;
using System;

namespace SmileDirect.SpaceXProxyServiceTest
{
    public class LaunchPadServiceTests
    {      
        Mock<ILogger<SpaceXOriginalService>> _logger;
        SpaceXSettings _settings;
        ISpaceXService _service;

        public LaunchPadServiceTests()
        {
            _settings = new SpaceXSettings();
            _logger = new Mock<ILogger<SpaceXOriginalService>>();
            _service = new SpaceXOriginalService(_logger.Object, _settings);     
        }

        [Fact]
        public void Null_URL_Handled_And_Logged()
        {
            _settings.URL = string.Empty;
            _service.GetLaunchPads();

            _logger.Verify(l => l.Log(LogLevel.Error, 0, It.IsAny<FormattedLogValues>(), It.IsAny<Exception>(),
            It.IsAny<Func<object, Exception, string>>()));
        }

        [Fact]
        public void Bad_URL_Handled_And_Logged()
        {

            _logger = new Mock<ILogger<SpaceXOriginalService>>();
            _service = new SpaceXOriginalService(_logger.Object, _settings);

            _settings.URL = "asdfasdfasdf";
            _service.GetLaunchPads();

            _logger.Verify(l => l.Log(LogLevel.Error, 0, It.IsAny<FormattedLogValues>(), It.IsAny<Exception>(),
            It.IsAny<Func<object, Exception, string>>()));
        }
    }
}


