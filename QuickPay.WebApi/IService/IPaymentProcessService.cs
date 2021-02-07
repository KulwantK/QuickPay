using QuickPay.WebApi.Models;
using System.Threading.Tasks;

namespace QuickPay.WebApi.IService
{
    public interface IPaymentProcessService
    {
        bool IsValidRequest(PaymentResponseModel responseModel);
        Task<PaymentResponseModel> ProcessPayment(PaymentDto payemntDto);
    }
}
