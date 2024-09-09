using System;
using System.Collections.Generic;

namespace PHRecord.Models;

public partial class DoctorsVisitingHour
{
    public long MappingId { get; set; }

    public long DoctorId { get; set; }

    public int HospitalId { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public string? OffDays { get; set; }

    public bool IsActive { get; set; }
}
