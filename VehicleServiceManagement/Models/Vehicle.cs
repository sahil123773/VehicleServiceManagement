using System.ComponentModel.DataAnnotations;

namespace VehicleServiceManagement.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a customer")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Vehicle number is required")]
        [StringLength(15, ErrorMessage = "Vehicle number cannot exceed 15 characters")]
        public string VehicleNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Brand is required")]
        [StringLength(50, ErrorMessage = "Brand cannot exceed 50 characters")]
        public string Brand { get; set; } = string.Empty;

        [Required(ErrorMessage = "Model is required")]
        [StringLength(50, ErrorMessage = "Model cannot exceed 50 characters")]
        public string Model { get; set; } = string.Empty;

        public Customer? Customer { get; set; }

        public ICollection<ServiceRecord> ServiceRecords { get; set; } = new List<ServiceRecord>();
    }
}
