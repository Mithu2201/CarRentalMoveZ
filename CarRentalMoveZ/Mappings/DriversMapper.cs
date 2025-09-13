using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Models;

namespace CarRentalMoveZ.Mappings
{
    public class DriversMapper
    {
        public static IEnumerable<DriverDTO> ToDTOList(IEnumerable<Driver> drivers)
        {
            if (drivers == null)
                return null;

            return drivers
                .Where(d => d != null && d.User != null)
                .Select(d => new DriverDTO
                {
                    DriverId = d.DriverId,
                    UserId = d.UserId,
                    Name = d.User.Name,
                    Email = d.User.Email,
                    PhoneNumber = d.User.PhoneNumber,
                    LicenseNo = d.LicenseNo,
                    Status = d.Status,
                    Role = "Driver"
                });
        }

        public static DriverDTO ToDTO(Driver driver)
        {
            if (driver == null || driver.User == null)
                return null;

            return new DriverDTO
            {
                DriverId = driver.DriverId,
                UserId = driver.UserId,
                Name = driver.User.Name,
                Email = driver.User.Email,
                PhoneNumber = driver.User.PhoneNumber,
                LicenseNo = driver.LicenseNo,
                Status = driver.Status,
                Role = "Driver"
            };
        }

        public static IEnumerable<DriverDTO> ToAvailableDTOList(IEnumerable<Driver> drivers)
        {
            if (drivers == null)
                return Enumerable.Empty<DriverDTO>();

            return drivers.Select(d => new DriverDTO
            {
                DriverId = d.DriverId,
                UserId = d.UserId,
                // Use Driver.Name if available, otherwise fallback to User.Name
                Name = !string.IsNullOrWhiteSpace(d.Name) ? d.Name : (d.User?.Name ?? "Unknown"),
                Email = !string.IsNullOrWhiteSpace(d.Email) ? d.Email : (d.User?.Email ?? "N/A"),
                PhoneNumber = !string.IsNullOrWhiteSpace(d.PhoneNumber) ? d.PhoneNumber : (d.User?.PhoneNumber ?? "N/A"),
                LicenseNo = d.LicenseNo,
                Status = d.Status,
                Role = "Driver"
            });
        }

    }
}
