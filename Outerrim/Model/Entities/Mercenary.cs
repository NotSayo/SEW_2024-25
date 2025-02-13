using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("Mercenaries")]
public class Mercenary
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int MercenaryId { get; set; }
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public required int BodySkills { get; set; }
    public required int CombatSkill { get; set; }
}