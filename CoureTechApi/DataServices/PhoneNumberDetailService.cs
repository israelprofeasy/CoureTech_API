using CoureTechApi.DataAccess;
using CoureTechApi.Models.DTOs;
using System;
using System.Threading.Tasks;


namespace CoureTechApi.DataServices
{
    public class PhoneNumberDetailService : IPhoneNumberDetailService
    {
        private readonly IInMemoryRepository _repo;
        public PhoneNumberDetailService(IInMemoryRepository repo)
        {
            _repo = repo;
        }
        public Task<ResponseDTO> RetreiveInformation(long phoneNumber)
        {
            var response = new ResponseDTO();

            // var C = phoneNumber.ToString().Substring(0, 3).Select(x => int.Parse(x.ToString())).ToList();
            var countryCodeStr = phoneNumber.ToString().Substring(0, 3);
            var countryCode = int.Parse(string.Join("", countryCodeStr));
            try
            {
                var details = _repo.RetreiveDetails(countryCode).Result;
                response.Number = phoneNumber.ToString();
                response.Country.Name = details.Item1.Name;
                response.Country.CountryCode = details.Item1.CountryCode.ToString();
                response.Country.CountryIso = details.Item1.CountryIso;
                foreach (var item in details.Item2)
                {
                    response.Country.CountryDetails.Add(new CountryDetailsDto { Operator = item.Operator, OperatorCode = item.OperatorCode });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Task.FromResult(response);
        }
    }
}
