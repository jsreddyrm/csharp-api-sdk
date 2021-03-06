using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class TrustedEmailDomainsConnector : SearchableEntityConnector<TrustedEmailDomain, TrustedEmailDomain, TrustedEmailDomainsSearch>, ITrustedEmailDomainsConnector
	{

        /// <remarks/>
		public TrustedEmailDomainsConnector()
		{
			Resource = "emailtrusteddomains";
		}

		/// <summary>
		/// Find a trustedEmailDomains based on id
		/// </summary>
		/// <param name="id">Identifier of the trustedEmailDomains to find</param>
		/// <returns>The found trustedEmailDomains</returns>
		public TrustedEmailDomain Get(long? id)
		{
			return GetAsync(id).Result;
		}

		/// <summary>
		/// Creates a new trustedEmailDomains
		/// </summary>
		/// <param name="trustedEmailDomains">The trustedEmailDomains to create</param>
		/// <returns>The created trustedEmailDomains</returns>
		public TrustedEmailDomain Create(TrustedEmailDomain trustedEmailDomains)
		{
			return CreateAsync(trustedEmailDomains).Result;
		}

		/// <summary>
		/// Deletes a trustedEmailDomains
		/// </summary>
		/// <param name="id">Identifier of the trustedEmailDomains to delete</param>
		public void Delete(long? id)
		{
			DeleteAsync(id).Wait();
		}

		/// <summary>
		/// Gets a list of trustedEmailDomainss
		/// </summary>
		/// <returns>A list of trustedEmailDomainss</returns>
		public EntityCollection<TrustedEmailDomain> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<TrustedEmailDomain>> FindAsync()
		{
			return await BaseFind().ConfigureAwait(false);
		}
		public async Task DeleteAsync(long? id)
		{
			await BaseDelete(id.ToString()).ConfigureAwait(false);
		}
		public async Task<TrustedEmailDomain> CreateAsync(TrustedEmailDomain trustedEmailDomains)
		{
			return await BaseCreate(trustedEmailDomains).ConfigureAwait(false);
		}
		public async Task<TrustedEmailDomain> GetAsync(long? id)
		{
			return await BaseGet(id.ToString()).ConfigureAwait(false);
		}
    }
}
