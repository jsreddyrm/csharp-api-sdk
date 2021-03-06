using System;
using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IAttendanceTransactionsConnector : IEntityConnector
	{
		AttendanceTransactionsSearch Search { get; set; }

		AttendanceTransaction Update(AttendanceTransaction attendanceTransaction);
		AttendanceTransaction Create(AttendanceTransaction attendanceTransaction);
		AttendanceTransaction Get(string employeeId, DateTime? date, AttendanceCauseCode? code);
		void Delete(string employeeId, DateTime? date, AttendanceCauseCode? code);
		EntityCollection<AttendanceTransactionSubset> Find();

		Task<AttendanceTransaction> UpdateAsync(AttendanceTransaction attendanceTransaction);
		Task<AttendanceTransaction> CreateAsync(AttendanceTransaction attendanceTransaction);
		Task<AttendanceTransaction> GetAsync(string employeeId, DateTime? date, AttendanceCauseCode? code);
		Task DeleteAsync(string employeeId, DateTime? date, AttendanceCauseCode? code);
		Task<EntityCollection<AttendanceTransactionSubset>> FindAsync();
	}
}
