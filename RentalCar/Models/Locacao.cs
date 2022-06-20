using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models
{
    [Table("locacao")]
    public class Locacao
    {
        [Key()]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage ="Nome Cliente é obrigatório")]
        [ForeignKey("Cliente")]
        [Column("id_cliente")]
        [Display(Name = " Nome Cliente*")]
        public int IdCliente { get; set; }
        public Cliente? Cliente { get; set; }
        
        [Required(ErrorMessage ="Modelo é obrigatório")]
        [ForeignKey("Carro")]
        [Column("id_carro")]
        [Display(Name = "Modelo*")]
        public int IdCarro { get; set; }
        public Carro? Carro { get; set; }

        [Required(ErrorMessage ="Valor Diária é obrigatório")]
        [Column("diaria", TypeName ="decimal(18,2)")]
        [Display(Name = "Diaria (R$)*")]
        public decimal Diaria { get; set; }
                
        [Column("data_locacao",TypeName="date")]
        [DataType(DataType.Date)]
        [Display(Name = "Data Locação*")]
        [Required(ErrorMessage = "Data de Locação é obrigatória")]
        public DateTime DataLocacao { get; set; }

        [Column("dias_locacao")]
        [Required(ErrorMessage ="Dias Locação é obrigatório")]
        [Range(1, 15, ErrorMessage = "Dias Locação deve estar entre 1 e 15 dias")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "Dias Locação deve conter apenas números")]
        [Display(Name = "Dias Locação*")]
        public int DiasLocacao { get; set; }

        [Column("data_devolucao", TypeName ="date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        [Display(Name = "Data Devolução")]
        public DateTime? DataDevolucao { get; set; }

        [Column("valor_seguro", TypeName ="decimal(18,2)")]
        [Required(ErrorMessage="Valor do seguro é obrigatório")]
        [Display(Name = "Valor Seguro (R$)*")]
        public decimal ValorSeguro { get; set; }

        [Column("observacao")]
        [StringLength(200, ErrorMessage = "Observação ultrapassou o limite de 200 caracteres")]
        [Display(Name = "Observação")]
        public string? observacao { get; set; }
        
    }
}
