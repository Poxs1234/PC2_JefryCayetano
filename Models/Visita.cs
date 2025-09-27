using System.ComponentModel.DataAnnotations;

namespace PortalInmobiliario.Models
{
    public class Visita
    {
        public int Id { get; set; }

        [Required]
        public int InmuebleId { get; set; }
        public Inmueble? Inmueble { get; set; }

        [Required]
        public string UsuarioId { get; set; } = string.Empty; // Identity User
        // public ApplicationUser? Usuario { get; set; }  <-- si extiendes IdentityUser

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        [DateGreaterThan("FechaInicio", ErrorMessage = "Fecha fin debe ser mayor que inicio")]
        public DateTime FechaFin { get; set; }

        [Required]
        public string Estado { get; set; } = "Solicitada"; // {Solicitada, Confirmada, Cancelada}

        public string? Notas { get; set; }
    }

    // Ejemplo de validación personalizada
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _otherPropertyName;

        public DateGreaterThanAttribute(string otherPropertyName)
        {
            _otherPropertyName = otherPropertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var otherProperty = validationContext.ObjectType.GetProperty(_otherPropertyName);
            if (otherProperty == null) return ValidationResult.Success;

            var otherValue = otherProperty.GetValue(validationContext.ObjectInstance);
            if (value is DateTime fechaFin && otherValue is DateTime fechaInicio)
            {
                if (fechaFin <= fechaInicio)
                    return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
