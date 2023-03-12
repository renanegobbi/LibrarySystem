using FluentValidation;

namespace SistemaBiblioteca.Business.Models.Livros.Validations
{
    public class LivroValidation : AbstractValidator<Livro>
    {
        public LivroValidation()
        {
            RuleFor(c => c.Titulo)
                .NotEmpty().WithMessage("O campo Título precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo Título precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("O campo Descrição precisa ser fornecido")
                .Length(2, 1000).WithMessage("O campo Descrição precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}