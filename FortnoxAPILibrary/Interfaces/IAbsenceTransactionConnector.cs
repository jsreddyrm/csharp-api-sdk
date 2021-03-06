using System;
using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IAbsenceTransactionConnector : IEntityConnector
	{
		AbsenceTransactionSearch Search { get; set; }

		AbsenceTransaction Update(AbsenceTransaction absenceTransaction);
		AbsenceTransaction Create(AbsenceTransaction absenceTransaction);
		AbsenceTransaction Get(string employeeId, DateTime? date, AbsenceCauseCode? code);
		void Delete(string employeeId, DateTime? date, AbsenceCauseCode? code);
		EntityCollection<AbsenceTransaction> Find();

		Task<AbsenceTransaction> UpdateAsync(AbsenceTransaction absenceTransaction);
		Task<AbsenceTransaction> CreateAsync(AbsenceTransaction absenceTransaction);
		Task<AbsenceTransaction> GetAsync(string employeeId, DateTime? date, AbsenceCauseCode? code);
		Task DeleteAsync(string employeeId, DateTime? date, AbsenceCauseCode? code);
		Task<EntityCollection<AbsenceTransaction>> FindAsync();
	}
}
