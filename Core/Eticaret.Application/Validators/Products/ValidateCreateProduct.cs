using System.Data;
using Eticaret.Application.ViewModels.Products;
using Eticaret.Domain.Entities;
using FluentValidation;

namespace Eticaret.Application.Validators.Products;

public class ValidateCreateProduct : AbstractValidator<VM_CreateProduct>
{
    public ValidateCreateProduct()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .NotNull().WithMessage("Lütfen ürün adını giriniz")
            .MaximumLength(150)
            .MinimumLength(2).WithMessage("Ürün adı 2-150 karakter arasında olmalıdır.");

        RuleFor(p => p.Stock)
            .NotEmpty()
            .NotNull().WithMessage("Lütfen stok bilgisi giriniz.")
            .Must(s => s > 0)
            .WithMessage("Eksi stok girilemez.");
        
        RuleFor(p => p.Price)
            .NotEmpty()
            .NotNull().WithMessage("Lütfen fiyat bilgisi giriniz.")
            .Must(s => s > 0)
            .WithMessage("Eksi fiyat girilemez."); 


    }
    
}