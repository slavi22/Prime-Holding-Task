using Task1.Vehicles;

namespace Task1.Rental;

public class VanRental : IRental
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

    public Van SelectedVan { get; set; }
    //TODO - add all those new properties in the interface
    public decimal InsuranceDailyCostInitial { get; set; }
    public decimal InsuranceDiscountPerDay { get; set; }
    public decimal EarlyReturnDiscountRent { get; set; }
    public decimal EarlyReturnDiscountInsurance { get; set; }


    public void Rent(Vehicle selectedVehicle, DateTime rentalStart, DateTime rentalEnd, DateTime actualReturnDate,
        int totalRentalDays, int actualRentalDays)
    {
        SelectedVan = (Van)selectedVehicle;
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
        EarlyReturnDiscountRent = RentalCalculator.CalculateRemainingDays(RemainingRentalDays, DailyRentalCost);
        EarlyReturnDiscountInsurance = RentalCalculator.CalculateInsurance(RemainingRentalDays, InsuranceDailyCost);
        TotalRental = ActualRentalPrice + RemainingRentalPrice;
        TotalInsurance = RentalCalculator.CalculateInsurance(ActualRentalDays, InsuranceDailyCost);
        Total = RentalCalculator.CalculateTotalPrice(ActualRentalPrice, RemainingRentalPrice, TotalInsurance);
    }

    public void Return()
    {
        Invoice.Invoice.PrintVanInvoice(this);
    }
}