using System;
using System.Collections.Generic;

namespace Railway.API.Models;

public partial class Station
{
    public int StationId { get; set; }

    public string StationName { get; set; } = null!;

    public string? Description { get; set; }

    public int CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public virtual ICollection<Route> RouteDepartureStationNavigations { get; set; } = new List<Route>();

    public virtual ICollection<Route> RouteDestinationStationNavigations { get; set; } = new List<Route>();
}
