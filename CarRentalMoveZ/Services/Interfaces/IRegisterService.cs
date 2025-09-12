using CarRentalMoveZ.ViewModels;

namespace CarRentalMoveZ.Services.Interfaces
{
    public interface IRegisterService   // <-- make it public
    {
        void Register(RegisterViewModel model);

        bool RegisterStaff(RegisterStaffViewModel model);

        bool RegisterDriver(RegisterDriverViewModel model);
    }
}
