namespace Task1.Vehicles;

public abstract class Vehicle
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public decimal VehicleValue { get; set; }

    protected Vehicle(string brand, string model, decimal vehicleValue)
    {
        Brand = brand;
        Model = model;
        VehicleValue = vehicleValue;
    }
}