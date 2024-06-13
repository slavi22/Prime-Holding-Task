using System.Text;
using Task1.Rental;

namespace Task1.Invoice;

public static class Invoice
{

    public static void PrintCarInvoice(CarRental carRentalModel)
    {
        Console.Clear();
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("XXXXXXXXXX");
        sb.AppendLine($"Date: {DateTime.Now.ToString("yyyy-MM-dd")}");
        sb.AppendLine($"Customer Name: name");
        sb.AppendLine($"Rented Vehicle: {carRentalModel.SelectedCar.Brand} {carRentalModel.SelectedCar.Model}\n");
        sb.AppendLine($"Reservation start date: {carRentalModel.RentalStart.ToString("yyyy-MM-dd")}");
        sb.AppendLine($"Reservation end date: {carRentalModel.RentalEnd.ToString("yyyy-MM-dd")}");
        sb.AppendLine($"Reserved rental days: {carRentalModel.TotalRentalDays} days\n");
        sb.AppendLine($"Actual Return date: {carRentalModel.ActualReturnDate.ToString("yyyy-MM-dd")}");
        sb.AppendLine($"Actual rental days: {carRentalModel.ActualRentalDays} days\n");
        sb.AppendLine($"Rental cost per day: ${carRentalModel.DailyRentalCost.ToString("0.00")}");
        sb.AppendLine($"Insurance per day: ${carRentalModel.InsuranceDailyCost.ToString("0.00")}\n");
        sb.AppendLine($"Total rent: ${carRentalModel.TotalRental.ToString("0.00")}");
        sb.AppendLine($"Total insurance: ${carRentalModel.TotalInsurance.ToString("0.00")}");
        sb.AppendLine($"Total: ${carRentalModel.Total.ToString("0.00")}");
        sb.AppendLine("XXXXXXXXXX");
        Console.WriteLine(sb.ToString());
    }
}