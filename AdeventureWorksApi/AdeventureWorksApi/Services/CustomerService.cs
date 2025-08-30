using Microsoft.EntityFrameworkCore;
using AdeventureWorksApi.Data;
using AdeventureWorksApi.DTOs;
using AdeventureWorksApi.Models;

namespace AdeventureWorksApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly AdventureWorksContext _context;

        public CustomerService(AdventureWorksContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers.Select(MapToDto);
        }

        public async Task<CustomerDto?> GetCustomerByIdAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            return customer == null ? null : MapToDto(customer);
        }

        public async Task<CustomerDto> CreateCustomerAsync(CreateCustomerDto createCustomerDto)
        {
            var customer = new Customer
            {
                NameStyle = createCustomerDto.NameStyle,
                Title = createCustomerDto.Title,
                FirstName = createCustomerDto.FirstName,
                MiddleName = createCustomerDto.MiddleName,
                LastName = createCustomerDto.LastName,
                Suffix = createCustomerDto.Suffix,
                CompanyName = createCustomerDto.CompanyName,
                SalesPerson = createCustomerDto.SalesPerson,
                EmailAddress = createCustomerDto.EmailAddress,
                Phone = createCustomerDto.Phone,
                PasswordHash = createCustomerDto.PasswordHash,
                PasswordSalt = createCustomerDto.PasswordSalt,
                RowGuid = Guid.NewGuid(),
                ModifiedDate = DateTime.Now
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return MapToDto(customer);
        }

        public async Task<CustomerDto?> UpdateCustomerAsync(int id, UpdateCustomerDto updateCustomerDto)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
                return null;

            customer.NameStyle = updateCustomerDto.NameStyle;
            customer.Title = updateCustomerDto.Title;
            customer.FirstName = updateCustomerDto.FirstName;
            customer.MiddleName = updateCustomerDto.MiddleName;
            customer.LastName = updateCustomerDto.LastName;
            customer.Suffix = updateCustomerDto.Suffix;
            customer.CompanyName = updateCustomerDto.CompanyName;
            customer.SalesPerson = updateCustomerDto.SalesPerson;
            customer.EmailAddress = updateCustomerDto.EmailAddress;
            customer.Phone = updateCustomerDto.Phone;
            
            if (!string.IsNullOrEmpty(updateCustomerDto.PasswordHash))
                customer.PasswordHash = updateCustomerDto.PasswordHash;
            
            if (!string.IsNullOrEmpty(updateCustomerDto.PasswordSalt))
                customer.PasswordSalt = updateCustomerDto.PasswordSalt;
            
            customer.ModifiedDate = DateTime.Now;

            await _context.SaveChangesAsync();
            return MapToDto(customer);
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
                return false;

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CustomerExistsAsync(int id)
        {
            return await _context.Customers.AnyAsync(c => c.CustomerID == id);
        }

        private static CustomerDto MapToDto(Customer customer)
        {
            return new CustomerDto
            {
                CustomerID = customer.CustomerID,
                NameStyle = customer.NameStyle,
                Title = customer.Title,
                FirstName = customer.FirstName,
                MiddleName = customer.MiddleName,
                LastName = customer.LastName,
                Suffix = customer.Suffix,
                CompanyName = customer.CompanyName,
                SalesPerson = customer.SalesPerson,
                EmailAddress = customer.EmailAddress,
                Phone = customer.Phone,
                RowGuid = customer.RowGuid,
                ModifiedDate = customer.ModifiedDate
            };
        }
    }
}