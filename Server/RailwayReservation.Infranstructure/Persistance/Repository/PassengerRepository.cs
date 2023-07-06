using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RailwayReservation.Application.Common.DTOs;
using RailwayReservation.Application.Common.Interfaces;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Domain.Common.Errors;
using RailwayReservation.Domain.Passenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RailwayReservation.Infranstructure.Persistance.Repository;

public class PassengerRepository : GenericRepository<Passenger, PassengerDto>, IPassengerRepository
{
    private List<Passenger> _passengers;
    private List<PassengerDto> _passengersDto;

    public PassengerRepository(RailwayReservationDbContext context)
        : base(context) { 
        _passengers = new();
        _passengersDto = new();
    }

    public override async Task<Passenger?> getById(Guid id)
    {
        var s = await base.table.FirstOrDefaultAsync(t => t.Id == id);
        return s;
    }

    public override async Task<List<PassengerDto>> GetAll()
    {
        _passengers = await base.table.ToListAsync();
        foreach(var passenger in _passengers)
        {
            _passengersDto.Add(new PassengerDto(passenger));
        }
        return _passengersDto;
    }

    public Passenger? First()
    {
        return base.table.FirstOrDefault<Passenger>();
    }

    public async Task<bool> CheckEmailExistAsync(string email)
    {
        return await base.table.AnyAsync(x => x.Email == email);
    }

    public async Task<bool> CheckEmailPhoneNoAsync(string phoneNo)
    {
        return await base.table.AnyAsync(x => x.PhoneNo == phoneNo);
    }

    public string CheckPasswordStrength(string password)
    {
        StringBuilder sb = new StringBuilder();
        if (password.Length < 8)
        {
            sb.Append("Minimun password length should be 8 " + Environment.NewLine);
        }
        if (
            !(
                Regex.IsMatch(password, "[a-z]")
                && Regex.IsMatch(password, "[A-Z]")
                && Regex.IsMatch(password, "[0-9]")
            )
        )
        {
            sb.Append("Password should be Alphanumberic " + Environment.NewLine);
        }
        char[] special =
        {
            '<',
            '>',
            '@',
            '!',
            '#',
            '$',
            '%',
            '^',
            '&',
            '*',
            '(',
            ')',
            '_',
            '+',
            '[',
            ']',
            '{',
            '}',
            ':',
            ';',
            '|',
            '\\',
            '.',
            '/',
            '-',
            '='
        };
        if (password.IndexOfAny(special) == -1)
        {
            sb.Append("Password should have special chars" + Environment.NewLine);
        }
        //var check = Regex.IsMatch(password, @"/.[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]/");
        return sb.ToString();
    }

    public async Task<Passenger?> GetPassengerLogin(LoginDto dto)
    {
        return await base.table.FirstOrDefaultAsync(
            p => p.Email == dto.Email && p.Password == dto.Password
        );
    }
}
