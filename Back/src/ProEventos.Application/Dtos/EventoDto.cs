using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Application.Dtos
{
    public class EventoDto
    {
		public int Id { get; set; }
		public string Local { get; set; }
        public string DataEvento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        //[MinLength(3, ErrorMessage = "{0} deve ter no minimo 4 caracteres")]
        //[MaxLength(50, ErrorMessage = "{0} deve ter no maximo 50 caracteres")]
        [StringLength(50,MinimumLength =3, ErrorMessage = "Interlavo permitido de 3 a 50 caracteres")]
        public string Tema { get; set; }

        [Display(Name = "Quantidade de pessoas")]
        [Range(1,2000, ErrorMessage = "Interlavo permitido de 1 a 2000 caracteres")]
        public int QtdPessoas { get; set; }

        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$", ErrorMessage = "Não é uma imagem valída")]
        public string ImagemUrl { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [Phone(ErrorMessage = "O campo {0} está com o numero inválido")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O e-mail {0} tem qu ser valído")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public List<PalestranteDto> Palestrantes { get; set; }
        public List<LoteDto> Lotes { get; set; }
        public List<RedeSocialDto> RedesSociais { get; set; }

    }
}
