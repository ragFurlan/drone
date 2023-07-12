namespace DroneDeliveryService.Models
{
    class Location
    {
        public string Name { get; }
        public int PackageWeight { get; }

        public Location(string name, int packageWeight)
        {
            Name = name;
            PackageWeight = packageWeight;
        }
    }
}
