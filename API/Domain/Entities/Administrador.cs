using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Domain.Enum;

namespace minimal_api.Domain.Entities
{
    public class Administrador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = default!;

        [Required]
        [StringLength(100, ErrorMessage = "Excedeu limite de caracteres válidos e 100")]
        [EmailAddress(ErrorMessage = "O formato do email é inválido.")]
        public string Email { get; set; } = default!;

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        ErrorMessage = "A senha deve ter no mínimo 8 caracteres, incluindo pelo menos uma letra minúscula, uma letra maiúscula, um número e um caractere especial.")]
        [MinLength(5, ErrorMessage = "O campo senha deve ter no mínimo 5 caracteres")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "O campo senha deve ter no mínimo 50 caracteres")]
        public string Senha { get; set; } = default!;

        [Required]
        [StringLength(10, ErrorMessage = "O campo deve ter no máximo 10 caracteres")]
        public string Perfil { get; set; } = default!;
    }
}