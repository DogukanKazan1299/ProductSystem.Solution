using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(t => t.ProductName).NotEmpty().WithMessage("Ürün adı boş geçilemez");
            RuleFor(t => t.CategoryId).NotEmpty().WithMessage("Kategori id boş olamaz");
            RuleFor(t => t.ProductName).MinimumLength(2).WithMessage("ürün adı en az 2 karakter olmalı");
        }
    }
}
