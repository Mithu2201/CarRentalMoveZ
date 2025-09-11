namespace CarRentalMoveZ.DTOs
{
    public class DriverDTO
    {
        public int DriverId { get; set; }

        public int UserId { get; set; } // Optional, if you need to link back to User

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string LicenseNo { get; set; }

        public string Status { get; set; } // Active / Inactive / Suspended

        public string Role { get; set; } = "Driver"; // Always Driver
    }
}
