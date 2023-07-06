using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Ticket.DTO;
using RailwayReservation.Domain.Route;
using RailwayReservation.Domain.Ticket;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class TicketRepository
        : GenericRepository<Domain.Ticket.Ticket, TicketResponse>,
            ITicketRepository
    {
        public TicketRepository(RailwayReservationDbContext context) : base(context)
        {
        }

        public override async Task<List<TicketResponse>> GetAll()
        {
            var result = await (from ticket in table
                          join trip in _context.Trips on ticket.TripId equals trip.Id
                          join route in _context.Routes on trip.RouteId equals route.Id
                          join seat in _context.Seats on ticket.SeatId equals seat.Id
                          join st in _context.SeatTypes on seat.SeatTypeId equals st.Id
                          join coach in _context.Coaches on seat.CoachId equals coach.Id
                          join train in _context.Trains on coach.TrainId equals train.Id
                          select new TicketResponse()
                          {
                              Id = ticket.Id,
                              TripId = ticket.TripId,
                              SeatId = ticket.SeatId,
                              SeatNo = seat.SeatNo,
                              SeatTypeName = st.SeatTypeName,
                              TrainNo = train.TrainName,
                              RouteId = route.Id,
                              RouteName = route.RouteName,
                              DepartureStation = "",
                              DestinationStation = "",
                              DepartureTime = trip.DepartureTime,
                              ArriveTime = trip.ArriveTime,
                              Fare = ticket.Fare,
                              Description = ticket.Description,
                              CreateBy = ticket.CreateBy,
                              CreateTime = ticket.CreateTime,
                              UpdateBy = ticket.UpdateBy,
                              UpdateTime = ticket.UpdateTime,
                              Status = ticket.Status
                          }).ToListAsync();
            foreach(var item in result)
            {
                var dep = (from route in _context.Routes
                           join station in _context.Stations on route.DepartureStation equals station.Id
                           where route.Id == item.RouteId
                           select new {
                               StationName = station.StationName
                           }).Single();
                item.DepartureStation = dep.StationName;

                var des = (from route in _context.Routes
                           join station in _context.Stations on route.DestinationStation equals station.Id
                           where route.Id == item.RouteId
                           select new
                           {
                               StationName = station.StationName
                           }).Single();
                item.DestinationStation = des.StationName;
            }
            return result;
        }

        public Task<List<TicketResponse>> GetByBooking(Guid bookingId)
        {
            
            throw new NotImplementedException();
        }

        public override async Task<TicketResponse?> GetResponseById(Guid id)
        {
            var list = await GetAll();
            return list.Where(e => e.Id == id).Single();
        }
    }
}
