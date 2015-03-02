namespace BasrterService.Model.Objects
{
    public class UserFeedback : Feedback
    {
        public User User { get; set; }

        public Deal Deal { get; set; }
    }
}
