using BasrterService.Model.Common;

namespace BasrterService.Model.Objects
{
    public class Account : BaseEntity
    {
        public decimal Ammount { get; set; }

        public User User { get; set; }
    }
}
