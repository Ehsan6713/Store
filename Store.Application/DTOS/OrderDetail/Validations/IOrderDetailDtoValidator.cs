using FluentValidation;
using Store.Application.Persistence.Contracts;

namespace Store.Application.DTOS.OrderDetail.Validations
{
    public class IOrderDetailDtoValidator : AbstractValidator<IOrderDetailDto>
    {
        private readonly IProductRepository productRepository;

        public IOrderDetailDtoValidator(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("{PropertyName} is required")
                .MustAsync(async (id, token) =>
                {
                    return !(await productRepository.Exist(id));
                });
            RuleFor(x => x.UnitPrice).GreaterThan(0).WithMessage("{PropertyName} can no be Less than 1");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("{PropertyName} can no be Less than 1");
            RuleFor(x => x.Discount).GreaterThan(-1).WithMessage("{PropertyName} can no be Negative");
        }
    }
}
