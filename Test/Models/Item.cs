using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test.Models
{
    // Test 01 13-Oct-22 - Mark Russell class of CSD-3354

    // Pujan Gautam - c0842623 
    public class Item :IValidatableObject
    {

        public int ID { get; set; }

        [Required]
        public double Cost { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public bool isOnSale { get; set; }

       public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            List<ValidationResult> results = new List<ValidationResult>();

            //validate the Name property has no numbers, and the Cost property is positive. Return a ValidationResult         

            if (this.Cost < 0) results.Add(new ValidationResult("Cost is Invalid!", new List<String> { "Cost" }));
            if (this.Name.Any(char.IsDigit)) results.Add(new ValidationResult("Name is Invalid!",new List<String>{"Name"}));

            //Return a ValidationResult for each property that fails validation
            return results;
          
            throw new NotImplementedException();
       }
    }   
}