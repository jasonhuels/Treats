using System.Collections.Generic;

namespace PierresTreats.Models
{
    public class Flavor
    {
        public int FlavorID {get; set;}
        public string Description {get; set;}
        public virtual ICollection<FlavorTreat> Treats {get; set;}
        public Flavor()
        {
            this.Treats = new HashSet<FlavorTreat>();
        }
    }
}