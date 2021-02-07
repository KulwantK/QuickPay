using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickPay.WebApi.IService;
using QuickPay.WebApi.Models;
using System.Threading.Tasks;

namespace QuickPay.WebApi.Controllers
{
    [Route("api/QuickPay")]
    [ApiController]
    public class PaymentProcessingApiController : ControllerBase
    {
        private readonly IPaymentProcessService processService;
        private readonly IMapper mapper;
        public PaymentProcessingApiController(IPaymentProcessService processService, IMapper mapper)
        {
            this.processService = processService;
            this.mapper = mapper;
        }
        /// <summary>
        /// api method for processing payements
        /// </summary>
        /// <param name="payemntDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentDto payemntDto)
        {

            var responseModel = mapper.Map<PaymentResponseModel>(payemntDto);
            if (processService.IsValidRequest(responseModel)||payemntDto==null|| responseModel==null)
                return StatusCode(StatusCodes.Status400BadRequest, responseModel);
            try
            {
                responseModel = await processService.ProcessPayment(payemntDto);
                return StatusCode(StatusCodes.Status200OK, responseModel);
            }
            catch
            {
                responseModel.Message = "Internal Server Error";
                responseModel.Errors.Add("invalid server error");
                responseModel.Success = false;
                return StatusCode(StatusCodes.Status500InternalServerError, responseModel);
            }
        }
    }
}
