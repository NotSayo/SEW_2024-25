using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("Compartments")]
public class Compartment
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int CompartmentId { get; set; }

    public int AircraftId { get; set; }
    public Aircraft? Aircraft { get; set; }

    public List<Machinery>? Machineries { get; set; }
}