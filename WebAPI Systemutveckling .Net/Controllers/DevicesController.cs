using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Systemutveckling_.Net.Helpers;
using WebAPI_Systemutveckling_.Net.Models;
using WebAPI_Systemutveckling_.Net.Repositories;

namespace WebAPI_Systemutveckling_.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceManager _deviceManager;

        public DevicesController(IDeviceManager deviceManager)
        {
            _deviceManager = deviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return new OkObjectResult(await _deviceManager.GetDevicesAsync());
        }

        [HttpGet("{id")]
        public async Task<IActionResult> GetOne(string id)
        {
            var device = await _deviceManager.GetDeviceAsync(id);
            return device != null ? new OkObjectResult(device) : new NotFoundResult();
        }

        [HttpPost]
        [UseApiKey]
        public async Task<IActionResult> CreateOne(DeviceRequest device)
        {
            var key = await _deviceManager.CreateDeviceAsync(device.Id);
            return key != null ? new OkObjectResult(key) : new BadRequestResult();
        }

        [HttpDelete("{id}")]
        [UseApiKey]
        public async Task<IActionResult> DeleteOne(string id)
        {
            var result = await _deviceManager.DeleteDeviceAsync(id);
            return result ? new OkResult() : new BadRequestResult();
        }
    }
}
