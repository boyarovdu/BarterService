using System.ComponentModel.DataAnnotations;
using BasrterService.Model.Common;

namespace BasrterService.Model.Objects
{
    public abstract class Weal : BaseEntity
    {
        public string Description { get; set; }

        [Required]
        public string Title { get; set; }

        public decimal Cost { get; set; }

        [Required]
        public User Owner { get; set; }
    }
}
