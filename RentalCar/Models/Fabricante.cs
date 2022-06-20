using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalCar.Models
{
    [Table("fabricante")]
    public class Fabricante
    {
        [Key()]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Cidade")]
        [Column("id_cidade")]
        [Display(Name = "Cidade*")]
        public int IdCidadeFabricante { get; set; }
        public virtual Cidade CidadeFabricante { get; set; }

        [Required]
        [Display(Name = "Nome*")]
        [Column("nome")]
        public string Nome { get; set; }

        [Column("endereco")]
        [Display(Name = "Endereço*")]
        public string Endereco { get; set; }

        [Column("telefone")]
        [Display(Name = "Telefone*")]
        public long Telefone { get; set; }

        [Column("nome_contato")]
        [Display(Name = "Contato*")]
        public string NomeContato { get; set; }

        [Column("email_contato")]
        [Display(Name = "E-mail Contato*")]
        public string EmailContato { get; set; }

    }
}
