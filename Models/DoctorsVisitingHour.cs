using System;
using System.Collections.Generic;

namespace PHRecord.Models;

public partial class DoctorsVisitingHour
{
    public int MappingId { get; set; }

    public int DoctorId { get; set; }

    public int HospitalId { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public string? OffDays { get; set; }

    public bool IsActive { get; set; }
}
