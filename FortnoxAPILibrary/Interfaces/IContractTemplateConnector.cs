using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IContractTemplateConnector : IEntityConnector
	{
		ContractTemplateSearch Search { get; set; }


		ContractTemplate Update(ContractTemplate contractTemplate);
		ContractTemplate Create(ContractTemplate contractTemplate);
		ContractTemplate Get(string id);
        EntityCollection<ContractTemplateSubset> Find();

		Task<ContractTemplate> UpdateAsync(ContractTemplate contractTemplate);
		Task<ContractTemplate> CreateAsync(ContractTemplate contractTemplate);
		Task<ContractTemplate> GetAsync(string id);
        Task<EntityCollection<ContractTemplateSubset>> FindAsync();
	}
}
