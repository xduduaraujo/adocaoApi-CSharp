using System;
using System.ComponentModel.DataAnnotations;


namespace DesafioWebAPI.Domain.DTO
{
    public class AdocaoCreateRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Idade é obrigatório.")]
        public int? Idade { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Especie é obrigatório.")]
        public string Especie { get; set; }
        public DateTime? DtNascimento { get; set; }
        [Required(ErrorMessage = "O nível de Fofura deve ser preenchido com um valor entre 1 e 5.")]
        public int? NvFofura { get; set; }
        [Required(ErrorMessage = "O nível de Carinho deve ser preenchido com um valor entre 1 e 5.")]
        public int? NvCarinho { get; set; }
        [Required(ErrorMessage = "O email deve ser preenchido.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
