using AutoMapper;
using QuickPay.Domain.Entities;
using QuickPay.Repository.IRepository;
using QuickPay.WebApi.IService;
using QuickPay.WebApi.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuickPay.WebApi.Service
{
    public class PaymentProcessService : IPaymentProcessService
    {
        private readonly IRepositoryService<Payment> repositoryService;
        private readonly ICheapPaymentGateway cheapPaymentGateway;
        private readonly IExpensivePaymentGateway expensivePaymentGateway;
        private readonly IPremiumPaymentService premiumPaymentService;
        private readonly IMapper mapper;
        public PaymentProcessService(IRepositoryService<Payment> repositoryService
            , IMapper mapper
            , ICheapPaymentGateway cheapPaymentGateway
            , IExpensivePaymentGateway expensivePaymentGateway
            , IPremiumPaymentService premiumPaymentService
            )
        {
            this.repositoryService = repositoryService;
            this.mapper = mapper;
            this.cheapPaymentGateway = cheapPaymentGateway;
            this.expensivePaymentGateway = expensivePaymentGateway;
            this.premiumPaymentService = premiumPaymentService;
        }
        public bool IsValidRequest(PaymentResponseModel paymentResponse)
        {
            if (string.IsNullOrWhiteSpace(paymentResponse.CreditCardNumber))
            {
                paymentResponse.Errors.Add("credit card number please");
            }
            if (!string.IsNullOrWhiteSpace(paymentResponse.CreditCardNumber))
            {
                //2204-1232-9746-5558, or 1111-1111-1111-1111.
                Regex regex = new Regex("^[1-9][0-9]{3}-[1-3]{4}-[0-9]{4}-[0-9]{4}$");
                var result = regex.Match(paymentResponse.CreditCardNumber);
                if (!result.Success)
                {
                    paymentResponse.Errors.Add("valid credit card number please");
                }
            }
            if (string.IsNullOrWhiteSpace(paymentResponse.CardHolder))
            {
                paymentResponse.Errors.Add("credit card number please");
            }
            if(string.IsNullOrWhiteSpace(paymentResponse.CardHolder))
            {
                paymentResponse.Errors.Add("card holder name please");
            }
            if (paymentResponse.SecurityCode.Length>3)
            {
                paymentResponse.Errors.Add("security code should have max 3 charcaters only");
            }
            if (paymentResponse.ExpirationDate < DateTime.Today)
            {
                paymentResponse.Errors.Add("please make sure card is not expired");
            }
            if (paymentResponse.Amount <= 0.0M)
            {
                paymentResponse.Errors.Add("enter valid amount please");
            }
            return paymentResponse.Errors.Any();
        }

        public async Task<PaymentResponseModel> ProcessPayment(PaymentDto payemntDto)
        {
            var responseModel = mapper.Map<PaymentResponseModel>(payemntDto);
            if (payemntDto.Amount <= 20)
            {
                Console.WriteLine("ICheapPaymentGateway");
                this.cheapPaymentGateway.ProcessCheapPayment(payemntDto, responseModel);
            }
            if (payemntDto.Amount >= 21 && payemntDto.Amount <= 500)
            {
                if (expensivePaymentGateway.IsAvailable())
                {
                    this.expensivePaymentGateway.ProcessExpensivePayment(payemntDto, responseModel);
                }
                else
                {
                    this.cheapPaymentGateway.ProcessCheapPayment(payemntDto, responseModel);
                }
            }
            if (payemntDto.Amount > 500)
            {
                int ctr = 1;
                bool isProcessed = false;
                while (ctr < 3 && !isProcessed)
                {
                    this.premiumPaymentService.ProcessPremiumPayment(payemntDto, responseModel);
                    isProcessed = responseModel.Success;
                    ctr++;
                }
            }
            //Code for Saving Processed data
            await this.repositoryService.Add(mapper.Map<Payment>(responseModel));
            
            return responseModel;
        }
    }
}