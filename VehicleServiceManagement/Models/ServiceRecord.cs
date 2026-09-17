using System.ComponentModel.DataAnnotations;

namespace VehicleServiceManagement.Models
{
    public class ServiceRecord
    {
        public int ServiceRecordId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a vehicle")]
        public int VehicleId { get; set; }

        [Required(ErrorMessage = "Service Type  is required")]
        [StringLength(50, ErrorMessage = "Service Type cannot exceed 50 characters")]
        public string ServiceType { get; set; } = string.Empty;

        //optional
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Service date is required")]
        public DateTime ServiceDate { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Cost must be greater than 0")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; } = string.Empty;

        public Vehicle Vehicle { get; set; }
    }
}
