using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ICustomerConnector : IEntityConnector
	{
		CustomerSearch Search { get; set; }

		Customer Update(Customer customer);
		Customer Create(Customer customer);
		Customer Get(string id);
		void Delete(string id);
		EntityCollection<CustomerSubset> Find();

		Task<Customer> UpdateAsync(Customer customer);
		Task<Customer> CreateAsync(Customer customer);
		Task<Customer> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<CustomerSubset>> FindAsync();
	}
}
