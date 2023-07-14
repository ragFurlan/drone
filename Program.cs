using DroneDeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace DroneDeliveryService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter drone information:");
            string[] droneInfo = Console.ReadLine().Split(',');

            List<Drone> drones = CreateDrones(droneInfo);

            Console.WriteLine("Enter locations and package weights (one per line). If you want to finish inserting the locations press enter again and the program will distribute the locations by the indicated drones:");
            List<Location> locations = ReadLocations();

            AssignLocationsToDrones(locations, drones);

            PrintDeliveryPlan(drones);

            Console.WriteLine("Press any key to end execution");
            Console.ReadLine();
        }

        static List<Drone> CreateDrones(string[] droneInfo)
        {
            List<Drone> drones = new List<Drone>();

            for (int i = 0; i < droneInfo.Length; i += 2)
            {
                string droneName = droneInfo[i].Trim();
                int maxWeight = int.Parse(droneInfo[i + 1].Trim());

                drones.Add(new Drone(droneName, maxWeight));
            }

            return drones;
        }

        static List<Location> ReadLocations()
        {
            List<Location> locations = new List<Location>();

            string input;
            while ((input = Console.ReadLine()) != "")
            {
                string[] locationInfo = input.Split(',');
                string locationName = locationInfo[0].Trim();
                int packageWeight = int.Parse(locationInfo[1].Trim());

                locations.Add(new Location(locationName, packageWeight));
            }

            return locations;
        }

        static void AssignLocationsToDrones(List<Location> locations, List<Drone> drones)
        {
            locations = locations.OrderByDescending(x => x.PackageWeight).ToList();
            drones = drones.OrderByDescending(x => x.MaxWeight).ToList();

            while (locations.Count > 0)
            {
                locations = SearchLocations(locations, drones);
            }

        }

        static List<Location> SearchLocations(List<Location> locations, List<Drone> drones)
        {
            List<Location> locationsCountAll = locations;
            foreach (Drone drone in drones)
            {
                locations = SearchLocations2(locations, drone, locationsCountAll);

            }
            return locations;
        }

        static List<Location> SearchLocations2(List<Location> locations, Drone drone, List<Location> locationsCountAll)
        {
            List<Location> locationForTrip = new List<Location>();

            while (drone.RemainingCapacity == drone.MaxWeight && locationsCountAll.Count > 0)
            {
                locationsCountAll = SearchLocations3(locations, drone, locationsCountAll);
            }

            return locationsCountAll;

        }

        static List<Location> SearchLocations3(List<Location> locations, Drone drone, List<Location> locationsCountAll)
        {
            List<Location> locationForTrip = new List<Location>();
            
            for (int l = 0; l < locations.Count; l++)
            {
                if (drone.RemainingCapacity >= locations[l].PackageWeight)
                {
                    drone.AddLocation(locations[l]);
                    locationForTrip.Add(locations[l]);
                    
                }
                if (drone.RemainingCapacity == 0)
                {
                    break;
                }
            }

            foreach (var location in locationForTrip)
            {               
                locationsCountAll.Remove(location);               
            }
           
            if (drone.RemainingCapacity == 0 || drone.RemainingCapacity < (drone.MaxWeight * 0.03))
            {
                drone.ResetRemainingCapacityToNextDrone();
            }

            return locationsCountAll;
        }


        static void PrintDeliveryPlan(List<Drone> drones)
        {
            foreach (Drone drone in drones)
            {
                Console.WriteLine(drone.Name);
                int tripNumber = 1;

                foreach (DeliveryTrip trip in drone.DeliveryTrips)
                {
                    Console.WriteLine("Trip #" + tripNumber);
                    Console.WriteLine(trip.GetLocationsString());
                    tripNumber++;
                }

                Console.WriteLine("");
            }
        }
    }
}
