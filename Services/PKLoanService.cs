using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pk_loan_crud.Data;

namespace pk_loan_crud.Services
{
    public class PKLoanService : IPKLoanService
    {
        private readonly DataContext _db;

        public PKLoanService(DataContext db)
        {
            _db = db;
        }

        // Delete
        public async Task<(bool, string)> DeleteLoan(PKLoan loan, int id)
        {
            try
            {
                var dbAuthor = await _db.PKLoans.FindAsync(loan.Id);

                if (dbAuthor == null)
                {
                    return (false, "Author could not be found");
                }

                _db.PKLoans.Remove(loan);
                await _db.SaveChangesAsync();

                return (true, "Author got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }

        // Get all
        public async Task<List<PKLoan>> GetAllLoan()
        {
            try
            {
                return await _db.PKLoans.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        // Get by id
        public async Task<PKLoan> GetLoanById(int id)
        {
            try
            {
                return await _db.PKLoans.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<PKLoan> AddLoan(PKLoan author)
        {
            try
            {
                await _db.PKLoans.AddAsync(author);
                await _db.SaveChangesAsync();
                return await _db.PKLoans.FindAsync(author.Id); // Auto ID from DB
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }
        }
        // Update
        public async Task<PKLoan> UpdateLoan(PKLoan loan, int id)
        {
            try
            {
                _db.Entry(loan).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return loan;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} was modified");
                return null;
            }
        }


    }
}