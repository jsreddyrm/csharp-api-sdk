using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ISupplierInvoiceExternalURLConnectionConnector : IEntityConnector
	{
		SupplierInvoiceExternalURLConnectionSearch Search { get; set; }


		SupplierInvoiceExternalURLConnection Update(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection);
		SupplierInvoiceExternalURLConnection Create(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection);
		SupplierInvoiceExternalURLConnection Get(long? id);
		void Delete(long? id);
		EntityCollection<SupplierInvoiceExternalURLConnection> Find();

		Task<SupplierInvoiceExternalURLConnection> UpdateAsync(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection);
		Task<SupplierInvoiceExternalURLConnection> CreateAsync(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection);
		Task<SupplierInvoiceExternalURLConnection> GetAsync(long? id);
		Task DeleteAsync(long? id);
		Task<EntityCollection<SupplierInvoiceExternalURLConnection>> FindAsync();
	}
}
