namespace Task1.Vehicles;

public class Car : Vehicle
{
    public int SafetyRating { get; set; }
    private bool _carHasHighSafety;


    public Car(string brand, string model, decimal vehicleValue, int safetyRating) : base(brand, model, vehicleValue)
    {
        SafetyRating = safetyRating;
        if (SafetyRating >= 1 && SafetyRating <=5)
        {
            if (SafetyRating >= 4)
            {
                _carHasHighSafety = true;
            }
        }
        else
        {
            throw new Exception();
        }
    }
}