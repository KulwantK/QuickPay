using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuickPay.Common.Constants;
using QuickPay.Domain.Entities;
using QuickPay.Repository.IRepository;
using QuickPay.WebApi.IService;
using QuickPay.WebApi.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace QuickPay.WebApi.Service
{
    public class PaymentProcessService : IPaymentProcessService
    {
        private readonly IRepositoryService<Payment> repositoryService;
        private readonly IMapper mapper;
        public PaymentProcessService(IRepositoryService<Payment> repositoryService,IMapper mapper)
        {
            this.repositoryService = repositoryService;
            this.mapper = mapper;
        }
        public bool IsValidRequest(PaymentResponseModel paymentResponse)
        {
            if(string.IsNullOrWhiteSpace(paymentResponse.CreditCardNumber))
            {
                paymentResponse.Errors.Add("credit card number please");
            }
            if (string.IsNullOrWhiteSpace(paymentResponse.CardHolder))
            {
                paymentResponse.Errors.Add("credit card number please");
            }
            if(paymentResponse.ExpirationDate<DateTime.Today)
            {
                paymentResponse.Errors.Add("please make sure card is not expired");
            }
            if(paymentResponse.Amount<=0.0M)
            {
                paymentResponse.Errors.Add("enter valid amount please");
            }
            return paymentResponse.Errors.Any();
        }

        public async Task<PaymentResponseModel> ProcessPayment(PaymentDto payemntDto)
        {
            //repositoryService.Update
            //    (
            //    new Payment
            //    {
            //        Id = 2,
            //        CreditCardNumber = "12-12-12-12",
            //        ExpirationDate = DateTime.Now.AddDays(100),
            //        SecurityCode = "123",
            //        Amount = 123.321M,
            //        CardHolder = "Updated Card Holder 123",
            //        PaymentState = new PaymentState { Id = 1, PaymentId = 1, Status = PaymentStatus.Processed }
            //    });


            var result = await repositoryService.All();

            var result1 = await repositoryService.Where(x => x.Id == 2);

            var test = repositoryService.Table;
            //var result =mapper.Map<PaymentDto>(await repositoryService.All());
            return mapper.Map<PaymentResponseModel>(new PaymentResponseModel());
        }
    }
}
