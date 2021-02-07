using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using QuickPay.Common.Constants;
using QuickPay.WebApi.Controllers;
using QuickPay.WebApi.IService;
using QuickPay.WebApi.Models;
using System;
using System.Threading.Tasks;
using Xunit;

namespace QuickPay.UnitTest.Apis
{
    public class PaymentProcessingApiShould
    {
        private readonly PaymentProcessingApiController mockController;
        private readonly Mock<IPaymentProcessService> mockProcessService;
        private readonly Mock<IMapper> mockMapper;
        public PaymentProcessingApiShould()
        {
            mockProcessService = new Mock<IPaymentProcessService>();
            mockMapper = new Mock<IMapper>();
            mockController = new PaymentProcessingApiController(mockProcessService.Object, mockMapper.Object);

        }
        [Fact]
        public async Task ProcessPayment_BadRequest()
        {
            //Arrange
            var paymentDto = new PaymentDto();
            var responseModel = new PaymentResponseModel();
            mockMapper.Setup(x => x.Map<PaymentResponseModel>(paymentDto)).Returns(responseModel);
            mockProcessService.Setup(service => service.IsValidRequest(responseModel)).Returns(true);

            //Act
            var act = await mockController.ProcessPayment(paymentDto) as ObjectResult;

            //Assert
            Assert.Equal(act.StatusCode, StatusCodes.Status400BadRequest);
        }
        [Fact]
        public async Task ProcessPayment_Ok()
        {
            //Arrange
            var paymentDto = new PaymentDto()
            {
                Id = 1,
                CreditCardNumber = "2204-1232-9746-5558",
                CardHolder = "James Smith",
                ExpirationDate = DateTime.Now.AddYears(1),
                SecurityCode = "331",
                Amount = 451.25M,
                State = new PaymentStateDto { PaymentId = 1, Status = PaymentStatus.Processed }
            };
            var responseModel = new PaymentResponseModel();
            mockMapper.Setup(x => x.Map<PaymentResponseModel>(paymentDto)).Returns(responseModel);
            mockProcessService.Setup(service => service.ProcessPayment(paymentDto)).Returns(Task.FromResult(responseModel));

            //Act
            var act = await mockController.ProcessPayment(paymentDto) as ObjectResult;

            //Assert
            Assert.Equal(act.StatusCode, StatusCodes.Status200OK);
        }
        [Fact]
        public async Task ProcessPayment_InternalServerError()
        {

            //Arrange
            PaymentDto paymentDto = null;
            PaymentResponseModel responseModel = null;
            mockMapper.Setup(x => x.Map<PaymentResponseModel>(paymentDto)).Returns(responseModel);
            mockProcessService.Setup(service => service.ProcessPayment(paymentDto)).Returns(Task.FromResult(responseModel));

            //Act
            var act = await mockController.ProcessPayment(paymentDto) as ObjectResult;

            //Assert
            Assert.Equal(act.StatusCode, StatusCodes.Status500InternalServerError);
        }
    }
}