namespace PHRecord.Models.DTO
{
    public class FileUploadDTO
    {

        public long userId { get; set; }
        public string fileName { get; set; }
        public string fileDescription { get; set; }
        public string base64File { get; set; }
        public string fileType { get; set; }
        public int docTypeId { get; set; }
    }
}
