using System.ComponentModel.DataAnnotations;

namespace WebAPI_Systemutveckling_.Net.Models
{
    public class DeviceRequest
    {
        [Required]
        public string Id { get; set; } = null!;
    }
}
