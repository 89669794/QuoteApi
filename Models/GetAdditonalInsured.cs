using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteApi.Models
{
    public class GetAdditonalInsured
    {
        public int QuoteId { get; set; }
        public int PersonId { get; set; }

        public string PersonName { get; set; }
        public int Coverage { get; set; }
        public string Dob { get; set; }
    }
}
