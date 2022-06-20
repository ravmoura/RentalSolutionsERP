using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models
{
    [Table("valorlocacao")]
    public class ValorLocacao
    {
        [Key()]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [ForeignKey("ModeloCarro")]
        [Column("id_modelo")]
        public int IdModeloCarro { get; set; }
        public virtual ModeloCarro ModeloCarro { get; set; }

        [Column("data_inicio_vigencia)")]
        public DateTime DataInicioVigencia { get; set; }

        [Column("data_fim_vigencia")]
        public DateTime DataFimVigencia { get; set; }

        [Column("preco")]
        public decimal preco { get; set; }
    }
}
