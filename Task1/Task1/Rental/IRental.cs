using Task1.Vehicles;

namespace Task1.Rental;

public interface IRental
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

    public void Rent(Vehicle selectedVehicle, DateTime rentalStart, DateTime rentalEnd, DateTime actualReturnDate, int totalRentalDays, int actualRentalDays);
    public void Return();
}