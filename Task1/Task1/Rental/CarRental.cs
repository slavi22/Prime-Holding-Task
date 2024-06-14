using System.Text;
using Task1.Vehicles;

namespace Task1.Rental;

public class CarRental : IRental
{
    public decimal DailyRentalCost { get; private set; }
    public string CustomerName { get; private set; }
    public DateTime RentalStart { get; private set; }
    public DateTime RentalEnd { get; private set; }
    public DateTime ActualReturnDate { get; private set; }
    public int TotalRentalDays { get; private set; }
    public int ActualRentalDays { get; private set; }
    public decimal InsuranceDailyCost { get; private set; }
    public int RemainingRentalDays { get; private set; }
    public decimal ActualRentalPrice { get; private set; }
    public decimal RemainingRentalPrice { get; private set; }
    public decimal TotalRental { get; private set; }
    public decimal TotalInsurance { get; private set; }
    public decimal Total { get; private set; }

    public Car SelectedCar { get; private set; }
    public decimal EarlyReturnDiscountRent { get; private set; }
    public decimal EarlyReturnDiscountInsurance { get; private set; }


    public void Rent(Vehicle selectedVehicle, string customerName, DateTime rentalStart, DateTime rentalEnd, DateTime actualReturnDate,
        int totalRentalDays, int actualRentalDays)
    {
        SelectedCar = (Car)selectedVehicle;
        CustomerName = customerName;
        RentalStart = rentalStart;
        RentalEnd = rentalEnd;
        ActualReturnDate = actualReturnDate;
        TotalRentalDays = totalRentalDays;
        ActualRentalDays = actualRentalDays;
        DailyRentalCost = ActualRentalDays <= 7 ? 20m : 15m;
        InsuranceDailyCost = decimal.Parse(!SelectedCar.CarHasHighSafety
            ? (selectedVehicle.VehicleValue * 0.0001m).ToString("0.00")
            : (selectedVehicle.VehicleValue * 0.0001m * 0.9m).ToString("0.00"));
        RemainingRentalDays = TotalRentalDays - ActualRentalDays;
        ActualRentalPrice = RentalCalculator.CalculateActualTimeRented(ActualRentalDays, DailyRentalCost);
        RemainingRentalPrice = RentalCalculator.CalculateRemainingDays(RemainingRentalDays, DailyRentalCost);
        EarlyReturnDiscountRent = RentalCalculator.CalculateEarlyReturnDiscount(RemainingRentalDays, DailyRentalCost);
        EarlyReturnDiscountInsurance = RentalCalculator.CalculateEarlyReturnDiscountInsurance(RemainingRentalDays, InsuranceDailyCost);
        TotalRental = ActualRentalPrice + RemainingRentalPrice;
        TotalInsurance = RentalCalculator.CalculateInsurance(ActualRentalDays, InsuranceDailyCost);
        Total = RentalCalculator.CalculateTotalPrice(ActualRentalPrice, RemainingRentalPrice, TotalInsurance);

    }


    public void Return()
    {
        Invoice.Invoice.PrintCarInvoice(this);
    }
}