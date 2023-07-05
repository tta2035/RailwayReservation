using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Application.Coach.DTO;
using RailwayReservation.Domain.Coach;

namespace RailwayReservation.Application.Train.DTO
{
    public class TrainResponse
    {
        public Guid Id { get; set; }
        public string TrainName { get; set; } = null!;

        public string? Description { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime CreateTime { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }
        public int CoachQuantity { get; set; }
        public int SeatQuantity { get; set; }
        public List<CoachResponse> Coaches { get; set; } = new();
    }
}
