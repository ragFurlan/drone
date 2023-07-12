using DroneDeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DroneDeliveryService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read drone information from the user
            Console.WriteLine("Enter drone information:");
            string[] droneInfo = Console.ReadLine().Split(',');

            List<Drone> drones = CreateDrones(droneInfo);

            // Read locations and package weights from the user
            Console.WriteLine("Enter locations and package weights (one per line):");
            List<Location> locations = ReadLocations();

            // Assign locations to drones
            AssignLocationsToDrones(locations, drones);

            // Print the delivery plan for each drone
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
                int locationsCount = SearchDrones(locations, drones);
                locations = locations.Skip(locationsCount).ToList();               
            }

        }

        static int SearchDrones(List<Location> locations, List<Drone> drones)
        {
            int locationsCountAll = 0;
            foreach (Drone drone in drones)
            {
                int locationsCountPerDrone = 0;
                for (int i = 0; i < locations.Count; i++)
                {                   
                    if (drone.RemainingCapacity >= locations[i].PackageWeight)
                    {
                        drone.AddLocation(locations[i]);
                        locationsCountPerDrone++;
                        locationsCountAll++;
                    }
                    else
                    {
                        drone.ResetRemainingCapacityToNextDrone();
                        locations = locations.Skip(locationsCountPerDrone).ToList();
                        break;
                    }
                }

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
