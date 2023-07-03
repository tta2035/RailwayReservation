using RailwayReservation.Application.Common.DTOs;
using RailwayReservation.Domain.Passenger;

namespace RailwayReservation.Application.Common.Interfaces.Persistences;

public interface IPassengerRepository: IGenericRepository<Passenger, PassengerDto>
{
    Passenger? First();
    Task<Passenger?> GetPassengerLogin(LoginDto dto);
    Task<bool> CheckEmailExistAsync(string email);
    Task<bool> CheckEmailPhoneNoAsync(string phoneNo);
    string CheckPasswordStrength(string password);
}
