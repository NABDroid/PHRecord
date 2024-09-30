using PHRecord.Context;
using PHRecord.Models;
using PHRecord.Models.DTO;

namespace PHRecord.Services
{
    public class GlobalService
    {

        private PhrDbContext phrDbContext;

        public GlobalService(PhrDbContext _context)
        {
            phrDbContext = _context;
        }

        public async Task<ResponseDTO> allAreas()
        {
            ResponseDTO responseDTO = new ResponseDTO { isSuccess = false, message = "Failed!", status = System.Net.HttpStatusCode.Unauthorized };

            try
            {
                List<AreaMapping> areaMappings = await Task.FromResult((from A in phrDbContext.AreaMappings
                                                                        where A.IsActive == true
                                                                        select new AreaMapping

                                                                        {
                                                                            AreaId = A.AreaId,
                                                                            AreaName = A.AreaName,
                                                                            ParentId = A.ParentId,
                                                                            AreaTypeId = A.AreaTypeId,
                                                                            CurrentPopulation = A.CurrentPopulation,
                                                                        }).ToList());

                if (areaMappings.Count > 0)
                {
                    responseDTO = new ResponseDTO
                    {
                        data = areaMappings,
                        isSuccess = true,
                        message = "Area map",
                        status = System.Net.HttpStatusCode.OK
                    };
                }
                else
                {
                    responseDTO = new ResponseDTO
                    {
                        isSuccess = false,
                        message = "No area map found!",
                        status = System.Net.HttpStatusCode.Unauthorized
                    };
                }

            }
            catch (Exception ex)
            {
                responseDTO = new ResponseDTO
                {
                    isSuccess = false,
                    message = "Failed!",
                    status = System.Net.HttpStatusCode.Unauthorized
                };
            }

            return responseDTO;
        }

        public async Task<ResponseDTO> hospitals(int divisionId, int districtId, int unionId)
        {
            ResponseDTO responseDTO = new ResponseDTO { isSuccess = false, message = "Failed!", status = System.Net.HttpStatusCode.Unauthorized };

            try
            {
                List<Hospital> hospitals = await Task.FromResult((from H in phrDbContext.Hospitals
                                                                  where H.IsActive == true && (H.DivisionId == divisionId || divisionId == 0) &&
                                                                  (H.DistrictId == districtId || districtId == 0) && (H.UnionId == unionId || unionId == 0)
                                                                  select new Hospital
                                                                  {
                                                                      HospitalId = H.HospitalId,
                                                                      HospitalName = H.HospitalName,
                                                                      HospitalAddress = H.HospitalAddress,
                                                                      ContactNo = H.ContactNo,
                                                                      NoOfSeat = H.NoOfSeat,
                                                                      BookedSeat = H.BookedSeat,
                                                                  }).ToList());

                if (hospitals.Count > 0)
                {
                    responseDTO = new ResponseDTO
                    {
                        data = hospitals,
                        isSuccess = true,
                        message = "Hospitals",
                        status = System.Net.HttpStatusCode.OK
                    };
                }
                else
                {
                    responseDTO = new ResponseDTO
                    {
                        isSuccess = false,
                        message = "No hospital found!",
                        status = System.Net.HttpStatusCode.Unauthorized
                    };
                }

            }
            catch (Exception ex)
            {
                responseDTO = new ResponseDTO
                {
                    isSuccess = false,
                    message = "Failed!",
                    status = System.Net.HttpStatusCode.Unauthorized
                };
            }

            return responseDTO;
        }

        public async Task<ResponseDTO> uploadFiles(List<FileUploadDTO> fileUploadDTO)
        {
            ResponseDTO responseDTO = new ResponseDTO { isSuccess = false, message = "Failed!", status = System.Net.HttpStatusCode.Unauthorized };

            try
            {


                for (int i = 0; i < fileUploadDTO.Count; i++)
                {
                    Document document = new Document
                    {

                        UserId = fileUploadDTO[i].userId,
                        DocumentTitle = fileUploadDTO[i].fileName,
                        DocumentDescription = fileUploadDTO[i].fileDescription,
                        MainDocument = fileUploadDTO[i].base64File,
                        FileType = fileUploadDTO[i].fileType,
                        DocTypeId = fileUploadDTO[i].docTypeId,
                    };

                    await phrDbContext.Documents.AddAsync(document);
                }





                int effectedrows = await phrDbContext.SaveChangesAsync();

                if (effectedrows > 0)
                {
                    responseDTO = new ResponseDTO
                    {
                        isSuccess = true,
                        message = "upload successful!",
                    };
                }



            }
            catch (Exception ex)
            {
                responseDTO = new ResponseDTO
                {
                    isSuccess = false,
                    message = "Failed!",
                };
            }

            return responseDTO;
        }


        public async Task<ResponseDTO> getDocumentList(int userId)
        {

            ResponseDTO responseDTO = new ResponseDTO { isSuccess = false, message = "Failed!", status = System.Net.HttpStatusCode.Unauthorized };

            try
            {
                var documents = await Task.FromResult((from D in phrDbContext.Documents
                                                                  where D.UserId == userId && D.IsActive == true
                                                                  join DT in phrDbContext.DocumentTypes on D.DocTypeId equals DT.DocTypeId
                                                                  select new 
                                                                  {
                                                                       D.DocumentId,
                                                                       D.DocumentTitle,
                                                                       D.DocumentDescription,
                                                                       DT.DocType,
                                                                  }).ToList());

                if (documents.Count > 0)
                {
                    responseDTO = new ResponseDTO
                    {
                        data = documents,
                        isSuccess = true,
                        message = "All documents of " + userId,
                        status = System.Net.HttpStatusCode.OK
                    };
                }
                else
                {
                    responseDTO = new ResponseDTO
                    {
                        isSuccess = false,
                        message = "No document found!",
                        status = System.Net.HttpStatusCode.Unauthorized
                    };
                }

            }
            catch (Exception ex)
            {
                responseDTO = new ResponseDTO
                {
                    isSuccess = false,
                    message = "Failed!",
                    status = System.Net.HttpStatusCode.Unauthorized
                };
            }

            return responseDTO;

        }


        public async Task<ResponseDTO> getDocumentById(int documentId)
        {

            ResponseDTO responseDTO = new ResponseDTO { isSuccess = false, message = "Failed!", status = System.Net.HttpStatusCode.Unauthorized };

            try
            {
                var document = await Task.FromResult((from D in phrDbContext.Documents
                                                           join DT in phrDbContext.DocumentTypes on D.DocTypeId equals DT.DocTypeId
                                                           where D.DocumentId == documentId && D.IsActive == true
                                                           select new
                                                           {
                                                                D.DocumentId,
                                                                D.DocumentTitle,
                                                                D.DocumentDescription,
                                                                D.MainDocument,
                                                                D.FileType,
                                                                D.FileDate,
                                                                DT.DocType

                                                           }).FirstOrDefault());

                if (document != null)
                {
                    responseDTO = new ResponseDTO
                    {
                        data = document,
                        isSuccess = true,
                        message = "Document of " + documentId,
                        status = System.Net.HttpStatusCode.OK
                    };
                }
                else
                {
                    responseDTO = new ResponseDTO
                    {
                        isSuccess = false,
                        message = "No document found!",
                        status = System.Net.HttpStatusCode.Unauthorized
                    };
                }

            }
            catch (Exception ex)
            {
                responseDTO = new ResponseDTO
                {
                    isSuccess = false,
                    message = "Failed!",
                    status = System.Net.HttpStatusCode.Unauthorized
                };
            }

            return responseDTO;

        }

    }
}
