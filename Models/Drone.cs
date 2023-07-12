using System.Collections.Generic;

namespace DroneDeliveryService.Models
{
    class Drone
    {
        public string Name { get; }
        public int MaxWeight { get; private set; }
        public int RemainingCapacity { get; set; }
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
            RemainingCapacity -= location.PackageWeight;

            if (DeliveryTrips.Count == 0 || DeliveryTrips[DeliveryTrips.Count - 1].TotalWeight + location.PackageWeight > MaxWeight)
            {
                DeliveryTrips.Add(new DeliveryTrip());
            }

            DeliveryTrips[DeliveryTrips.Count - 1].AddLocation(location);

        }

        public void ResetRemainingCapacityToNextDrone()
        {
            RemainingCapacity = MaxWeight;
        }
    }
}
