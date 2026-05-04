using System.ComponentModel.DataAnnotations;

namespace ProjectCSharp.models
{
    public class PersonagemDTO
    {
        [Required(ErrorMessage = "Nome deve ser obrigatório")]
        [MaxLength(50, ErrorMessage = "Nome precisa ter no máximo 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Categoria deve ser obrigatório")]
        [MaxLength(15, ErrorMessage = "Deve conter no máximo 15 caracteres")]
        public string Categoria { get; set; }
    }

    public class PersonagemUpdate
    {
        [MaxLength(50, ErrorMessage = "Nome precisa ter no máximo 50 caracteres")]
        public string? Nome { get; set; }

        [MaxLength(15, ErrorMessage = "Deve conter no máximo 15 caracteres")]
        public string? Categoria { get; set; }
    }
}