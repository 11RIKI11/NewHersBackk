using Core.Attribute;
using Core.Model.DTO;
using Core.Model.DTO.Attendee;
using Core.Model.DTO.Payment;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace BackendApp.Controllers
{
    [ApiVersion("1.0")]
    public class PaymentsController : CustomControllerBase
    {
        private PaymentService _paymentService;
        public PaymentsController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentAddRequest request)
        {
            var result = await _paymentService.CreatePaymentAsync(request);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return OkResponse(result.Data);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetPaymentById(Guid id)
        {
            var result = await _paymentService.GetPaymentByIdAsync(id);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return OkResponse(result.Data);
        }

        [HttpGet("by-buyer/{id}")]
        public async Task<IActionResult> GetPaymentByUserId(Guid id, [FromQuery] PaginationRequest pag)
        {
            var result = await _paymentService.GetPaymentsByUserIdAsync(id, pag);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return OkResponse(result.Data);
        }

        [HttpPost("me")]
        [ValidateToken]
        public async Task<IActionResult> GetPaymentsBySelf([FromBody] PaymentSearchRequest request)
        {
            request.Filter.UserIds = new List<Guid> { UserId.Value };
            var result = await _paymentService.GetPaymentsAsync(request);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return OkResponse(result.Data);
        }

        [HttpPost("search")]
        [ValidateModel]
        public async Task<IActionResult> GetPayments([FromBody] PaymentSearchRequest request)
        {
            var result = await _paymentService.GetPaymentsAsync(request);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return OkResponse(result.Data);
        }

        [HttpPut("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdatePayment(Guid id, [FromBody] PaymentUpdateRequest request)
        {
            var result = await _paymentService.UpdatePaymentAsync(id, request);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletePayment(Guid id)
        {
            var result = await _paymentService.DeletePaymentAsync(id);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return NoContent();
        }
    }
}
