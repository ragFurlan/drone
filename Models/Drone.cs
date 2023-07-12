using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneDeliveryService.Models
{
    class Drone
    {
        public string Name { get; }
        public int MaxWeight { get; }
        public int RemainingCapacity { get; private set; }
        public List<DeliveryTrip> DeliveryTrips { get; }

        public Drone(string name, int maxWeight)
        {
            Name = name;
            MaxWeight = maxWeight;
            RemainingCapacity = maxWeight;
            DeliveryTrips = new List<DeliveryTrip>();
        }

        public void AddLocation(Location location)
        {
            if (RemainingCapacity >= location.PackageWeight)
            {
                RemainingCapacity -= location.PackageWeight;

                if (DeliveryTrips.Count == 0 || DeliveryTrips[DeliveryTrips.Count - 1].TotalWeight + location.PackageWeight > MaxWeight)
                {
                    DeliveryTrips.Add(new DeliveryTrip());
                }

                DeliveryTrips[DeliveryTrips.Count - 1].AddLocation(location);
            }
        }
    }
}
