using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pk_loan_crud.Data
{
    [Table("PK_LOAN")]
    public class PKLoan
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [Column("Company")]
        [StringLength(4)]
        public string Company { get; set; }

        [Column("Year_No")]
        public int YearNo { get; set; }

        [Column("Month_No")]
        public int MonthNo { get; set; }

        [Column("Loan_Type")]
        public int LoanType { get; set; }

        [Required]
        [Column("CV_Code")]
        [StringLength(10)]
        public string CvCode { get; set; }

        [Required]
        [Column("Bank_Code")]
        [StringLength(250)]
        public string BankCode { get; set; }

        [Column("Rate", TypeName = "decimal(15, 4)")]
        public decimal Rate { get; set; }

        [Column("Amount", TypeName = "decimal(15, 4)")]
        public decimal Amount { get; set; }

        [Column("Interest_amt", TypeName = "decimal(15, 4)")]
        public decimal InterestAmt { get; set; }

        [Column("Fr_amount", TypeName = "decimal(15, 4)")]
        public decimal FrAmount { get; set; }

        [Column("Fr_interest_amt", TypeName = "decimal(15, 4)")]
        public decimal FrInterestAmt { get; set; }

        [Column("Currency_code")]
        [StringLength(3)]
        public string CurrencyCode { get; set; }
    }
}