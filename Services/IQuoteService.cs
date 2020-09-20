using QuoteApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteApi.Services
{
    public interface IQuoteService
    {
        Task<Quote> GetQuote(string quoteno);
        Task<List<People>> FindPeople(string query);
        List<GetAdditonalInsured> GetAdditionalInsuredsForQuote(int quoteid);
        int AddAdditionalInsured(AdditonalInsured additonalInsured);

        List<Quote> GetAllQuotes();
        bool RemoveQuote(string quoteno);

        bool RemoveAddAdditionalInsured(int id);

    }
}
