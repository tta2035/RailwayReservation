using System;
using System.Collections.Generic;

namespace Railway.API.Models;

public partial class Route
{
    public int RouteId { get; set; }

    public string RouteName { get; set; } = null!;

    public int DepartureStation { get; set; }

    public int DestinationStation { get; set; }

    public decimal RouteFare { get; set; }

    public string? Description { get; set; }

    public int CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public virtual Station DepartureStationNavigation { get; set; } = null!;

    public virtual Station DestinationStationNavigation { get; set; } = null!;
}
