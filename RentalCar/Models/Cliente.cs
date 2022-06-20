using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace RentalCar.Models
{
    [Table("clientes")]
    public class Cliente
    {
        [Key()]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        [Display(Name ="Nome*")]
        [StringLength(200, ErrorMessage = "Nome ultrapassou o limite de 200 caracteres")]
        [Required(ErrorMessage = "Nome é obrigatório")]        
        public string Nome { get; set; }
        
        [Column("data_nascimento", TypeName = "date")]
        [Display(Name ="Data Nascimento*")]
        [DataType(DataType.Date,ErrorMessage = "Data de Nascimento é obrigatória e deve estar no formato dd/MM/yyyy")]
        [DisplayFormat(ApplyFormatInEditMode=false,DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage= "Data Nascimento é obrigatória")]        
        //RegularExpression(@"^([1-9]|0[1-9]|[1,2][0-9]|3[0,1])/(0[1-9]|1[0,1,2])/\d{4}$", ErrorMessage= "Data de nascimento deve estar no formato dd/MM/yyyy")]
        public DateTime DataNascimento { get; set; }

        [Column("telefone")]      
        [DataType(DataType.PhoneNumber, ErrorMessage = "Telefone precisa estar o formato (XX)XXXX-XXXX")]
        [StringLength(10, ErrorMessage = "Celular precisa estar no formato (XX)99999-9999")]
        [RegularExpression(@"[0-9]+", ErrorMessage ="Telefone deve conter somente números")]
        public string? Telefone { get; set;}

        [Column("celular")]
        [Display(Name = "Celular*")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Celular precisa estar o formato (XX)XXXX-XXXX")]
        [Required(ErrorMessage="Celular é obrigatório")]
        [StringLength(11, ErrorMessage="Celular precisa estar no formato (DD)99999-9999")]
        [RegularExpression(@"[0-9]+", ErrorMessage="Celular deve conter somente números")]
        public string Celular { get; set; }

        [Column("cnh")]
        [Display(Name = "CNH*")]
        [Required(ErrorMessage ="Habilitação (CNH) é obrigatória")]
        [StringLength(11,ErrorMessage ="CNH possui 11 digitos")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "CNH deve conter apenas números")]
        public string Cnh { get; set; }
               
        [Column("rg")]
        [Display(Name = "RG")]
        [StringLength(11, ErrorMessage = "RG em formato inválido")]
        [RegularExpression(@"[0-9]+", ErrorMessage ="RG deve conter apenas números")]
        public string? Rg { get; set; }

        [Column("cpf")]
        [Display(Name = "CPF")]
        [DataType("CPF", ErrorMessage = "CPF em formato inválido")]
        [StringLength(11, ErrorMessage = "CPF em formato inválido")]
        [RegularExpression(@"[0-9]+", ErrorMessage="CPF deve conter penas números")]
        public string? Cpf { get; set; }

        [Column("endereco")]
        [Display(Name = "Endereço*")]
        [StringLength(200, ErrorMessage = "Endereço ultrapassou o limite de 200 caracteres")]
        [Required(ErrorMessage = "Endereço é obrigatório")]
        public string Endereco { get; set; }

        [Column("email")]
        [Display(Name = "E-mail")]
        [StringLength(50, ErrorMessage = "E-mail ultrapassou o limite de 50 caracteres")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail inválido.")]
        public string? Email { get; set; }

        public ICollection<Locacao> Locacoes { get; set; }

        public Cliente()
        {
            Locacoes = new HashSet<Locacao>();
        }

    }
}
