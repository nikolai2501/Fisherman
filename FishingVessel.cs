using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingVessel
{
    public class FishingVessel
    {
        public string InternationalNumber { get; set; }
        public string CallSign { get; set; }
        public string Marking { get; set; }
        public Owner VesselOwner { get; set; }
        public Captain VesselCaptain { get; set; }
        public TechnicalSpecs TechnicalSpecifications { get; set; }

        public void DisplayVesselInfo()
        {
            Console.WriteLine($"International Number: {InternationalNumber}");
            Console.WriteLine($"Call Sign: {CallSign}");
            Console.WriteLine($"Marking: {Marking}");
            Console.WriteLine($"Owner: {VesselOwner.Name}, Contact: {VesselOwner.ContactInfo}");
            Console.WriteLine($"Captain: {VesselCaptain.Name}, Qualifications: {VesselCaptain.Qualifications}");
            Console.WriteLine($"Technical Specs: Length - {TechnicalSpecifications.Length}m, Width - {TechnicalSpecifications.Width}m, Tonnage - {TechnicalSpecifications.Tonnage} tons");
        }
    }

    public class Owner
    {
        public string Name { get; set; }
        public string ContactInfo { get; set; }
    }

    public class Captain
    {
        public string Name { get; set; }
        public string Qualifications { get; set; }
    }

    public class TechnicalSpecs
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Tonnage { get; set; }
        public double Draft { get; set; }
        public string Engine { get; set; }
        public double EnginePower { get; set; }
        public string FuelType { get; set; }
    }
}




