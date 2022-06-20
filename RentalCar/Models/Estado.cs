using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models
{
    [Table("estados")]
    public class Estado
    {
        [Key()]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        [Required(ErrorMessage ="Estado é obrigatório")]
        [StringLength(20, ErrorMessage = "Estado ultrapassou o limite de 20 caracteres")]        
        public string Nome { get; set; }

        [Column("uf")]
        [Required(ErrorMessage ="UF é obrigatória")]
        [StringLength(2, ErrorMessage= "UF ultrapassou o limite de 2 caracteres")]
        public string Uf { get; set; }
                
        public ICollection<Cidade> Cidades { get; set; }

        public Estado(){
            Cidades = new HashSet<Cidade>();
        }

    }
}
