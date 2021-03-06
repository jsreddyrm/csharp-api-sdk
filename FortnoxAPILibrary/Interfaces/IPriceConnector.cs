using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IPriceConnector : IEntityConnector
	{
		PriceSearch Search { get; set; }

		Price Update(Price price);
		Price Create(Price price);
		Price Get(string priceListCode, string articleNumber, decimal? fromQuantity = null);
		void Delete(string priceListCode, string articleNumber, decimal? fromQuantity = null);
		EntityCollection<PriceSubset> Find(string priceListId, string articleId = null);

		Task<Price> UpdateAsync(Price price);
		Task<Price> CreateAsync(Price price);
		Task<Price> GetAsync(string priceListCode, string articleNumber, decimal? fromQuantity = null);
		Task DeleteAsync(string priceListCode, string articleNumber, decimal? fromQuantity = null);
		Task<EntityCollection<PriceSubset>> FindAsync(string priceListId, string articleId = null);
	}
}
