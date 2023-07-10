using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace pk_loan_crud.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _builder;

        public DbInitializer(ModelBuilder builder)
        {
            _builder = builder;
        }

        public void Seed()
        {
            _builder.Entity<PKLoan>(pk =>
            {
                pk.HasData(
                     new PKLoan
                     {
                         Id = 1,
                         Company = "ABC",
                         YearNo = 2023,
                         MonthNo = 7,
                         LoanType = 1,
                         CvCode = "1234567890",
                         BankCode = "ABCDEFGH",
                         Rate = 7.5m,
                         Amount = 10000.00m,
                         InterestAmt = 750.00m,
                         FrAmount = 10500.00m,
                         FrInterestAmt = 787.50m,
                         CurrencyCode = "USD"
                     }
                );

                pk.HasData(
                    new PKLoan
                    {
                        Id = 2,
                        Company = "XYZ",
                        YearNo = 2023,
                        MonthNo = 7,
                        LoanType = 2,
                        CvCode = "0987654321",
                        BankCode = "HIJKLMNOP",
                        Rate = 6.5m,
                        Amount = 20000.00m,
                        InterestAmt = 1300.00m,
                        FrAmount = 21300.00m,
                        FrInterestAmt = 1384.50m,
                        CurrencyCode = "EUR"
                    }
               );
            });
        }
    }
}