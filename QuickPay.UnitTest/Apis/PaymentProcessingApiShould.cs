using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using QuickPay.WebApi.Controllers;
using QuickPay.WebApi.IService;
using QuickPay.WebApi.Models;
using System.Threading.Tasks;
using Xunit;

namespace QuickPay.UnitTest.Apis
{
    public class PaymentProcessingApiShould
    {
        private readonly PaymentProcessingApiController paymentProcessingApiController;
        private readonly Mock<IPaymentProcessService> processService;
        private readonly Mock<IMapper> mapper;
        public PaymentProcessingApiShould()
        {
            processService = new Mock<IPaymentProcessService>();
            mapper = new Mock<IMapper>();
            paymentProcessingApiController = new PaymentProcessingApiController(processService.Object, mapper.Object);

        }
        [Fact]
        public async Task ProcessPayment_BadRequest()
        {
            //Arrange
            var payment = new PaymentDto();
            var response = new PaymentResponseModel();

            processService.Setup(x => x.IsValidRequest(response)).Returns(false);

            //Act
            var act =await paymentProcessingApiController.ProcessPayment(payment) as ObjectResult;

            //Assert
            Assert.Equal(act.StatusCode, StatusCodes.Status400BadRequest);
        }
        [Fact]
        public async Task ProcessPayment_Ok()
        {

        }
        [Fact]
        public async Task ProcessPayment_InternalServerError()
        {

        }
    }
}
