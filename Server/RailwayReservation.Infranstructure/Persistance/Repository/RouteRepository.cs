using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Route.DTO;
using RailwayReservation.Domain.Route;
using Microsoft.EntityFrameworkCore;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class RouteRepository : GenericRepository<Route, RouteResponse>, IRouteRepository
    {
        public RouteRepository(RailwayReservationDbContext context) : base(context)
        {
            
        }
        public override async Task<List<RouteResponse>> GetAll()
        {
            List<RouteResponse> list = new List<RouteResponse>();
            try
            {
                var result = await (
                                from route in table
                                join depStation in _context.Stations.AsEnumerable() on route.DepartureStation equals depStation.Id
                                join desStation in _context.Stations.AsEnumerable() on route.DestinationStation equals desStation.Id
                                // select new { Id  = route.Id,
                                //              RouteName = route.RouteName}
                                
                                select new RouteResponse(
                                        route.Id,
                                        route.RouteName,
                                        depStation.Id,
                                        depStation.StationName,
                                        desStation.Id,
                                        desStation.StationName,
                                        route.RouteFare,
                                        route.Description,
                                        route.CreateBy,
                                        route.CreateTime,
                                        route.UpdateBy,
                                        route.UpdateTime
                                )
                                
                            ).ToListAsync();
                //foreach(var item in result)
                //{
                //    list.Add( item );
                //}
                return result;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<RouteResponse> getRouteResponse(Guid id)
        {
            var result = (
                from route in base.table
                join depStation in _context.Stations on route.DepartureStation equals depStation.Id
                join desStation in _context.Stations on route.DepartureStation equals desStation.Id
                where route.Id == id
                select new RouteResponse(
                    route.Id,
                        route.RouteName,
                        depStation.Id,
                        depStation.StationName,
                        desStation.Id,
                        desStation.StationName,
                        route.RouteFare,
                        route.Description,
                        route.CreateBy,
                        route.CreateTime,
                        route.UpdateBy,
                        route.UpdateTime
                )
            ).Single();
            return result;
        }

        public override Task<Route?> getById(Guid id)
        {
            return base.getById(id);
        }
    }
}
