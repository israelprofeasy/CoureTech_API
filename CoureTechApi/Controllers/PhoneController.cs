using CoureTechApi.DataServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CoureTechApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneNumberDetailService _numberService;

        public PhoneController(IPhoneNumberDetailService numberService)
        {
            _numberService = numberService;
        }
        [HttpGet("get-number-details")]
        public IActionResult GetPhoneNumberDetails(string phoneNumber)
        {
            if (String.IsNullOrWhiteSpace(phoneNumber))
            {
                return BadRequest("You must enter a value");
            }
            if(phoneNumber.Length != 13 || !phoneNumber.All(char.IsDigit))
            {
                return BadRequest("Phone number must contain only 13 digits");
            }
            var response = _numberService.RetreiveInformation(Int64.Parse(phoneNumber));
            return Ok(response.Result);
        }
    }
}
