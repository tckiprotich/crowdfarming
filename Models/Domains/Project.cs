namespace crowdfarming.Models.Domains
{
    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Target { get; set; }
        public int Collected { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int FarmerID { get; set; }
        public Farmer Farmer { get; set; }
        public List<Investment> Investments { get; set; }
    }
}