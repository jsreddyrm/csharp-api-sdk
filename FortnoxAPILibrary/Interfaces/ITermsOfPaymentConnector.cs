using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ITermsOfPaymentConnector : IEntityConnector
	{
		TermsOfPaymentSearch Search { get; set; }


		TermsOfPayment Update(TermsOfPayment termsOfPayment);
		TermsOfPayment Create(TermsOfPayment termsOfPayment);
		TermsOfPayment Get(string id);
		void Delete(string id);
		EntityCollection<TermsOfPayment> Find();

		Task<TermsOfPayment> UpdateAsync(TermsOfPayment termsOfPayment);
		Task<TermsOfPayment> CreateAsync(TermsOfPayment termsOfPayment);
		Task<TermsOfPayment> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<TermsOfPayment>> FindAsync();
	}
}
