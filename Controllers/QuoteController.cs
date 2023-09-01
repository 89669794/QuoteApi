from concurrent.futures.process import _system_limits_checked
from os import system

using system;
using System.Collections.Generic;
using _system_limits_checked.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuoteApi.Models;
using QuoteApi.Services;

namespace QuoteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {

        private readonly IQuoteService _quoteService;
        public QuoteController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }
        // GET: api/Quote
        /// <summary>
        /// Get All Quotes Details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_quoteService.GetAllQuotes());
        }

        // GET: api/Quote/5
        /// <summary>
        /// Get Quote Details by Quoteno
        /// </summary>
        /// <param name="quoteno">Quote Number</param>
        /// <returns></returns>
        [HttpGet("{quoteno}", Name = "GetQuoteByNo")]
        public async Task<IActionResult> GetQuoteByNo(string quoteno)
        {
            return  Ok( await _quoteService.GetQuote(quoteno));
        }

        /// <summary>
        /// Look Up People by query
        /// </summary>
        /// <param name="query">Prople FirstName or Last Name</param>
        /// <returns></returns>
        [HttpGet("people/{query}", Name = "GetPeople")]
        public async Task<IActionResult> GetPeople(string query)
        {
            var result = await _quoteService.FindPeople(query);

            if(result.Count>0)
            {
              return  Ok(result);
            }
            else
            {
                return Ok("Results not found");
            }
        }

        [HttpGet("insured/{quoteid}", Name = "GetAdditionalInsuredsForQuote")]
        public IActionResult GetInsuredsForQuote(int quoteid)
        {
            return Ok(_quoteService.GetAdditionalInsuredsForQuote(quoteid));
        }
        // POST: api/Quote
        /// <summary>
        /// Add AddAdditionalInsured
        /// </summary>
        /// <param name="value">AdditonalInsured</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostAddAdditionalInsured([FromBody] AdditonalInsured value)
        {
            var result = _quoteService.AddAdditionalInsured(value);
            if (result > 0)
                return Ok(result);
            else
                return BadRequest();
        }

        // PUT: api/Quote/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAdditionalInsured(int id)
        {
           return Ok (_quoteService.RemoveAddAdditionalInsured(id));
        }
    }
}
