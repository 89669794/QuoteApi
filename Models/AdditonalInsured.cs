using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteApi.Models
{
    public class AdditonalInsured
    {
        [Required]
        [NotNull]
        public int PeopleId { get; set; }
        [Required]
        [NotNull]
        public int QueoteId { get; set; }
        [Required]
        [NotNull]
        [Range(1,100)]
        public int Coverage { get; set; }
        public int AdditonalInsuredId { get; set; }
    }
}
