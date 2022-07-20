using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CustomerValidatior : AbstractValidator<Customer>
    {
        public CustomerValidatior()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Musteri Adını Doldurunuz");
            RuleFor(x => x.CustomerPhone).NotEmpty().WithMessage("Telefon Nosunu Doldurunuz");
            RuleFor(x => x.CustomerAddress).NotEmpty().WithMessage("Customer Adreess Boş Bırakılamaz");
            RuleFor(x => x.CustomerDate).NotEmpty().WithMessage("Olusturma Zamaı Doldurunuz");


        }
    }
}
