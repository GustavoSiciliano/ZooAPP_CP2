using System.ComponentModel.DataAnnotations;

namespace ZooApp.Models
{
    public class Animal
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome.")]
        public string Nome { get; set; } = "";

        [Required(ErrorMessage = "Informe a espécie.")]
        [Display(Name = "Espécie")]
        public string Especie { get; set; } = "";

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de chegada")]
        public DateTime DataChegada { get; set; } = DateTime.Today;

        public Habitat Habitat { get; set; }

        [Range(0.1, 10000, ErrorMessage = "Peso entre 0,1 e 10000 kg.")]
        [Display(Name = "Peso (kg)")]
        public decimal Peso { get; set; } = 1;

        [Required(ErrorMessage = "Escolha a dieta.")]
        public string Dieta { get; set; } = "";

        [Display(Name = "Observações")]
        public string? Observacoes { get; set; }
    }
}