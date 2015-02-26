using System.Collections.Generic;
using BasrterService.Model.Common;

namespace BasrterService.Model.Objects
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Account Account { get; set; }

        public void Buy(Weal weal)
        {
            // this must be transaction
            this.Account.Ammount -= weal.Cost;
            weal.Owner.Account.Ammount += weal.Cost;
        }
    }
}
