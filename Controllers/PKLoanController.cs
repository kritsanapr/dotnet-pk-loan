using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pk_loan_crud.Data;
using pk_loan_crud.Services;

namespace pk_loan_crud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PKLoanController : Controller
    {
        private readonly IPKLoanService _pkLoanService;

        public PKLoanController(IPKLoanService pkLoanService)
        {
            _pkLoanService = pkLoanService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var loan = await _pkLoanService.GetAllLoan();
            if (loan == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No PK_Loan in database.");
            }

            return StatusCode(StatusCodes.Status200OK, loan);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            PKLoan loan = await _pkLoanService.GetLoanById(id);

            if (loan == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No PKLoan found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, loan);
        }

        [HttpPost]
        public async Task<ActionResult<PKLoan>> Add(PKLoan loan)
        {
            var dbLoan = await _pkLoanService.AddLoan(loan);

            if (dbLoan == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{loan.Company} could not be added.");
            }

            return CreatedAtAction(nameof(Get), new { id = loan.Id }, loan);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PKLoan loan)
        {
            if (id != loan.Id)
            {
                return BadRequest();
            }

            PKLoan dbLoan = await _pkLoanService.UpdateLoan(loan, id);

            if (dbLoan == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{loan.Company} could not be updated");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _pkLoanService.GetLoanById(id);
            (bool status, string message) = await _pkLoanService.DeleteLoan(book, id);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, book);
        }
    }
}