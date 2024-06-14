using System.Text;
using Task1.Rental;

namespace Task1.Invoice;

public static class Invoice
{
    public static void PrintCarInvoice(CarRental carRentalModel)
    {
        //Console.Clear();
        Console.WriteLine();
        StringBuilder sb = new StringBuilder();
        if (carRentalModel.TotalRentalDays != carRentalModel.ActualRentalDays)
        {
            sb.AppendLine("XXXXXXXXXX");
            sb.AppendLine($"Date: {DateTime.Now.ToString("yyyy-MM-dd")}");
            sb.AppendLine($"Customer Name: {carRentalModel.CustomerName}");
            sb.AppendLine($"Rented Vehicle: {carRentalModel.SelectedCar.Brand} {carRentalModel.SelectedCar.Model}\n");
            sb.AppendLine($"Reservation start date: {carRentalModel.RentalStart.ToString("yyyy-MM-dd")}");
            sb.AppendLine($"Reservation end date: {carRentalModel.RentalEnd.ToString("yyyy-MM-dd")}");
            sb.AppendLine($"Reserved rental days: {carRentalModel.TotalRentalDays} days\n");
            sb.AppendLine($"Actual Return date: {carRentalModel.ActualReturnDate.ToString("yyyy-MM-dd")}");
            sb.AppendLine($"Actual rental days: {carRentalModel.ActualRentalDays} days\n");
            sb.AppendLine($"Rental cost per day: ${carRentalModel.DailyRentalCost.ToString("0.00")}");
            sb.AppendLine($"Insurance per day: ${carRentalModel.InsuranceDailyCost.ToString("0.00")}\n");
            sb.AppendLine($"Early return discount for rent: ${carRentalModel.EarlyReturnDiscountRent.ToString("0.00")}");
            sb.AppendLine($"Early return discount for insurance: ${carRentalModel.EarlyReturnDiscountInsurance.ToString("0.00")}\n");
            sb.AppendLine($"Total rent: ${carRentalModel.TotalRental.ToString("0.00")}");
            sb.AppendLine($"Total insurance: ${carRentalModel.TotalInsurance.ToString("0.00")}");
            sb.AppendLine($"Total: ${carRentalModel.Total.ToString("0.00")}");
            sb.AppendLine("XXXXXXXXXX");
        }
        else
        {
            sb.AppendLine("XXXXXXXXXX");
            sb.AppendLine($"Date: {DateTime.Now.ToString("yyyy-MM-dd")}");
            sb.AppendLine($"Customer Name: {carRentalModel.CustomerName}");
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
        }
        Console.WriteLine(sb.ToString());
    }

    public static void PrintMotorCycleInvoice(MotorcycleRental motorcycleRentalModel)
    {
        //Console.Clear();
        Console.WriteLine();
        StringBuilder sb = new StringBuilder();
        if (motorcycleRentalModel.SelectedMotorcycle.DriverAge<25)
        {
            if (motorcycleRentalModel.TotalRentalDays != motorcycleRentalModel.ActualRentalDays)
            {
                sb.AppendLine("XXXXXXXXXX");
                sb.AppendLine($"Date: {DateTime.Now.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Customer Name: {motorcycleRentalModel.CustomerName}");
                sb.AppendLine($"Rented Vehicle: {motorcycleRentalModel.SelectedMotorcycle.Brand} {motorcycleRentalModel.SelectedMotorcycle.Model}\n");
                sb.AppendLine($"Reservation start date: {motorcycleRentalModel.RentalStart.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Reservation end date: {motorcycleRentalModel.RentalEnd.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Reserved rental days: {motorcycleRentalModel.TotalRentalDays} days\n");
                sb.AppendLine($"Actual Return date: {motorcycleRentalModel.ActualReturnDate.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Actual rental days: {motorcycleRentalModel.ActualRentalDays} days\n");
                sb.AppendLine($"Rental cost per day: ${motorcycleRentalModel.DailyRentalCost.ToString("0.00")}");
                sb.AppendLine($"Initial insurance pay: ${motorcycleRentalModel.InsuranceDailyCostInitial.ToString("0.00")}");
                sb.AppendLine($"Insurance addition per day: ${motorcycleRentalModel.InsuranceAdditionPerDay.ToString("0.00")}");
                sb.AppendLine($"Insurance per day: ${motorcycleRentalModel.InsuranceDailyCost.ToString("0.00")}\n");
                sb.AppendLine($"Early return discount for rent: ${motorcycleRentalModel.EarlyReturnDiscountRent.ToString("0.00")}");
                sb.AppendLine($"Early return discount for insurance: ${motorcycleRentalModel.EarlyReturnDiscountInsurance.ToString("0.00")}\n");
                sb.AppendLine($"Total rent: ${motorcycleRentalModel.TotalRental.ToString("0.00")}");
                sb.AppendLine($"Total insurance: ${motorcycleRentalModel.TotalInsurance.ToString("0.00")}");
                sb.AppendLine($"Total: ${motorcycleRentalModel.Total.ToString("0.00")}");
                sb.AppendLine("XXXXXXXXXX");
            }
            else
            {
                sb.AppendLine("XXXXXXXXXX");
                sb.AppendLine($"Date: {DateTime.Now.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Customer Name: {motorcycleRentalModel.CustomerName}");
                sb.AppendLine($"Rented Vehicle: {motorcycleRentalModel.SelectedMotorcycle.Brand} {motorcycleRentalModel.SelectedMotorcycle.Model}\n");
                sb.AppendLine($"Reservation start date: {motorcycleRentalModel.RentalStart.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Reservation end date: {motorcycleRentalModel.RentalEnd.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Reserved rental days: {motorcycleRentalModel.TotalRentalDays} days\n");
                sb.AppendLine($"Actual Return date: {motorcycleRentalModel.ActualReturnDate.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Actual rental days: {motorcycleRentalModel.ActualRentalDays} days\n");
                sb.AppendLine($"Rental cost per day: ${motorcycleRentalModel.DailyRentalCost.ToString("0.00")}");
                sb.AppendLine($"Initial insurance pay: ${motorcycleRentalModel.InsuranceDailyCostInitial.ToString("0.00")}");
                sb.AppendLine($"Insurance addition per day: ${motorcycleRentalModel.InsuranceAdditionPerDay.ToString("0.00")}");
                sb.AppendLine($"Insurance per day: ${motorcycleRentalModel.InsuranceDailyCost.ToString("0.00")}\n");
                sb.AppendLine($"Total rent: ${motorcycleRentalModel.TotalRental.ToString("0.00")}");
                sb.AppendLine($"Total insurance: ${motorcycleRentalModel.TotalInsurance.ToString("0.00")}");
                sb.AppendLine($"Total: ${motorcycleRentalModel.Total.ToString("0.00")}");
                sb.AppendLine("XXXXXXXXXX");
            }
        }
        else
        {
            if (motorcycleRentalModel.TotalRentalDays != motorcycleRentalModel.ActualRentalDays)
            {
                sb.AppendLine("XXXXXXXXXX");
                sb.AppendLine($"Date: {DateTime.Now.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Customer Name: {motorcycleRentalModel.CustomerName}");
                sb.AppendLine($"Rented Vehicle: {motorcycleRentalModel.SelectedMotorcycle.Brand} {motorcycleRentalModel.SelectedMotorcycle.Model}\n");
                sb.AppendLine($"Reservation start date: {motorcycleRentalModel.RentalStart.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Reservation end date: {motorcycleRentalModel.RentalEnd.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Reserved rental days: {motorcycleRentalModel.TotalRentalDays} days\n");
                sb.AppendLine($"Actual Return date: {motorcycleRentalModel.ActualReturnDate.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Actual rental days: {motorcycleRentalModel.ActualRentalDays} days\n");
                sb.AppendLine($"Rental cost per day: ${motorcycleRentalModel.DailyRentalCost.ToString("0.00")}");
                sb.AppendLine($"Insurance per day: ${motorcycleRentalModel.InsuranceDailyCost.ToString("0.00")}\n");
                sb.AppendLine($"Early return discount for rent: ${motorcycleRentalModel.EarlyReturnDiscountRent.ToString("0.00")}");
                sb.AppendLine($"Early return discount for insurance: ${motorcycleRentalModel.EarlyReturnDiscountInsurance.ToString("0.00")}\n");
                sb.AppendLine($"Total rent: ${motorcycleRentalModel.TotalRental.ToString("0.00")}");
                sb.AppendLine($"Total insurance: ${motorcycleRentalModel.TotalInsurance.ToString("0.00")}");
                sb.AppendLine($"Total: ${motorcycleRentalModel.Total.ToString("0.00")}");
                sb.AppendLine("XXXXXXXXXX");
            }
            else
            {
                sb.AppendLine("XXXXXXXXXX");
                sb.AppendLine($"Date: {DateTime.Now.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Customer Name: {motorcycleRentalModel.CustomerName}");
                sb.AppendLine($"Rented Vehicle: {motorcycleRentalModel.SelectedMotorcycle.Brand} {motorcycleRentalModel.SelectedMotorcycle.Model}\n");
                sb.AppendLine($"Reservation start date: {motorcycleRentalModel.RentalStart.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Reservation end date: {motorcycleRentalModel.RentalEnd.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Reserved rental days: {motorcycleRentalModel.TotalRentalDays} days\n");
                sb.AppendLine($"Actual Return date: {motorcycleRentalModel.ActualReturnDate.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Actual rental days: {motorcycleRentalModel.ActualRentalDays} days\n");
                sb.AppendLine($"Rental cost per day: ${motorcycleRentalModel.DailyRentalCost.ToString("0.00")}");
                sb.AppendLine($"Insurance per day: ${motorcycleRentalModel.InsuranceDailyCost.ToString("0.00")}\n");
                sb.AppendLine($"Total rent: ${motorcycleRentalModel.TotalRental.ToString("0.00")}");
                sb.AppendLine($"Total insurance: ${motorcycleRentalModel.TotalInsurance.ToString("0.00")}");
                sb.AppendLine($"Total: ${motorcycleRentalModel.Total.ToString("0.00")}");
                sb.AppendLine("XXXXXXXXXX");
            }
        }
        Console.WriteLine(sb.ToString());
    }

    public static void PrintVanInvoice(VanRental vanRentalModel)
    {
        //Console.Clear();
        Console.WriteLine();
        StringBuilder sb = new StringBuilder();
        if (vanRentalModel.SelectedVan.DriverYOE<25)
        {
            if (vanRentalModel.TotalRentalDays != vanRentalModel.ActualRentalDays)
            {
                sb.AppendLine("XXXXXXXXXX");
                sb.AppendLine($"Date: {DateTime.Now.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Customer Name: {vanRentalModel.CustomerName}");
                sb.AppendLine($"Rented Vehicle: {vanRentalModel.SelectedVan.Brand} {vanRentalModel.SelectedVan.Model}\n");
                sb.AppendLine($"Reservation start date: {vanRentalModel.RentalStart.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Reservation end date: {vanRentalModel.RentalEnd.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Reserved rental days: {vanRentalModel.TotalRentalDays} days\n");
                sb.AppendLine($"Actual Return date: {vanRentalModel.ActualReturnDate.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Actual rental days: {vanRentalModel.ActualRentalDays} days\n");
                sb.AppendLine($"Rental cost per day: ${vanRentalModel.DailyRentalCost.ToString("0.00")}");
                sb.AppendLine($"Initial insurance pay: ${vanRentalModel.InsuranceDailyCostInitial.ToString("0.00")}");
                sb.AppendLine($"Insurance discount per day: ${vanRentalModel.InsuranceDiscountPerDay.ToString("0.00")}");
                sb.AppendLine($"Insurance per day: ${vanRentalModel.InsuranceDailyCost.ToString("0.00")}\n");
                sb.AppendLine($"Early return discount for rent: ${vanRentalModel.EarlyReturnDiscountRent.ToString("0.00")}");
                sb.AppendLine($"Early return discount for insurance: ${vanRentalModel.EarlyReturnDiscountInsurance.ToString("0.00")}\n");
                sb.AppendLine($"Total rent: ${vanRentalModel.TotalRental.ToString("0.00")}");
                sb.AppendLine($"Total insurance: ${vanRentalModel.TotalInsurance.ToString("0.00")}");
                sb.AppendLine($"Total: ${vanRentalModel.Total.ToString("0.00")}");
                sb.AppendLine("XXXXXXXXXX");
            }
            else
            {
                sb.AppendLine("XXXXXXXXXX");
                sb.AppendLine($"Date: {DateTime.Now.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Customer Name: {vanRentalModel.CustomerName}");
                sb.AppendLine($"Rented Vehicle: {vanRentalModel.SelectedVan.Brand} {vanRentalModel.SelectedVan.Model}\n");
                sb.AppendLine($"Reservation start date: {vanRentalModel.RentalStart.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Reservation end date: {vanRentalModel.RentalEnd.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Reserved rental days: {vanRentalModel.TotalRentalDays} days\n");
                sb.AppendLine($"Actual Return date: {vanRentalModel.ActualReturnDate.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Actual rental days: {vanRentalModel.ActualRentalDays} days\n");
                sb.AppendLine($"Rental cost per day: ${vanRentalModel.DailyRentalCost.ToString("0.00")}");
                sb.AppendLine($"Initial insurance pay: ${vanRentalModel.InsuranceDailyCostInitial.ToString("0.00")}");
                sb.AppendLine($"Insurance discount per day: ${vanRentalModel.InsuranceDiscountPerDay.ToString("0.00")}");
                sb.AppendLine($"Insurance per day: ${vanRentalModel.InsuranceDailyCost.ToString("0.00")}\n");
                sb.AppendLine($"Total rent: ${vanRentalModel.TotalRental.ToString("0.00")}");
                sb.AppendLine($"Total insurance: ${vanRentalModel.TotalInsurance.ToString("0.00")}");
                sb.AppendLine($"Total: ${vanRentalModel.Total.ToString("0.00")}");
                sb.AppendLine("XXXXXXXXXX");
            }
        }
        else
        {
            if (vanRentalModel.TotalRentalDays != vanRentalModel.ActualRentalDays)
            {
                sb.AppendLine("XXXXXXXXXX");
                sb.AppendLine($"Date: {DateTime.Now.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Customer Name: {vanRentalModel.CustomerName}");
                sb.AppendLine($"Rented Vehicle: {vanRentalModel.SelectedVan.Brand} {vanRentalModel.SelectedVan.Model}\n");
                sb.AppendLine($"Reservation start date: {vanRentalModel.RentalStart.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Reservation end date: {vanRentalModel.RentalEnd.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Reserved rental days: {vanRentalModel.TotalRentalDays} days\n");
                sb.AppendLine($"Actual Return date: {vanRentalModel.ActualReturnDate.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Actual rental days: {vanRentalModel.ActualRentalDays} days\n");
                sb.AppendLine($"Rental cost per day: ${vanRentalModel.DailyRentalCost.ToString("0.00")}");
                sb.AppendLine($"Initial insurance pay: ${vanRentalModel.InsuranceDailyCostInitial.ToString("0.00")}\n");
                sb.AppendLine($"Early return discount for rent: ${vanRentalModel.EarlyReturnDiscountRent.ToString("0.00")}");
                sb.AppendLine($"Early return discount for insurance: ${vanRentalModel.EarlyReturnDiscountInsurance.ToString("0.00")}\n");
                sb.AppendLine($"Total rent: ${vanRentalModel.TotalRental.ToString("0.00")}");
                sb.AppendLine($"Total insurance: ${vanRentalModel.TotalInsurance.ToString("0.00")}");
                sb.AppendLine($"Total: ${vanRentalModel.Total.ToString("0.00")}");
                sb.AppendLine("XXXXXXXXXX");
            }
            else
            {
                sb.AppendLine("XXXXXXXXXX");
                sb.AppendLine($"Date: {DateTime.Now.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Customer Name: {vanRentalModel.CustomerName}");
                sb.AppendLine($"Rented Vehicle: {vanRentalModel.SelectedVan.Brand} {vanRentalModel.SelectedVan.Model}\n");
                sb.AppendLine($"Reservation start date: {vanRentalModel.RentalStart.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Reservation end date: {vanRentalModel.RentalEnd.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Reserved rental days: {vanRentalModel.TotalRentalDays} days\n");
                sb.AppendLine($"Actual Return date: {vanRentalModel.ActualReturnDate.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"Actual rental days: {vanRentalModel.ActualRentalDays} days\n");
                sb.AppendLine($"Rental cost per day: ${vanRentalModel.DailyRentalCost.ToString("0.00")}");
                sb.AppendLine($"Initial insurance pay: ${vanRentalModel.InsuranceDailyCostInitial.ToString("0.00")}");
                sb.AppendLine($"Total rent: ${vanRentalModel.TotalRental.ToString("0.00")}");
                sb.AppendLine($"Total insurance: ${vanRentalModel.TotalInsurance.ToString("0.00")}");
                sb.AppendLine($"Total: ${vanRentalModel.Total.ToString("0.00")}");
                sb.AppendLine("XXXXXXXXXX");
            }
        }
        Console.WriteLine(sb.ToString());
    }
}