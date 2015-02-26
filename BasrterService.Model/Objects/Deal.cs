using System;
using BasrterService.Model.Common;

namespace BasrterService.Model.Objects
{
    public class Deal : BaseEntity
    {
        public User FromUser { get; set; }

        public User ToUser { get; set; }

        public decimal Ammount { get; set; }

        public DateTime Date { get; set; }

        public Account FromAccount {
            get { return FromUser.Account; }
        }

        public Account ToAccount{ 
            get { return ToUser.Account; }
        }

        public bool Validate(out string validationError)
        {
            validationError = "Error occured in deal";
            return true;
        }
    }
}
