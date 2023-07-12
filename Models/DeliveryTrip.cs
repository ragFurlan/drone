using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneDeliveryService.Models
{
    class DeliveryTrip
    {
        private List<Location> locations;

        public int TotalWeight { get; private set; }

        public DeliveryTrip()
        {
            locations = new List<Location>();
            TotalWeight = 0;
        }

        public void AddLocation(Location location)
        {
            locations.Add(location);
            TotalWeight += location.PackageWeight;
        }

        public string GetLocationsString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Location location in locations)
            {
                sb.Append(location.Name);
                sb.Append(", ");
            }
            sb.Length -= 2; // Remove the trailing comma and space

            return sb.ToString();
        }
    }
}
