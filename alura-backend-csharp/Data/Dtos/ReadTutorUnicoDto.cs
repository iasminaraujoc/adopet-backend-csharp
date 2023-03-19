using System.ComponentModel.DataAnnotations;

namespace alura_backend_csharp.Data.Dtos
{
    public class ReadTutorDto
    {
        public string Foto { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public string Sobre { get; set; }
    }
}
