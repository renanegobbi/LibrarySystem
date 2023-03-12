using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaBiblioteca.App.Mvc.ViewModels
{
    public class EmprestimoViewModel
    {
        public EmprestimoViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Usuario")]
        public Guid UsuarioId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Livro")]
        public Guid LivroId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Data de retirada")]
        public DateTime DataRetirada { get; set; } = DateTime.Now;

        [DisplayName("Data de devolução")]
        public DateTime? DataDevolucao { get; set; }
    }
}