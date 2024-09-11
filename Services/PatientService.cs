using PHRecord.Context;
using PHRecord.Models.DTO;
using PHRecord.Models;

namespace PHRecord.Services
{
    public class PatientService
    {

        private PhrDbContext phrDbContext;

        public PatientService(PhrDbContext _context)
        {
            phrDbContext = _context;
        }

        public async Task<ResponseDTO> allHistoryTitles()
        {
            ResponseDTO responseDTO = new ResponseDTO { isSuccess = false, message = "Failed!", status = System.Net.HttpStatusCode.Unauthorized };

            try
            {
                List<HistoryTitle> historyTitles = await Task.FromResult((from HT in phrDbContext.HistoryTitles
                                                                        where HT.IsActive == true
                                                                        select new HistoryTitle
                                                                        {
                                                                            TitleId = HT.TitleId,
                                                                            Title = HT.Title,
                                                                        }).ToList());

                if (historyTitles.Count > 0)
                {
                    responseDTO = new ResponseDTO
                    {
                        data = historyTitles,
                        isSuccess = true,
                        message = "All history titles",
                        status = System.Net.HttpStatusCode.OK
                    };
                }
                else
                {
                    responseDTO = new ResponseDTO
                    {
                        isSuccess = false,
                        message = "No history title found!",
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



        public async Task<ResponseDTO> submitHistory(List<PatientHistory> patientHistories)
        {
            ResponseDTO responseDTO = new ResponseDTO { isSuccess = false, message = "Failed!", status = System.Net.HttpStatusCode.Unauthorized };

            try
            {
                for (int i = 0; i < patientHistories.Count; i++)
                {
                    await phrDbContext.PatientHistories.AddAsync(patientHistories[i]);
                }




                int effectedrows = await phrDbContext.SaveChangesAsync();

                if (effectedrows > 0)
                {
                    responseDTO = new ResponseDTO
                    {
                        isSuccess = true,
                        message = "added history!",
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
