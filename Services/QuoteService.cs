using QuoteApi.Helpers;
using QuoteApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteApi.Services
{
    public class QuoteService : IQuoteService
    {
        private static List<People> peoples = new List<People>();
        private static List<Quote> quotes = new List<Quote>();
        private static List<AdditonalInsured> additonalInsureds = new List<AdditonalInsured>();
        public QuoteService()
        {

            quotes.Clear();
            peoples.Clear();
        }
        private List<People> GetDummyPersonsData()
        {
            peoples.Add(new People { Id = 1, Dob = "03/01/1980", FirstName = "Mr James", LastName = "Father", Name = "Mr James Father" });
            peoples.Add(new People { Id = 2, Dob = "03/01/1970", FirstName = "Mr John", LastName = "Karkow", Name = "Mr John Karkow" });
            peoples.Add(new People { Id = 3, Dob = "03/01/1985", FirstName = "Mr Red", LastName = "Hemom", Name = "Mr Red Hemom" });
            peoples.Add(new People { Id = 4, Dob = "03/01/1986", FirstName = "Mr Red", LastName = "kiran", Name = "Mr Red kiran" });
            return peoples;
        }

        private List<Quote> GetDummyQuoteData()
        {
            quotes.Add(new Quote { Id = 1, Applicant = "Mr James Father", Date = "14/07/2020", EffectiveDate = "20/07/2020", Number = "Q92348", Premimum = PremimumQuote.Basic, Status = QuoteStatus.Pending });
            quotes.Add(new Quote { Id = 2, Applicant = "Mr Raj", Date = "14/09/2020", EffectiveDate = "20/09/2020", Number = "Q92349", Premimum = PremimumQuote.Basic, Status = QuoteStatus.Pending });
            quotes.Add(new Quote { Id = 3, Applicant = "Mr Mark", Date = "14/08/2020", EffectiveDate = "20/08/2020", Number = "Q92347", Premimum = PremimumQuote.Basic, Status = QuoteStatus.Issuesd });


            return quotes;
        }
        public int AddAdditionalInsured(AdditonalInsured additonalInsured)
        {

            if (additonalInsureds.Count > 0)
            {
                additonalInsured.AdditonalInsuredId = additonalInsureds.Max(k => k.AdditonalInsuredId) + 1;

            }
            else
            {
                additonalInsured.AdditonalInsuredId = 1;
            }
            additonalInsureds.Add(additonalInsured);
        
            return additonalInsured.AdditonalInsuredId;
        }

       public bool RemoveAddAdditionalInsured(int id)
        {
            var item = additonalInsureds.FirstOrDefault(k => k.AdditonalInsuredId == id);
            additonalInsureds.Remove(item);
            return true;
        }
        public async Task<List<People>> FindPeople(string query)
        {
            GetDummyPersonsData();
            return peoples.Where(k => k.Name.Contains(query, System.StringComparison.CurrentCultureIgnoreCase)).ToList();
        }

        public List<GetAdditonalInsured> GetAdditionalInsuredsForQuote(int quoteid)
        {
            return (from result in additonalInsureds.Where(k => k.QueoteId == quoteid)
                    let person = peoples.FirstOrDefault(k => k.Id == result.PeopleId)
                    select new GetAdditonalInsured
                    {
                        Coverage = result.Coverage,
                        Dob = person.Dob,
                        PersonId = person.Id,
                        PersonName = person.Name,
                        QuoteId = result.QueoteId
                    }).ToList();
        }

        public async Task<Quote> GetQuote(string quoteno)
        {
            GetDummyQuoteData();
            return quotes.FirstOrDefault(k => k.Number == quoteno);
        }
        public List<Quote> GetAllQuotes()
        {

            GetDummyQuoteData();
            return quotes;
        }

        public bool RemoveQuote(string quoteno)
        {
            var quote = quotes.FirstOrDefault(k => k.Number == quoteno);
            if (quote != null)
                quotes.Remove(quote);
            return true;
        }

       
    }
}
