namespace FishingPlace.Models
{
    public class Fish
    {
        public int Id {  get; set; }
        public string Type {  get; set; }
        public int Weight {  get; set; }

        public ICollection<FishingVessel> FishingVessels { get; set; }
        
        public FishingVessel FishingVessel { get; set; }

    }
}
