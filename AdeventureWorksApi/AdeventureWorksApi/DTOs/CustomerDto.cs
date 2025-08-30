using System.ComponentModel.DataAnnotations;

namespace AdeventureWorksApi.DTOs
{
    public class CustomerDto
    {
        public int CustomerID { get; set; }
        public bool NameStyle { get; set; }
        public string? Title { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string? Suffix { get; set; }
        public string? CompanyName { get; set; }
        public string? SalesPerson { get; set; }
        public string? EmailAddress { get; set; }
        public string? Phone { get; set; }
        public Guid RowGuid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

    public class CreateCustomerDto
    {
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
    }

    public class UpdateCustomerDto
    {
        public bool NameStyle { get; set; }

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

        [MaxLength(128)]
        public string? PasswordHash { get; set; }

        [MaxLength(10)]
        public string? PasswordSalt { get; set; }
    }
}