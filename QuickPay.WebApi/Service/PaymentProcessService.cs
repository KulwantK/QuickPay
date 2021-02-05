﻿using AutoMapper;
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

            return mapper.Map<PaymentResponseModel>(payemntDto);
        }
    }
}
