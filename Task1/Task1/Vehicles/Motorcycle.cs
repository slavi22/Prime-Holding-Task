namespace Task1.Vehicles;

public class Motorcycle : Vehicle
{
    public int DriverAge { get; set; }

    public Motorcycle(string brand, string model, decimal vehicleValue) : base(brand, model, vehicleValue)
    {
    }
}