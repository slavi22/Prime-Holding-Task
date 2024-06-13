namespace Task1.Rental;

public static class RentalCalculator
{
    public static decimal CalculateActualTimeRented(int actualDaysOfRental, decimal dailyRentalCost)
    {
        return actualDaysOfRental * dailyRentalCost;
    }

    public static decimal CalculateRemainingDays(int remainingDaysOfRental, decimal dailyRentalCost)
    {
        return remainingDaysOfRental * dailyRentalCost / 2;
    }

    public static decimal CalculateInsurance(int actualDaysOfRental, decimal insuranceDailyCost)
    {
        return actualDaysOfRental * insuranceDailyCost;
    }

    public static decimal CalculateTotalPrice(decimal actualRental, decimal remainingRental, decimal insurance)
    {
        return actualRental + remainingRental + insurance;
    }
}