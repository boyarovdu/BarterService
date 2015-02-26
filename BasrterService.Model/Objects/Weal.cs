using BasrterService.Model.Common;

namespace BasrterService.Model.Objects
{
    public abstract class Weal : BaseEntity
    {
        public string Description { get; set; }

        public string Title { get; set; }

        public decimal Cost { get; set; }

        public User Owner { get; set; }
    }
}
