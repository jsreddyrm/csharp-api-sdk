using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class CurrencyConnector : EntityConnector<Currency, EntityCollection<Currency>, Sort.By.Currency?>, ICurrencyConnector
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.Currency? FilterBy { get; set; }


		/// <remarks/>
		public CurrencyConnector()
		{
			Resource = "currencies";
		}
		/// <summary>
		/// Find a currency based on id
		/// </summary>
		/// <param name="id">Identifier of the currency to find</param>
		/// <returns>The found currency</returns>
		public Currency Get(string id)
		{
			return BaseGet(id.ToString());
		}

		/// <summary>
		/// Updates a currency
		/// </summary>
		/// <param name="currency">The currency to update</param>
		/// <returns>The updated currency</returns>
		public Currency Update(Currency currency)
		{
			return BaseUpdate(currency, currency.Code.ToString());
		}

		/// <summary>
		/// Creates a new currency
		/// </summary>
		/// <param name="currency">The currency to create</param>
		/// <returns>The created currency</returns>
		public Currency Create(Currency currency)
		{
			return BaseCreate(currency);
		}

		/// <summary>
		/// Deletes a currency
		/// </summary>
		/// <param name="id">Identifier of the currency to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id.ToString());
		}

		/// <summary>
		/// Gets a list of currencys
		/// </summary>
		/// <returns>A list of currencys</returns>
		public EntityCollection<Currency> Find()
		{
			return BaseFind();
		}

		public async Task<EntityCollection<Currency>> FindAsync()
		{
			return await BaseFind();
		}
		public async Task DeleteAsync(string id)
		{
			await BaseDelete(id.ToString());
		}
		public async Task<Currency> CreateAsync(Currency currency)
		{
			return await BaseCreate(currency);
		}
		public async Task<Currency> UpdateAsync(Currency currency)
		{
			return await BaseUpdate(currency, currency.Code.ToString());
		}
		public async Task<Currency> GetAsync(string id)
		{
			return await BaseGet(id.ToString());
		}
	}
}
