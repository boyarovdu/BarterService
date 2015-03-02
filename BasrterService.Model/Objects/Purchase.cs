namespace BasrterService.Model.Objects
{
    public class Purchase : Deal
    {
        public decimal Ammount { get; set; }

        public ScoreTransaction ScoreTransaction { get; set; }

        public ScoreAccount FromScoreAccount
        {
            get { return FromUser.ScoreAccount; }
        }

        public ScoreAccount ToScoreAccount
        {
            get { return ToUser.ScoreAccount; }
        }
    }
}
