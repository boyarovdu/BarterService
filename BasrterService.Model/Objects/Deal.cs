using System;
using System.ComponentModel.DataAnnotations;
using BasrterService.Model.Common;

namespace BasrterService.Model.Objects
{
    public class Deal : BaseEntity
    {
        public User Consumer { get; set; }

        public User Seller { get; set; }

        public DateTime Date { get; set; }

        public Weal Weal { get; set; }
    }
}
