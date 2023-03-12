using FluentValidation;
using System;

namespace SistemaBiblioteca.Business.Models.Emprestimos.Validations
{
    public class EmprestimoValidation : AbstractValidator<Emprestimo>
    {
        public EmprestimoValidation()
        {
            RuleFor(e => e.DataRetirada)
                .NotEmpty().WithMessage("O campo Data de Retirada é obrigatório")
                .NotEqual(e => DateTime.Now).WithMessage("A data deve ser igual a hoje.");

            RuleFor(e => e.DataDevolucao)
                .LessThan(e => e.DataRetirada).WithMessage("A data de devolução não pode ser menor que a data de retirada.");
        }
    }
}