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

                if (areaMappings != null)
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
                                                                            HospitalId =  H.HospitalId,
                                                                            HospitalName = H.HospitalName,
                                                                            HospitalAddress = H.HospitalAddress,
                                                                            ContactNo = H.ContactNo,
                                                                            NoOfSeat = H.NoOfSeat,
                                                                            BookedSeat = H.BookedSeat,
                                                                        }).ToList());

                if (hospitals != null)
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


        public async Task<ResponseDTO> uploadFiles(FileUploadDTO fileUploadDTO)
        {
            ResponseDTO responseDTO = new ResponseDTO { isSuccess = false, message = "Failed!", status = System.Net.HttpStatusCode.Unauthorized };

            try
            {
                

                if (hospitals != null)
                {
                    responseDTO = new ResponseDTO
                    {
                        data = hospitals,
                        isSuccess = true,
                        message = "File upload successful",
                        status = System.Net.HttpStatusCode.OK
                    };
                }
                else
                {
                    responseDTO = new ResponseDTO
                    {
                        isSuccess = false,
                        message = "Failed to upload file!",
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
