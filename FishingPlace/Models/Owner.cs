namespace FishingPlace.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        
        public int FishingVesselId { get; set; }
        public FishingVessel FishingVessel { get; set; }

      
    }
}
