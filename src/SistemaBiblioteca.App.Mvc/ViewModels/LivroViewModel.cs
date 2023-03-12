using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace SistemaBiblioteca.App.Mvc.ViewModels
{
    public class LivroViewModel
    {
        public LivroViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Usuario")]
        public Guid UsuarioId { get; set; }

        [DisplayName("Imagem do Livro")]
        public HttpPostedFileBase ImagemUpload { get; set; }

        [DisplayName("Imagem")]
        [Required(ErrorMessage = "A imagem {0} é obrigatória")]
        public string Imagem { get; set; }

        [DisplayName("Editora")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Editora { get; set; }

        [DisplayName("Título")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Titulo { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Ano de publicação")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime AnoPublicacao { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Data do cadastro")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Disponibilidade do empréstimo")]
        public string StatusEmprestimo { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Permissão para exclusão do livro.")]
        public bool PermissoaExclusaoLivro { get; set; }

        public UsuarioViewModel Usuario { get; set; }

        public IEnumerable<UsuarioViewModel> Usuarios { get; set; }
    }
}