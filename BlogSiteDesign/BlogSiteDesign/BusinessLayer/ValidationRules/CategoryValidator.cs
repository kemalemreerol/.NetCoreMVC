﻿using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adını boş geçemezsiniz.");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklmaası boş geçemezsiniz.");
            RuleFor(x => x.CategoryName).NotEmpty().MaximumLength(50).WithMessage("Kategori adı en fazla 50 karatker olmalıdır.");
            RuleFor(x => x.CategoryName).NotEmpty().MinimumLength(2).WithMessage("Kategori adı en az 2 karatker olmalıdır.");
        }
    }
}
