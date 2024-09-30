namespace PHRecord.Models.DTO
{
    public class RegistrationDTO
    {
        public string? FullName { get; set; }
        public string? EmailAddress { get; set; }
        public string? ContctNo { get; set; }
        public string? Address { get; set; }
        public int? GenderId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? BloodGroup { get; set; }
        public string? IdentificationNo { get; set; }
        public string? IdentificationTypeId { get; set; }
        public string password { get; set; }
    }
}
