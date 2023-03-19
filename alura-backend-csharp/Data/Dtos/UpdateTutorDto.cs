using System.ComponentModel.DataAnnotations;

namespace alura_backend_csharp.Data.Dtos
{
    public class UpdateTutorDto
    {
        [Required(ErrorMessage = "O id é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A foto é obrigatória")]
        public string Foto { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        [StringLength(11, ErrorMessage = "Seu {0} nome pode ter no mínimo {2} e no máximo {1} caracteres", MinimumLength = 10)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "É obrigatório adicionar uma descrição sobre você")]
        public string Sobre { get; set; }
    }
}
