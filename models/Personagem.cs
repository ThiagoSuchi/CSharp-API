using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCSharp.models
{
    public class Personagem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Garante a criação como AUTO_INCREMENT no MySQL
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome deve ser obrigatório")]
        [MaxLength(50, ErrorMessage = "Nome precisa ter no máximo 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Categoria deve ser obrigatório")]
        [MaxLength(15, ErrorMessage = "Deve conter no máximo 15 caracteres")]
        public string Categoria { get; set; }
    }
}