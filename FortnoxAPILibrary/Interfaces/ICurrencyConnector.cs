using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ICurrencyConnector : IEntityConnector
	{
		CurrencySearch Search { get; set; }


		Currency Update(Currency currency);
		Currency Create(Currency currency);
		Currency Get(string id);
		void Delete(string id);
		EntityCollection<Currency> Find();

		Task<Currency> UpdateAsync(Currency currency);
		Task<Currency> CreateAsync(Currency currency);
		Task<Currency> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<Currency>> FindAsync();
	}
}
