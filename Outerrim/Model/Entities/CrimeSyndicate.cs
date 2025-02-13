using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("CrimeSyndicates")]
public class CrimeSyndicate
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int SyndicateId { get; set; }
    public required string Name { get; set; }
    public required string Location { get; set; }
}