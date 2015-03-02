using BasrterService.Model.Common;

namespace BasrterService.Model.Objects
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }

        public Weal Weal { get; set; }

        public User Author { get; set; }
    }
}
