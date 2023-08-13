using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Customer")]
public class Customer
{
    [Key]
    [Column("id", TypeName = "integer"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("first_name", TypeName = "varchar")]
    public required string FirstName { get; set; }

    [Column("last_name", TypeName = "varchar")]
    public required string LastName { get; set; }

    [Column("modified_date", TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [Column("created_date", TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }
}