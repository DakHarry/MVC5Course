using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.ViewModels
{
    public class ProductBatchUpdateViewModel : IValidatableObject
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<decimal> Stock { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(this.Stock < 100 && this.Price > 50)
            {
                yield return new ValidationResult("庫存金額有錯!", new string[] { "Price" });
            }
            if(Price > 200)
            {
                yield return new ValidationResult("金額有錯!", new string[] { "Price" });
            }
        }
        
    }
}