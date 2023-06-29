using RailwayReservation.Application.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Infranstructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime utcNow => DateTime.UtcNow; 
}
