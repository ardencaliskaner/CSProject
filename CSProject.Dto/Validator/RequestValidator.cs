using CSProject.Dto.ApiModel.Request;
using FluentValidation;

namespace CSProject.Dto.Validator
{
    public class RequestValidator : AbstractValidator<ProductStockRequestModel>
    {
        public RequestValidator()
        {
            RuleFor(x => x.ProductId).NotNull().WithMessage("Ürün Seçimi Yapılmalıdır !");
        }
    }
}
