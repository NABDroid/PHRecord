using System;
using System.Collections.Generic;

namespace PHRecord.Models;

public partial class UserInfo
{
    public long UserId { get; set; }

    public string? FullName { get; set; }

    public string? EmailAddress { get; set; }

    public string? ContctNo { get; set; }

    public string? Address { get; set; }

    public int? GenderId { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? BloodGroup { get; set; }

    public string? FatherName { get; set; }

    public string? MotherName { get; set; }

    public string? IsSingle { get; set; }

    public string? IdentificationNo { get; set; }

    public int? IdentificationTypeId { get; set; }

    public int? UserType { get; set; }

    public DateTime? RegistrationTime { get; set; }

    public bool IsActive { get; set; }

    public DateTime? InactiveTime { get; set; }
}
