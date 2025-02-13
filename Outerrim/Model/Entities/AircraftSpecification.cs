using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("AircraftSpecifications")]
public class AircraftSpecification
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int SpecificationId { get; set; }
    public int StructureId { get; set; }
    public int FuelTankCapacity { get; set; }
    public int MinSpeed { get; set; }
    public int MaxSpeed { get; set; }
    public int MaxAltitude { get; set; }
    public required string SpecificationCode { get; set; }

    public List<Aircraft> Aircrafts { get; set; }
}