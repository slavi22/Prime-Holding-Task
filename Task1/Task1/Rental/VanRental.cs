using Task1.Vehicles;

namespace Task1.Rental;

public class VanRental : IRental
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

    public Van SelectedVan { get; private set; }
    public decimal InsuranceDailyCostInitial { get; private set; }
    public decimal InsuranceDiscountPerDay { get; private set; }
    public decimal EarlyReturnDiscountRent { get; private set; }
    public decimal EarlyReturnDiscountInsurance { get; private set; }


    public void Rent(Vehicle selectedVehicle, string customerName, DateTime rentalStart, DateTime rentalEnd, DateTime actualReturnDate,
        int totalRentalDays, int actualRentalDays)
    {
        SelectedVan = (Van)selectedVehicle;
        CustomerName = customerName;
        RentalStart = rentalStart;
        RentalEnd = rentalEnd;
        ActualReturnDate = actualReturnDate;
        TotalRentalDays = totalRentalDays;
        ActualRentalDays = actualRentalDays;
        DailyRentalCost = ActualRentalDays <= 7 ? 50m : 40m;
        InsuranceDailyCostInitial = selectedVehicle.VehicleValue * 0.0003m;
        if (SelectedVan.DriverYOE > 5)
        {
            InsuranceDailyCost = InsuranceDailyCostInitial * 0.85m;
            InsuranceDiscountPerDay = InsuranceDailyCostInitial - InsuranceDailyCost;
        }
        else
        {
            InsuranceDailyCost = InsuranceDailyCostInitial;
        }
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
        Invoice.Invoice.PrintVanInvoice(this);
    }
}