using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalCar.Models
{
    [Table("cidades")]
    public class Cidade
    {
        [Key()]
        [Column("id")]
        public int Id { get; set; }
                
        [Column("nome")]        
        [Required(ErrorMessage = "Nome é obrigatória")]
        [Display(Name = "Nome*")]
        public string Nome { get; set; }

        [Column("id_estado")]
        [Required(ErrorMessage = "Estado é obrigatória")]
        [ForeignKey("Estado")]        
        [Display(Name = "Estado*")]
        public int IdEstado { get; set; }
        public Estado? Estado { get; set; }
    }
}
