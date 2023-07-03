using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using Microsoft.EntityFrameworkCore;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Station.DTO;
using RailwayReservation.Domain.Station;
using RailwayReservation.Domain.Station.ValueObjects;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class StationRepository
        : GenericRepository<Domain.Station.Station, StationResponse>,
            IStationRepository
    {
        public StationRepository(RailwayReservationDbContext context)
            : base(context) { }

        public override async Task<List<StationResponse>> GetAll()
        {
            List<StationResponse> list = new List<StationResponse>();
            try
            {
                var result = await (
                    from station in table
                        //join route in _context.Routes.AsEnumerable() on station.Id equals route.DepartureStation
                    select new StationResponse(
                        station.Id,
                        station.StationName,
                        station.Description,
                        station.CreateBy,
                        station.CreateTime,
                        station.UpdateBy,
                        station.UpdateTime,
                        _context.Routes.Count(route => route.DepartureStation == station.Id || route.DestinationStation == station.Id)
                        )
                        ).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        public override async Task<StationResponse?> GetResponseById(Guid id)
        {
            try
            {
                var result = await (
                    from station in table
                        //join route in _context.Routes.AsEnumerable() on station.Id equals route.DepartureStation
                    where station.Id == id
                    select new StationResponse(
                        station.Id,
                        station.StationName,
                        station.Description,
                        station.CreateBy,
                        station.CreateTime,
                        station.UpdateBy,
                        station.UpdateTime,
                        _context.Routes.Count(route => route.DepartureStation == station.Id || route.DestinationStation == station.Id)
                        )
                        ).SingleAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }
    }
}
