using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioWebAPI.Domain.DTO
{
	public class AdocaoUpdateRequest
	{
		[Required(AllowEmptyStrings = false, ErrorMessage = "O Nome é obrigatório!")]
		public string Nome { get; set; }
		[Required]
		public int? Idade { get; set; }
		public DateTime? DtNascimento { get; set; }
		[Required]
		public int? NvFofura { get; set; }
		[Required]
		public int? NvCarinho { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
	}
}
