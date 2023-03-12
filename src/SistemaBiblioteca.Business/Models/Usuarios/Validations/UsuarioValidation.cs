using FluentValidation;
using SistemaBiblioteca.Business.Core.Validations.Documentos;

namespace SistemaBiblioteca.Business.Models.Usuarios.Validations
{
    public class UsuarioValidation : AbstractValidator<Usuario>
    {
        public UsuarioValidation()
        {
            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(u => u.Cpf.Length).Equal(CpfValidacao.TamanhoCpf)
                .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");

            RuleFor(u => CpfValidacao.Validar(u.Cpf)).Equal(true)
                .WithMessage("O documento fornecido é inválido.");
        }
    }
}