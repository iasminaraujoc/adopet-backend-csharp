using System.ComponentModel.DataAnnotations;

namespace alura_backend_csharp.Models;

public class Tutor
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage ="O nome é obrigatório")]
    [MaxLength(100)]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O email é obrigatório")]
    [MaxLength(100)]
    public string Email { get; set; }

    [Required(ErrorMessage = "A foto é obrigatória")]
    [MaxLength(100)]
    public string Foto { get; set; }

    [Required(ErrorMessage = "O telefone é obrigatório")]
    [MaxLength(11)]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "A cidade é obrigatória")]
    [MaxLength(100)]
    public string Cidade { get; set; }

    [Required(ErrorMessage = "É obrigatório adicionar uma descrição sobre você")]
    [MaxLength(500)]
    public string Sobre { get; set; }
}
