using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalCar.Models
{
    [Table("carros")]
    public class Carro
    {
        [Key()]
        [Column("id")]
        public int Id { get; set; }

        [Column("modelo")]
        [Required(ErrorMessage ="Modelo é obrigatório")]
        [StringLength(20, ErrorMessage = "Modelo ultrapassou o limite de 20 caracteres")]
        [Display(Name = "Modelo*")]
        public string Modelo { get; set; }
        //public virtual ModeloCarro ModeloCarro { get; set; }

        [Column("data_compra",TypeName = "date")]
        [DataType(DataType.Date)]
        //DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        [Display(Name = "Data Compra*")]
        [Required(ErrorMessage = "Data Compra é obrigatória")]
        public DateTime DataCompra { get; set; }

        [Column("placa")]
        [StringLength(8, ErrorMessage = "Placa ultrapassou o limite de 8 caracteres")]
        public string? Placa { get; set; }

        [Column("renavam")]
        [StringLength(10, ErrorMessage = "Renavan ultrapassou o limite de 10 caracteres")]
        public string? Renavam { get; set; }

        [Column("chassi")]
        [StringLength(10, ErrorMessage = "Chassi ultrapassou o limite de 10 caracteres")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "Chassi deve conter apenas números")]
        public string? Chassi { get; set; }

        [Column("cor")]
        [StringLength(20, ErrorMessage = "Cor ultrapassou o limite de 20 caracteres")]
        public string? Cor { get; set; }

        [Column("descricao")]
        [Display(Name = "Descrição")]
        [StringLength(200, ErrorMessage = "Descrição ultrapassou o limite de 200 caracteres")]
        public string? Descricao { get; set; }       

        [Column("ano_fabricacao")]       
        [Range(1980, 2022, ErrorMessage ="Ano Fabricação deve estar entre 1980 e o ano atual")]
        [Required(ErrorMessage ="Ano Fabricação é obrigatório")]
        [Display(Name = "Ano Fabricação*")]
        public int AnoFabricacao { get; set; }

        [Column("observacoes")]
        [StringLength(200, ErrorMessage = "Observação ultrapassou o limite de 200 caracteres")]
        [Display(Name = "Observações")]
        public string? Observacoes { get; set; }

        public ICollection<Locacao> Locacoes { get; set; }

        public Carro()
        {
            Locacoes = new HashSet<Locacao>();
        }
    }
}


