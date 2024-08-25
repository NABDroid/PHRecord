using System;
using System.Collections.Generic;

namespace PHRecord.Models;

public partial class Hospital
{
    public int HospitalId { get; set; }

    public string HospitalName { get; set; } = null!;

    public int DistrictId { get; set; }

    public int DivisionId { get; set; }

    public int UnionId { get; set; }

    public string? HospitalAddress { get; set; }

    public int? NoOfSeat { get; set; }

    public int? BookedSeat { get; set; }

    public string? ContactNo { get; set; }

    public bool IsActive { get; set; }
}
