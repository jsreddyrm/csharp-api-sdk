using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IVoucherFileConnectionConnector : IEntityConnector
	{
		VoucherFileConnectionSearch Search { get; set; }

        VoucherFileConnection Create(VoucherFileConnection voucherFileConnection);
		VoucherFileConnection Get(string id);
		void Delete(string id);
		EntityCollection<VoucherFileConnection> Find();

        Task<VoucherFileConnection> CreateAsync(VoucherFileConnection voucherFileConnection);
		Task<VoucherFileConnection> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<VoucherFileConnection>> FindAsync();
	}
}
