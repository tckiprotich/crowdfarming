namespace crowdfarming.Models.Domains
{
    public class Investment
    {
        public int ID { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int InvestorID { get; set; }
        public Investor Investor { get; set; }
        public int ProjectID { get; set; }
        public Project Project { get; set; }
        

       
    }
}