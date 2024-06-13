namespace Task1.Vehicles;

public class Car : Vehicle
{
    public int SafetyRating { get; set; }
    public bool CarHasHighSafety { get; }


    public Car(string brand, string model, decimal vehicleValue, int safetyRating) : base(brand, model, vehicleValue)
    {
        SafetyRating = safetyRating;
        if (SafetyRating >= 1 && SafetyRating <=5)
        {
            if (SafetyRating >= 4)
            {
                CarHasHighSafety = true;
            }
        }
        else
        {
            throw new Exception();
        }
    }
}