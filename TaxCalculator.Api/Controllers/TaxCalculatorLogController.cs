using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxCalculator.Api.Repositories.Contracts;
using TaxCalculator.Models.Dtos;

namespace TaxCalculator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxCalculatorLogController : ControllerBase
    {
        private readonly ITaxCalculatorLogRepository _taxCalculatorLogRepository;
        public TaxCalculatorLogController(ITaxCalculatorLogRepository taxCalculatorLogRepository)
        {
            this._taxCalculatorLogRepository = taxCalculatorLogRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxCalculatorLogDto>>> GetLogItems()
        {
            try
            {
                var logItems = await _taxCalculatorLogRepository.GetLogAsync();

                if (logItems == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(logItems);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving taxation log data from the database");

            }

        }
    }
}
