using System;
using System.Collections.Generic;

namespace PHRecord.Models;

public partial class DoctorInfo
{
    public int UserId { get; set; }

    public string? AchievedDegrees { get; set; }

    public int? HospitalId { get; set; }

    public string? RegistrationNo { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public string? ChamberAddress { get; set; }

    public string? Universities { get; set; }

    public string? WorkTimes { get; set; }
}
