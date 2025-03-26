namespace FishingPlase.Models
{
    public class FishingVessel
    {
        public string InternationalNumber { get; set; }
        public string CallSign { get; set; }
        public string Marking { get; set; }
        public Owner VesselOwner { get; set; }
        public Captain VesselCaptain { get; set; }
        

        
             public double Length { get; set; }
        public double Width { get; set; }
        public double Tonnage { get; set; }
        public double Draft { get; set; }
        public string Engine { get; set; }
        public double EnginePower { get; set; }
        public string FuelType { get; set; }
    }
}   }

