using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteApi.Models
{
    public class Quote
    {
        [Required]
        [NotNull]
        public string Number  { get; set; }
        [Required]
        [NotNull]
        public string Status { get; set; }
        [Required]
        [NotNull]
        public string Applicant { get; set; }
        [Required]
        [NotNull]
        public string Date { get; set; }
        [Required]
        [NotNull]
        public string EffectiveDate { get; set; }
        [Required]
        [NotNull]
        public string Premimum { get; set; }
        [Required]
        [NotNull]
        public int Id { get; set; }

    }
}
