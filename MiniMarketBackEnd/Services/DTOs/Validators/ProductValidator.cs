using FluentValidation;

namespace MiniMarketBackEnd.Services.DTOs.Validators
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator(bool create)
        {
            if(create)
                RuleFor(p => p.ProductId).NotNull().Equal(0);
            else
                RuleFor(p => p.ProductId).NotNull().NotEqual(0);
            RuleFor(p => p.Description).NotEmpty().MaximumLength(500);
            RuleFor(p => p.CategoryId).NotNull();
            RuleFor(p => p.SupplierId).NotNull();
            RuleFor(p => p.Brand).NotEmpty().MaximumLength(50);
            RuleFor(p => p.Model).NotEmpty().MaximumLength(50);
            RuleFor(p => p.Measure).NotEmpty().MaximumLength(100);
            RuleFor(p => p.Price).NotNull().ExclusiveBetween(10000, 99999);
        }

    }
}
