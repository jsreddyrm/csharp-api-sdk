using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class TermsOfPaymentConnector : EntityConnector<TermsOfPayment, EntityCollection<TermsOfPaymentSubset>, Sort.By.TermsOfPayment?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.TermsOfPayment? FilterBy { get; set; }


		/// <remarks/>
		public TermsOfPaymentConnector()
		{
			Resource = "termsofpayments";
		}

		/// <summary>
		/// Find a termsOfPayment based on id
		/// </summary>
		/// <param name="id">Identifier of the termsOfPayment to find</param>
		/// <returns>The found termsOfPayment</returns>
		public TermsOfPayment Get(string id)
		{
			return BaseGet(id);
		}

		/// <summary>
		/// Updates a termsOfPayment
		/// </summary>
		/// <param name="termsOfPayment">The termsOfPayment to update</param>
		/// <returns>The updated termsOfPayment</returns>
		public TermsOfPayment Update(TermsOfPayment termsOfPayment)
		{
			return BaseUpdate(termsOfPayment, termsOfPayment.Id.ToString());
		}

		/// <summary>
		/// Creates a new termsOfPayment
		/// </summary>
		/// <param name="termsOfPayment">The termsOfPayment to create</param>
		/// <returns>The created termsOfPayment</returns>
		public TermsOfPayment Create(TermsOfPayment termsOfPayment)
		{
			return BaseCreate(termsOfPayment);
		}

		/// <summary>
		/// Deletes a termsOfPayment
		/// </summary>
		/// <param name="id">Identifier of the termsOfPayment to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id);
		}

		/// <summary>
		/// Gets a list of termsOfPayments
		/// </summary>
		/// <returns>A list of termsOfPayments</returns>
		public EntityCollection<TermsOfPaymentSubset> Find()
		{
			return BaseFind();
		}
	}
}
