using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class PrintTemplateConnector : SearchableEntityConnector<PrintTemplate, PrintTemplate, PrintTemplateSearch>, IPrintTemplateConnector
	{

		/// <remarks/>
		public PrintTemplateConnector()
		{
			Resource = "printtemplates";
		}

		/// <summary>
		/// Gets a list of printTemplates
		/// </summary>
		/// <returns>A list of printTemplates</returns>
		public EntityCollection<PrintTemplate> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<PrintTemplate>> FindAsync()
		{
			return await BaseFind().ConfigureAwait(false);
		}
	}
}
