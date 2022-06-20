using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models
{
    [Table("modelo")]
    public class ModeloCarro
    {
        [Key()]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [ForeignKey("TipoCarro")]
        [Column("id_tipo")]
        public int IdTipoCarro { get; set; }
        public virtual Categoria TipoCarro { get; set; }

        [Required]
        [ForeignKey("Fabricante")]
        [Column("id_fabricante")]
        public int IdFabricante { get; set; }
        public virtual Fabricante Fabricante { get; set; }

        [Required]
        [ForeignKey("TipoCombustivel")]
        [Column("id_combustivel")]
        public int IdTipoCombustivel { get; set; }
        public virtual Combustivel TipoCombustivel { get; set; }

        [Column("descricao")]        
        public string Descricao { get; set; }

        [Column("ano_modelo")]
        public int AnoModelo { get; set; }

        [Column("portas")]
        public int Portas { get; set; }
    }
}
