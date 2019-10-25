using System.Collections.Generic;

namespace PierresTreats.Models
{
    public class Treat
    {
        public int TreatID {get; set;}
        public string Name {get; set;}
        public virtual ApplicationUser User {get; set;}
        public ICollection<FlavorTreat> Flavors {get;}
        public Treat()
        {
            this.Flavors = new HashSet<FlavorTreat>();
        }
    }
}