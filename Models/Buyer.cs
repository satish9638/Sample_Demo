using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sample_Test.Models
{
    public class Buyer
    {
        public int BuyerId { get; set; }
        public int EventId { get; set; }
        public virtual Event Events { get;set; }
        public string TesterKey { get; set; }

        [Display(Name = "Buyer Name:")]
        [Required(ErrorMessage = "Buyer name is required.")]
        [AllowHtml]
        public string BuyerName { get; set; }
    }
}
