using System.Text;
using Task1.Vehicles;

namespace Task1.Rental;

public class CarRental : IRental
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
    public Car SelectedCar { get; set; }


    public void Rent(Vehicle selectedCar, DateTime rentalStart, DateTime rentalEnd, DateTime actualReturnDate,
        int totalRentalDays, int actualRentalDays)
    {
        SelectedCar = (Car)selectedCar;
        RentalStart = rentalStart;
        RentalEnd = rentalEnd;
        ActualReturnDate = actualReturnDate;
        TotalRentalDays = totalRentalDays;
        ActualRentalDays = actualRentalDays;
        DailyRentalCost = ActualRentalDays <= 7 ? 20m : 15m;
        InsuranceDailyCost = decimal.Parse(!SelectedCar.CarHasHighSafety
            ? (selectedCar.VehicleValue * 0.0001m).ToString("0.00")
            : (selectedCar.VehicleValue * 0.0001m * 0.9m).ToString("0.00"));
        RemainingRentalDays = TotalRentalDays - ActualRentalDays;
        ActualRentalPrice = RentalCalculator.CalculateActualTimeRented(ActualRentalDays, DailyRentalCost);
        RemainingRentalPrice = RentalCalculator.CalculateRemainingDays(RemainingRentalDays, DailyRentalCost);
        TotalRental = ActualRentalPrice + RemainingRentalPrice;
        TotalInsurance = RentalCalculator.CalculateInsurance(ActualRentalDays, InsuranceDailyCost);
        Total = RentalCalculator.CalculateTotalPrice(ActualRentalPrice, RemainingRentalPrice, TotalInsurance);

    }


    public void Return()
    {
        Invoice.Invoice.PrintCarInvoice(this);
    }
}