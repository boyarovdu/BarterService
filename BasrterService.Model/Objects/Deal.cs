using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BasrterService.Model.Common;

namespace BasrterService.Model.Objects
{
    public class Deal : BaseEntity, IValidatableObject
    {
        public User FromUser { get; set; }

        public User ToUser { get; set; }

        public decimal Ammount { get; set; }

        public DateTime Date { get; set; }

        public Account FromAccount
        {
            get { return FromUser.Account; }
        }

        public Account ToAccount
        {
            get { return ToUser.Account; }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return null;
        }
    }
}
