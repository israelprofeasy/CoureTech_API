

namespace CoureTechApi.Models.DTOs
{
    public class ResponseDTO
    {
        public string Number { get; set; }
        public CountryDto Country { get; set; } = new CountryDto();
        
    }
}
