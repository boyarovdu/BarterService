using System;
using BasrterService.Model.Common;

namespace BasrterService.Model.Objects
{
    public class Transaction : BaseEntity
    {
        public Account FromAccount { get; set; }

        public Account ToAccount { get; set; }

        public decimal Ammount { get; set; }

        public DateTime Date { get; set; }
    }
}
