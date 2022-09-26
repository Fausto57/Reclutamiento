using Org.BouncyCastle.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Reclutamiento.Models
{
    public class ProspectosModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo Apellido Paterno es obligatorio")]
        public string? ApellidoPaterno { get; set; }
        [Required(ErrorMessage = "El campo Apellido Materno es obligatorio")]
        public string? ApellidoMaterno { get; set; }
        [Required(ErrorMessage = "El campo Calle es obligatorio")]
        public string? Calle { get; set; }
        [Required(ErrorMessage = "El campo Numero de casa es obligatorio")]
        public string? Numero { get; set; }
        [Required(ErrorMessage = "El campo Colonia es obligatorio")]
        public string? Colonia { get; set; }
        [Required(ErrorMessage = "El campo Codigo Postal es obligatorio")]
        public string? CodigoPostal { get; set; }
        [Required(ErrorMessage = "El campo Telefono es obligatorio")]
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "El campo RFC es obligatorio")]
        public string? RFC { get; set; }
        public string? Estatus { get; set; }
        public string? Descripcion { get; set; }

    }
}
