using AdeventureWorksApi.DTOs;
using AdeventureWorksApi.Models;

namespace AdeventureWorksApi.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
        Task<CustomerDto?> GetCustomerByIdAsync(int id);
        Task<CustomerDto> CreateCustomerAsync(CreateCustomerDto createCustomerDto);
        Task<CustomerDto?> UpdateCustomerAsync(int id, UpdateCustomerDto updateCustomerDto);
        Task<bool> DeleteCustomerAsync(int id);
        Task<bool> CustomerExistsAsync(int id);
    }
}