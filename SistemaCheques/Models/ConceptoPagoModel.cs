using System.ComponentModel.DataAnnotations;

namespace SistemaCheques.Models
{
	public class ConceptoPagoModel
	{

		public int idConceptoPago { get; set; }

        [Required(ErrorMessage = "El campo Descripcion es obligatorio")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El campo Estado es obligatorio")]
        public string? Estado { get; set;}

    }
}
