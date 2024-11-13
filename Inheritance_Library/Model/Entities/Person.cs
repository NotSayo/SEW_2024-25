using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("PERSONS")]
public class Person
{[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column("FIRST_NAME")]
    public string? FirstName { get; set; }
    [Column("LAST_NAME")]
    public string? LastName { get; set; }
    [Column("DATE_OF_BIRTH")]
    public DateTime DateOfBirth { get; set; }
}