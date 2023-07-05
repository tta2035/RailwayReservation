using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace RailwayReservation.Application.SeatType.Commands
{
    public class UpdateSeatTypeCommand : IRequest<int>
    {
        public Guid Id { get; set; }

        public string SeatTypeName { get; set; }

        public double RaitoFare { get; set; }

        public string? Description { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public UpdateSeatTypeCommand(Guid id, string seatTypeName, double raitoFare, string? description, Guid? updateBy, DateTime? updateTime)
        {
            Id = id;
            SeatTypeName = seatTypeName;
            RaitoFare = raitoFare;
            Description = description;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
        }
    }
}