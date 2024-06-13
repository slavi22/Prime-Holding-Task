namespace Task1.Vehicles;

public class Van : Vehicle
{
    public int DriverYOE { get; set; }

    public Van(string brand, string model, decimal vehicleValue) : base(brand, model, vehicleValue)
    {
    }
}