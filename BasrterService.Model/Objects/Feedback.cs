using System.ComponentModel.DataAnnotations;
using BasrterService.Model.Common;

namespace BasrterService.Model.Objects
{
    public class Feedback : BaseEntity
    {
        public string Content { get; set; }

        public int Rating { get; set; }

        public Deal Deal { get; set; }
    }
}
