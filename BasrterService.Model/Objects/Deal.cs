using System;
using BasrterService.Model.Common;

namespace BasrterService.Model.Objects
{
    public class Deal : BaseEntity
    {
        public User FromUser { get; set; }

        public User ToUser { get; set; }

        public DateTime Date { get; set; }

        public Weal Weal { get; set; }
    }
}
