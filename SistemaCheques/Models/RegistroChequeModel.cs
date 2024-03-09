using System.ComponentModel.DataAnnotations;

namespace SistemaCheques.Models
{
    public class RegistroChequeModel
    {
        public int idRegistroCheque { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public int NumeroSolicitud { get; set; }

        [Required(ErrorMessage = "El campo Tipo de persona es obligatorio")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "El campo Cedula es obligatorio")]
        public DateTime FechaRegistro { get; set; }

        [Required(ErrorMessage = "El campo Balance es obligatorio")]
        public int CuentaProveedor { get; set; }

        [Required(ErrorMessage = "El campo Cuenta Contable es obligatorio")]
        public int CuentaBanco { get; set; }

        [Required(ErrorMessage = "El campo Estado es obligatorio")]
        public string? Estado { get; set; }
    
    }
}
