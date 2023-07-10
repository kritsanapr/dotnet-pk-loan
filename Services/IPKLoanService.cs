using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pk_loan_crud.Data;

namespace pk_loan_crud.Services
{
    public interface IPKLoanService
    {
        Task<List<PKLoan>> GetAllLoan();
        Task<PKLoan> GetLoanById(int id);
        Task<PKLoan> AddLoan(PKLoan loan);
        Task<PKLoan> UpdateLoan(PKLoan loan, int id);
        Task<(bool, string)> DeleteLoan(PKLoan loan, int id);
    }
}