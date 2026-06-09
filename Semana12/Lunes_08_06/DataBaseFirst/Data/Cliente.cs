using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseFirst.Data;

[Table("CLIENTE")]
public partial class Cliente
{
    [Key]
    public int IdCliente { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string NombreCliente { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string Cif { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string? Direccion { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Usuario { get; set; } = null!;

    [MaxLength(500)]
    public byte[] Password { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime FechaAlta { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaBaja { get; set; }

    [StringLength(200)]
    public string? ColumnaNueva {  get; set; }
}
