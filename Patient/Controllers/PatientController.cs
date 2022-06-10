using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoronaApp.Services.Models;
using CoronaApp.Services.Interface;
using System.Text.Json;

namespace CoronaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _context;
        private readonly ILogger<PatientController> _logger;

        public PatientController(IPatientRepository context, ILogger<PatientController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet("GetPatientById {id}")]
        public async Task<Patient> GetPatientById(int id)
        {
            try
            {
                _logger.LogInformation(message: "Get Patient By Id");
                return await _context.Get(id);

            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Get Patient By Id {id}");
                throw;
            }

        }
        [HttpGet("GetAllPatients")]
        public async Task<List<Patient>> GetAllPatients()
        {
            try
            {
                _logger.LogInformation(message: "Get All Patients");
                return await _context.Get();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Get All patients faild");
                throw;
            }

        }

        [HttpPost]
        public async Task<bool> Post(Location location, int id)
        {
            try
            {
                _logger.LogInformation(message: "Post");
                await _context.SaveNewLocation(new Patient() { Location = new List<Location>() { location }, ID = id });
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"create new patient faild");
                throw;
            }


        }
    }
}
