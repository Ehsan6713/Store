using FluentValidation;
using Store.Application.Contracts.Persistence;

namespace Store.Application.DTOS.OrderDetail.Validations
{
    public class IOrderDetailDtoValidator : AbstractValidator<IOrderDetailDto>
    {
        private readonly IProductRepository _productRepository;

        public IOrderDetailDtoValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("{PropertyName} is required")
                .MustAsync(ProductIdExists).WithMessage("Product not found")
                .MustAsync(CheckStock).WithMessage("Stock is Zero");
            RuleFor(x => x.UnitPrice).GreaterThan(0).WithMessage("{PropertyName} can not be Less than 1");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("{PropertyName} can not be Less than 1");
            RuleFor(x => x.Discount).GreaterThan(-1).WithMessage("{PropertyName} can not be Negative");
        }

        private async Task<bool> ProductIdExists(int id, CancellationToken token)
        {
            return !(await _productRepository.Exist(id));
        }
        private async Task<bool> CheckStock(int id, CancellationToken token)
        {
            var product = await _productRepository.Get(id);
            if (product.Stock == 0)
                return true;
            return false;
        }
    }
}
