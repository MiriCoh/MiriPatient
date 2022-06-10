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

namespace CoronaApp.Test
{

    public class PatientControllerTest : IClassFixture<WebApplicationFactory<LocationController>>
    {

        [Fact]
        public async void AddPatientTest()
        {
            var PatientRepositoryMock = new Mock<IPatientRepository>();
            var mockPatient = new Mock<Patient>();
            PatientRepositoryMock.Setup(p => p.SaveNewLocation(mockPatient.Object)).Returns(Task.FromResult(true));
            var controller = new PatientController(PatientRepositoryMock.Object, NullLogger<PatientController>.Instance);
            Location l = new Location()
            {
                City = "Elad",
                Description = "park",
                EndDate = new DateTime(),
                StartDate = new DateTime()
            };
            var mockID = 123;
            Task<bool> result = controller.Post(l, mockID);
            Assert.True(result.Result == true);
        }
    }
}
