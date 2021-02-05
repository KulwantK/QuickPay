using AutoMapper;
using QuickPay.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickPay.WebApi.Extensions
{
    public class AutoMappingProfile:Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<PaymentResponseModel, PaymentDto>().ReverseMap();
        }
    }
}
