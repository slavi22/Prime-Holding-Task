using Task1.Vehicles;

namespace Task1.Rental;

public class MotorcycleRental : IRental
{
    public decimal DailyRentalCost { get; set; }
    public DateTime RentalStart { get; set; }
    public DateTime RentalEnd { get; set; }
    public DateTime ActualReturnDate { get; set; }
    public int TotalRentalDays { get; set; }
    public int ActualRentalDays { get; set; }
    public decimal InsuranceDailyCost { get; set; }
    public int RemainingRentalDays { get; set; }
    public decimal ActualRentalPrice { get; set; }
    public decimal RemainingRentalPrice { get; set; }
    public decimal TotalRental { get; set; }
    public decimal TotalInsurance { get; set; }
    public decimal Total { get; set; }

    public Motorcycle SelectedMotorcycle { get; set; }
    //TODO - add all those new properties in the interface
    public decimal InsuranceDailyCostInitial { get; set; }
    public decimal InsuranceAdditionPerDay { get; set; }

    public void Rent(Vehicle selectedVehicle, DateTime rentalStart, DateTime rentalEnd, DateTime actualReturnDate,
        int totalRentalDays,
        int actualRentalDays)
    {
        SelectedMotorcycle = (Motorcycle)selectedVehicle;
        RentalStart = rentalStart;
        RentalEnd = rentalEnd;
        ActualReturnDate = actualReturnDate;
        TotalRentalDays = totalRentalDays;
        ActualRentalDays = actualRentalDays;
        DailyRentalCost = ActualRentalDays <= 7 ? 15m : 10m;
        InsuranceDailyCostInitial = selectedVehicle.VehicleValue * 0.0002m;
        if (SelectedMotorcycle.DriverAge < 25)
        {
            InsuranceDailyCost = InsuranceDailyCostInitial * 1.2m;
            InsuranceAdditionPerDay = InsuranceDailyCost - InsuranceDailyCostInitial;
        }
        else
        {
            InsuranceDailyCost = InsuranceDailyCostInitial;
        }
        RemainingRentalDays = TotalRentalDays - ActualRentalDays;
        ActualRentalPrice = RentalCalculator.CalculateActualTimeRented(ActualRentalDays, DailyRentalCost);
        RemainingRentalPrice = RentalCalculator.CalculateRemainingDays(RemainingRentalDays, DailyRentalCost);
        TotalRental = ActualRentalPrice + RemainingRentalPrice;
        TotalInsurance = RentalCalculator.CalculateInsurance(ActualRentalDays, InsuranceDailyCost);
        Total = RentalCalculator.CalculateTotalPrice(ActualRentalPrice, RemainingRentalPrice, TotalInsurance);
    }

    public void Return()
    {
        Invoice.Invoice.PrintMotorCycleInvoice(this);
    }
}