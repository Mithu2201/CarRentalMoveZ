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
    }
}
