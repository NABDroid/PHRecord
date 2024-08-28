namespace PHRecord.Models.DTO
{
    public class FileUploadDTO
    {

        public long? userId { get; set; }
        public string? fileName { get; set; }
        public string? fileDescription { get; set; }
        public byte[]? base64File { get; set; }
        public string? fileTuyp { get; set; }
        public int? docTypeId { get; set; }
    }
}
