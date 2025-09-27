using System.ComponentModel.DataAnnotations;

namespace PortalInmobiliario.Models
{
    public class Inmueble
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Codigo { get; set; } = string.Empty; // único

        [Required]
        [StringLength(100)]
        public string Titulo { get; set; } = string.Empty;

        public string? Imagen { get; set; }

        [Required]
        public string Tipo { get; set; } = string.Empty; // Departamento, Casa, Oficina, Local

        [Required]
        public string Ciudad { get; set; } = string.Empty;

        [Required]
        public string Direccion { get; set; } = string.Empty;

        [Range(0, 20)]
        public int Dormitorios { get; set; }

        [Range(0, 10)]
        public int Banos { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Metros cuadrados debe ser > 0")]
        public int MetrosCuadrados { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Precio debe ser > 0")]
        public decimal Precio { get; set; }

        public bool Activo { get; set; } = true;

        // Relación con Visitas y Reservas
        public ICollection<Visita>? Visitas { get; set; }
        public ICollection<Reserva>? Reservas { get; set; }
    }
}
