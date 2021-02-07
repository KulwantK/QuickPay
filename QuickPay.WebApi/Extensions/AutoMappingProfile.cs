using AutoMapper;
using QuickPay.Domain.Entities;
using QuickPay.WebApi.Models;

namespace QuickPay.WebApi.Extensions
{
    public class AutoMappingProfile:Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<PaymentResponseModel, PaymentDto>().ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<PaymentState, PaymentStateDto>().ReverseMap();
            CreateMap<Payment, PaymentResponseModel>().ReverseMap();
        }
    }
}
