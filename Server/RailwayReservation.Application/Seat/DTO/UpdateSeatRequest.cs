using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Seat.DTO
{
    public class UpdateSeatRequest
    {
        public Guid Id { get; set; }

        public Guid CoachId { get; set; }

        public Guid SeatTypeId { get; set; }

        public string SeatNo { get; set; }

        public string? Description { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public UpdateSeatRequest(
            Guid id,
            Guid coachId,
            Guid seatTypeId,
            string seatNo,
            string? description,
            Guid? updateBy,
            DateTime? updateTime
        )
        {
            Id = id;
            CoachId = coachId;
            SeatTypeId = seatTypeId;
            SeatNo = seatNo;
            Description = description;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
        }
    }
}
