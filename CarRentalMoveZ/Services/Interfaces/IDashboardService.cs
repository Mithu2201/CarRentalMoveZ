using CarRentalMoveZ.DTOs;


namespace CarRentalMoveZ.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardDTO> GetDashboardDataAsync();
    }
}
