using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("MercenaryReputations")]
public class MercenaryReputation
{
    public required string ReputationChange { get; set; }

    public int MercenaryId { get; set; }
    public Mercenary? Mercenary { get; set; }

    public int SyndicateId { get; set; }
    public CrimeSyndicate? Syndicate { get; set; }
}