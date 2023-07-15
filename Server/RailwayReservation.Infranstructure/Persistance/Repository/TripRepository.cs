using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RailwayReservation.Application.Common.Interfaces;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Trip.DTO;
using RailwayReservation.Domain.Trip;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class TripRepository
        : GenericRepository<Domain.Trip.Trip, TripResponse>,
            ITripRepository
    {
        private readonly ITicketRepository _ticketRepository;
        public TripRepository(RailwayReservationDbContext context,
            ITicketRepository ticketRepository)
            : base(context) { 
            _ticketRepository = ticketRepository;
        }

        public override async Task<List<TripResponse>> GetAll()
        {
            try
            {
                var result = await (from trip in _context.Trips
                                    join train in _context.Trains on trip.TrainId equals train.Id
                                    join route in _context.Routes on trip.RouteId equals route.Id
                                    select new TripResponse()
                                    {
                                        Id = trip.Id,
                                        TrainId = trip.TrainId,
                                        TrainName = train.TrainName,
                                        RouteId = trip.RouteId,
                                        RouteName = route.RouteName,
                                        DepartureStation = "",
                                        DestinationStation = "",
                                        DepartureTime = trip.DepartureTime,
                                        ArriveTime =  trip.ArriveTime,
                                        Description = trip.Description == null ? "" : trip.Description,
                                        CreateBy =  trip.CreateBy,
                                        CreateTime = trip.CreateTime,
                                        UpdateBy = trip.UpdateBy,
                                        UpdateTime = trip.UpdateTime
                                    }).ToListAsync();
                
                foreach (var item in result)
                {
                    item.Tickets = (from ticket in _context.Tickets
                                    where ticket.TripId == item.Id
                                    select ticket).ToList();
                    var dep = (from route in _context.Routes
                               join station in _context.Stations on route.DepartureStation equals station.Id
                               where route.Id == item.RouteId
                               select new
                               {
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
            } catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy trip " + ex.StackTrace);
            }
        }

        public override async Task<TripResponse?> GetResponseById(Guid id)
        {
            var list = await GetAll();
            return list.Where(e => e.Id == id).Single();
        }

        public async Task<List<TripResponse>> GetTripByRouteIdAndDate(Guid routeId, DateTime searchDate)
        {
            var list = await GetAll();
            return list.Where(e => e.RouteId == routeId && e.DepartureTime.Date == searchDate.Date).ToList();
        }
    }
}
