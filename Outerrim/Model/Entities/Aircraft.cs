using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("Aircrafts")]
public class Aircraft
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int AircraftId { get; set; }
    public int Fuel { get; set; }
    public int Speed { get; set; }
    public int Altitude { get; set; }
    public required string Name { get; set; }

    public int SpecificationId { get; set; }
    public AircraftSpecification? Specification { get; set; }

    public List<Compartment>? Compartments { get; set; }

}