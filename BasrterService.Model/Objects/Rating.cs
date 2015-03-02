using System.ComponentModel.DataAnnotations;
using BasrterService.Model.Common;

namespace BasrterService.Model.Objects
{
    public class Rating : BaseEntity
    {
        public User User { get; set; }

        public int Stars { get; set; }

        public long DealsCount { get; set; }
    }
}
