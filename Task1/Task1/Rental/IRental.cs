using Task1.Vehicles;

namespace Task1.Rental;

public interface IRental
{
    public decimal DailyRentalCost { get; }
    public string CustomerName { get; }
    public DateTime RentalStart { get; }
    public DateTime RentalEnd { get; }
    public DateTime ActualReturnDate { get; }
    public int TotalRentalDays { get; }
    public int ActualRentalDays { get; }
    public decimal InsuranceDailyCost { get; }
    public int RemainingRentalDays { get; }
    public decimal ActualRentalPrice { get; }
    public decimal RemainingRentalPrice { get; }
    public decimal TotalRental { get; }
    public decimal TotalInsurance { get; }
    public decimal Total { get; }
    public decimal EarlyReturnDiscountRent { get; }
    public decimal EarlyReturnDiscountInsurance { get; }

    public void Rent(Vehicle selectedVehicle, string customerName, DateTime rentalStart, DateTime rentalEnd, DateTime actualReturnDate, int totalRentalDays, int actualRentalDays);
    public void Return();
}