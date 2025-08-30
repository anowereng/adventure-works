using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdeventureWorksApi.Models
{
    [Table("Customer", Schema = "SalesLT")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }

        [Required]
        public bool NameStyle { get; set; } = false;

        [MaxLength(8)]
        public string? Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? MiddleName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(10)]
        public string? Suffix { get; set; }

        [MaxLength(128)]
        public string? CompanyName { get; set; }

        [MaxLength(256)]
        public string? SalesPerson { get; set; }

        [MaxLength(50)]
        [EmailAddress]
        public string? EmailAddress { get; set; }

        [MaxLength(25)]
        public string? Phone { get; set; }

        [Required]
        [MaxLength(128)]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        [MaxLength(10)]
        public string PasswordSalt { get; set; } = string.Empty;

        [Required]
        public Guid RowGuid { get; set; } = Guid.NewGuid();

        [Required]
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}