using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaBiblioteca.App.Mvc.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [DisplayName("CPF")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(11, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string Cpf { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Permissão para exclusão do usuário.")]
        public bool PermissoaExclusaoUsuario { get; set; }

        public EnderecoViewModel Endereco { get; set; }

        public IEnumerable<LivroViewModel> Produtos { get; set; }
    }
}
