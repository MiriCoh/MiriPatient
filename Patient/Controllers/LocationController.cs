using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoronaApp.Services.Models;
using CoronaApp.Services.Interface;
using Microsoft.Build.Framework;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Serilog;
using NuGet.ContentModel;

namespace CoronaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private ILocationRepository _context;
        private readonly ILogger<LocationController> _logger;
        public LocationController(ILocationRepository context, ILogger<LocationController> logger)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("GetLocationByID {id}")]
        public async Task<List<Location>> GetLocationByID(int id)
        {
            try
            {
                _logger.LogInformation(message: "Get LoCation By Id");
                return await _context.Get(id);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Get Location By id {id} failed");
                throw;
            }

        }
        [HttpGet("GetLocationByCity {city}")]
        public async Task<List<Location>> GetLocationByCity(string city)
        {
            try
            {
                _logger.LogInformation(message: "Get Location By city");
                return await _context.Get(city);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Get Location By city {city} failed");
                throw;
            }
        }
        [HttpPost]
        public void Post(int id, Location location)
        {
            try
            {
                _context.Create(location, id);
                _logger.LogInformation(message: "Post LoCation sucssefully");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"create new location faild");
                throw;
            }

        }

    }
}

