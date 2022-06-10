using Xunit;
using System;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;
using Mock;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Microsoft.AspNetCore.Routing;
using CoronaApp.Services.Models;
using CoronaApp.Services.Interface;
using CoronaApp.Api.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Serilog;
using Microsoft.Extensions.Logging.Abstractions;

namespace CoronaApp.Test1
{

    public class LocationControllerTests : IClassFixture<WebApplicationFactory<LocationController>>
    {
        [Fact]
        public async void GetPatientByIDTest()
        {
            var locationRepositoryMock = new Mock<ILocationRepository>();
            var mockID = 1223;
            var controller = new LocationController(locationRepositoryMock.Object, NullLogger<LocationController>.Instance);
            locationRepositoryMock.Setup(l => l.Get(mockID)).Returns(Task.FromResult(new List<Location>()));
            var result = await controller.GetLocationByID(mockID);
            Assert.True(result.Count == 0);
        }
        [Fact]
        public async void GetPatientByCityTest()
        {
            var locationRepositoryMock = new Mock<ILocationRepository>();
            var controller = new LocationController(locationRepositoryMock.Object, NullLogger<LocationController>.Instance);
            locationRepositoryMock.Setup(l => l.Get(String.Empty)).Returns(Task.FromResult(new List<Location>()));
            var result = await controller.GetLocationByCity("bney");
            Assert.Null(result);
        }
    }
}
