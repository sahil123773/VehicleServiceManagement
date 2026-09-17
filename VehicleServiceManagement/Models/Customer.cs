using System.ComponentModel.DataAnnotations;

namespace VehicleServiceManagement.Models
{
    public class Customer
    {
        
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(10, ErrorMessage = "Name cannot exceed 10 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^[0-9]{10}$",
            ErrorMessage = "Enter a valid 10-digit phone number")]
        public string PhoneNumber { get; set; } = string.Empty;

        public ICollection<Vehicle> Vehicles { get; set; }

    }
}
