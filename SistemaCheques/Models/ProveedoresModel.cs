using System.ComponentModel.DataAnnotations;

namespace SistemaCheques.Models

{
    public class ProveedoresModel
    {
        public int idProveedor { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo Tipo de persona es obligatorio")]
        public string? TipoPersona { get; set; }

        [Required(ErrorMessage = "El campo Cedula es obligatorio")]
        public string? Cedula { get; set; }

        [Required(ErrorMessage = "El campo Balance es obligatorio")]
        public decimal Balance { get; set; }

        [Required(ErrorMessage = "El campo Cuenta Contable es obligatorio")]
        public int CuentaContable { get; set; }

        [Required(ErrorMessage = "El campo Estado es obligatorio")]
        public string? Estado { get; set; }
    }
}
