using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("Machineries")]
public class Machinery
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int MachineryId { get; set; }
    public required string Label { get; set; }
    public required string Function { get; set; }

    public int CompartmentId { get; set; }
    public Compartment? Compartment { get; set; }
}