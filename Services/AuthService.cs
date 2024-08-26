using Microsoft.EntityFrameworkCore;
using PHRecord.Context;
using PHRecord.Models;
using PHRecord.Models.DTO;

namespace PHRecord.Services
{
    public class AuthService
    {
        private PhrDbContext phrDbContext;

        public AuthService(PhrDbContext _context)
        {
            phrDbContext = _context;
        }

        public async Task<ResponseDTO> login(string userName, string password)
        {
            ResponseDTO responseDTO = new ResponseDTO { isSuccess = false, message = "Failed!", status = System.Net.HttpStatusCode.Unauthorized };

            try
            {
                var userInfo = await Task.FromResult((from L in phrDbContext.LoginCreds
                                                      where L.UserName == userName && L.LoginPassword == password && L.IsActive == true
                                                      join U in phrDbContext.UserInfos on L.UserId equals U.UserId
                                                      where U.IsActive == true
                                                      select new
                                                      {
                                                          U.UserId,
                                                          U.FullName,
                                                          U.ContctNo,
                                                          U.Address,
                                                          U.EmailAddress,
                                                          U.FatherName,
                                                          U.MotherName,
                                                          U.BloodGroup,
                                                          U.GenderId,
                                                          U.DateOfBirth,
                                                          Gender = (U.GenderId == 1) ? "Male" : "Female",
                                                          UserType = (U.UserType == 1) ? "Patient" : "Doctor",
                                                          U.RegistrationTime,
                                                          U.IdentificationNo,
                                                          U.IdentificationTypeId,
                                                      }).FirstOrDefault());

                if (userInfo != null)
                {
                    responseDTO = new ResponseDTO
                    {
                        data = userInfo,
                        isSuccess = true,
                        message = "Login successful",
                        status = System.Net.HttpStatusCode.OK
                    };
                }
                else
                {
                    responseDTO = new ResponseDTO
                    {
                        isSuccess = false,
                        message = "Wrong credential!",
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


        public async Task<ResponseDTO> register(RegistrationDTO registrationDTO)
        {
            ResponseDTO responseDTO = new ResponseDTO { isSuccess = false, message = "Failed!", status = System.Net.HttpStatusCode.Unauthorized };
            try
            {
                registrationDTO.userInfo.IsActive = true;

                await phrDbContext.UserInfos.AddAsync(registrationDTO.userInfo);
                int effectedrows = await phrDbContext.SaveChangesAsync();

                LoginCred loginCred = new LoginCred
                {
                    UserName = registrationDTO.userInfo.EmailAddress,
                    LoginPassword = registrationDTO.password,
                    UserId = registrationDTO.userInfo.UserId,
                    IsActive = true
                };

                await phrDbContext.LoginCreds.AddAsync(loginCred);
                effectedrows = await phrDbContext.SaveChangesAsync();


                if (effectedrows > 0)
                {
                    responseDTO = new ResponseDTO
                    {
                        isSuccess = true,
                        message = "Registration successful",
                        status = System.Net.HttpStatusCode.OK
                    };
                }
                else
                {
                    responseDTO = new ResponseDTO
                    {
                        isSuccess = false,
                        message = "Registration failed!",
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
