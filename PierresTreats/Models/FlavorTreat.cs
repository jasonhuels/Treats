using System.ComponentModel.DataAnnotations.Schema;

namespace PierresTreats.Models
{
    public class FlavorTreat
    {
        public int FlavorTreatID {get; set;}
        public int TreatID {get; set;}
        public int FlavorID {get; set;}
        [ForeignKey("TreatID")]
        public Treat Treat {get; set;}
        [ForeignKey("FlavorID")]
        public Flavor Flavor {get; set;}
    }
}