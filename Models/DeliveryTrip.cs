﻿using System.Collections.Generic;
using System.Text;

namespace DroneDeliveryService.Models
{
    class DeliveryTrip
    {
        private readonly List<Location> locations;

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
            sb.Length -= 2;

            return sb.ToString();
        }
    }
}
