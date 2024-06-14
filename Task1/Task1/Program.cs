using System.Globalization;
using Task1.Rental;
using Task1.Vehicles;

namespace Task1;

class Program
{
    private static Dictionary<int, Vehicle> _vehicles;

    static void Main(string[] args)
    {
        Init();
        //StartInput();
        PrintInvoice(_vehicles[1], "John Doe",
            DateTime.ParseExact("2024-06-03", "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None),
            DateTime.ParseExact("2024-06-13", "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None),
            DateTime.ParseExact("2024-06-13", "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None));
        PrintInvoice(_vehicles[2], "Mary Johnson",
            DateTime.ParseExact("2024-06-03", "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None),
            DateTime.ParseExact("2024-06-13", "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None),
            DateTime.ParseExact("2024-06-13", "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None));
        PrintInvoice(_vehicles[3], "John Markson",
            DateTime.ParseExact("2024-06-03", "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None),
            DateTime.ParseExact("2024-06-18", "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None),
            DateTime.ParseExact("2024-06-13", "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None));
        Console.WriteLine("Program execution has finished. Press any key to exit . . .");
        Console.ReadKey(true);
    }

    static void Init()
    {
        _vehicles = new Dictionary<int, Vehicle>
        {
            { 1, new Car("Mitsubishi", "Mirage", 15_000m, 3) },
            { 2, new Motorcycle("Triumph", "Tiger Sport 660", 10_000m) },
            { 3, new Van("Citroen", "Jumper", 20_000m) }
        };
    }

    static void PrintInvoice(Vehicle vehicle, string customerName, DateTime startDate, DateTime endDate,
        DateTime actualReturnDate)
    {
        var rentalTimeAtFirst = (endDate - startDate).Days;
        var actualRentalTimeUsed = rentalTimeAtFirst - (endDate - actualReturnDate).Days;
        if (vehicle.GetType().ToString() == typeof(Car).ToString())
        {
            CarRental carRental = new CarRental();
            carRental.Rent(_vehicles[1], customerName, startDate, endDate, actualReturnDate, rentalTimeAtFirst,
                actualRentalTimeUsed);
            Console.WriteLine(
                $"A car that is valued at ${carRental.SelectedCar.VehicleValue.ToString("0.00")} and has a security rating of {carRental.SelectedCar.SafetyRating}");
            Invoice.Invoice.PrintCarInvoice(carRental);
        }
        else if (vehicle.GetType().ToString() == typeof(Motorcycle).ToString())
        {
            MotorcycleRental motorcycleRental = new MotorcycleRental();
            ((Motorcycle)_vehicles[2]).DriverAge = 20;
            motorcycleRental.Rent(_vehicles[2], customerName, startDate, endDate, actualReturnDate, rentalTimeAtFirst,
                actualRentalTimeUsed);
            Console.WriteLine(
                $"A motorcycle valued at ${motorcycleRental.SelectedMotorcycle.VehicleValue.ToString("0.00")} and the driver is {motorcycleRental.SelectedMotorcycle.DriverAge} years old");
            Invoice.Invoice.PrintMotorCycleInvoice(motorcycleRental);
        }
        else if (vehicle.GetType().ToString() == typeof(Van).ToString())
        {
            VanRental vanRental = new VanRental();
            ((Van)_vehicles[3]).DriverYOE = 8;
            vanRental.Rent(_vehicles[3], customerName, startDate, endDate, actualReturnDate, rentalTimeAtFirst,
                actualRentalTimeUsed);
            Console.WriteLine(
                $"A cargo van valued at ${vanRental.SelectedVan.VehicleValue.ToString("0.00")} and the driver has {vanRental.SelectedVan.DriverYOE} years of driving experience");
            Invoice.Invoice.PrintVanInvoice(vanRental);
        }
    }

    static void StartInput()
    {
        Console.WriteLine(
            "Here are our currently available vehicles for rental. You can pick the one you want to rent by typing its number.");
        foreach (var vehicle in _vehicles)
        {
            Console.WriteLine($"{vehicle.Key}) {vehicle.Value.Brand} {vehicle.Value.Model}");
        }

        string input;
        Vehicle selectedVehicle;
        int key;
        Console.WriteLine();
        while (true)
        {
            try
            {
                Console.Write("Pick your desired vehicle: ");
                input = Console.ReadLine();
                if (int.TryParse(input, out key))
                {
                    if (_vehicles.ContainsKey(key))
                    {
                        selectedVehicle = _vehicles[key];
                        break;
                    }
                    else
                    {
                        throw new Exception("Invalid number selected!");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        if (selectedVehicle is Car car)
        {
            CarInput(car);
        }
        else if (selectedVehicle is Motorcycle motorcycle)
        {
            MotorcycleInput(motorcycle);
        }
        else if (selectedVehicle is Van van)
        {
            VanInput(van);
        }
        //Console.WriteLine(((Van)selectedVehicle).DriverYOE);
    }

    static void CarInput(Car car)
    {
        Console.WriteLine($"You have selected \"{car.Brand} {car.Model}\"");
        const string format = "yyyy-MM-dd";
        string name;
        DateTime startDate;
        DateTime endDate;
        DateTime actualReturnDate;
        while (true)
        {
            try
            {
                Console.Write("Please provide the customer's name: ");
                name = Console.ReadLine();
                if (name.Any(char.IsDigit))
                {
                    throw new Exception("The name can't contain numbers!");
                }

                if (string.IsNullOrEmpty(name))
                {
                    throw new Exception("The name can't be empty!");
                }

                break;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        while (true)
        {
            try
            {
                Console.Write("Start date? (enter a date in the format - \"yyyy-mm-dd\"): ");
                if (DateTime.TryParseExact(Console.ReadLine(), format, CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out startDate))
                {
                    //Console.WriteLine("Valid start date entered: " + startDate.ToString("yyyy-MM-dd"));
                    break;
                }
                else
                {
                    throw new Exception("Invalid format!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        while (true)
        {
            try
            {
                Console.Write("End date? (enter a date in the format - \"yyyy-mm-dd\"): ");
                if (DateTime.TryParseExact(Console.ReadLine(), format, CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out endDate))
                {
                    if (DateTime.Compare(endDate, startDate) < 0)
                    {
                        throw new Exception("You can't have a return date that is earlier than the start date!");
                    }

                    //Console.WriteLine("Valid end date entered: " + endDate.ToString("yyyy-MM-dd"));
                    break;
                }
                else
                {
                    throw new Exception("Invalid format!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        while (true)
        {
            try
            {
                Console.Write("Actual return date? (enter a date in the format - \"yyyy-mm-dd\"): ");
                if (DateTime.TryParseExact(Console.ReadLine(), format, CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out actualReturnDate))
                {
                    //Console.WriteLine("Valid actual return date entered: " + actualReturnDate.ToString("yyyy-MM-dd"));
                    break;
                }
                else
                {
                    throw new Exception("Invalid format!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var rentalTimeAtFirst = (endDate - startDate).Days;
        var actualRentalTimeUsed = rentalTimeAtFirst - (endDate - actualReturnDate).Days;
        CarRental carRental = new CarRental();
        carRental.Rent(car, name, startDate, endDate, actualReturnDate, rentalTimeAtFirst,
            actualRentalTimeUsed);
        while (true)
        {
            try
            {
                Console.Write("Type \"return\" if you wish to return the vehicle: ");
                string input = Console.ReadLine().ToLower();
                if (input == "return")
                {
                    carRental.Return();
                    break;
                }
                else
                {
                    throw new Exception("Invalid option entered!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    static void MotorcycleInput(Motorcycle motorcycle)
    {
        Console.WriteLine($"You have selected \"{motorcycle.Brand} {motorcycle.Model}\"");
        const string format = "yyyy-MM-dd";
        string name;
        DateTime startDate;
        DateTime endDate;
        DateTime actualReturnDate;
        while (true)
        {
            try
            {
                Console.Write("Please provide the customer's name: ");
                name = Console.ReadLine();
                if (name.Any(char.IsDigit))
                {
                    throw new Exception("The name can't contain numbers!");
                }

                if (string.IsNullOrEmpty(name))
                {
                    throw new Exception("The name can't be empty!");
                }

                break;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        while (true)
        {
            try
            {
                Console.Write("Please provide the driver's age: ");
                if (int.TryParse(Console.ReadLine(), out int age))
                {
                    motorcycle.DriverAge = age;
                    break;
                }
                else
                {
                    throw new Exception("Invalid input format. Please only use numbers!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        while (true)
        {
            try
            {
                Console.Write("Start date? (enter a date in the format - \"yyyy-mm-dd\"): ");
                if (DateTime.TryParseExact(Console.ReadLine(), format, CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out startDate))
                {
                    //Console.WriteLine("Valid start date entered: " + startDate.ToString("yyyy-MM-dd"));
                    break;
                }
                else
                {
                    throw new Exception("Invalid format!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        while (true)
        {
            try
            {
                Console.Write("End date? (enter a date in the format - \"yyyy-mm-dd\"): ");
                if (DateTime.TryParseExact(Console.ReadLine(), format, CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out endDate))
                {
                    if (DateTime.Compare(endDate, startDate) < 0)
                    {
                        throw new Exception("You can't have a return date that is earlier than the start date!");
                    }

                    //Console.WriteLine("Valid end date entered: " + endDate.ToString("yyyy-MM-dd"));
                    break;
                }
                else
                {
                    throw new Exception("Invalid format!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        while (true)
        {
            try
            {
                Console.Write("Actual return date? (enter a date in the format - \"yyyy-mm-dd\"): ");
                if (DateTime.TryParseExact(Console.ReadLine(), format, CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out actualReturnDate))
                {
                    //Console.WriteLine("Valid actual return date entered: " + actualReturnDate.ToString("yyyy-MM-dd"));
                    break;
                }
                else
                {
                    throw new Exception("Invalid format!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var rentalTimeAtFirst = (endDate - startDate).Days;
        var actualRentalTimeUsed = rentalTimeAtFirst - (endDate - actualReturnDate).Days;
        MotorcycleRental motorcycleRental = new MotorcycleRental();
        motorcycleRental.Rent(motorcycle, name, startDate, endDate, actualReturnDate, rentalTimeAtFirst,
            actualRentalTimeUsed);
        while (true)
        {
            try
            {
                Console.Write("Type \"return\" if you wish to return the vehicle: ");
                string input = Console.ReadLine().ToLower();
                if (input == "return")
                {
                    motorcycleRental.Return();
                    break;
                }
                else
                {
                    throw new Exception("Invalid option entered!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    static void VanInput(Van van)
    {
        Console.WriteLine($"You have selected \"{van.Brand} {van.Model}\"");
        const string format = "yyyy-MM-dd";
        string name;
        DateTime startDate;
        DateTime endDate;
        DateTime actualReturnDate;
        while (true)
        {
            try
            {
                Console.Write("Please provide the customer's name: ");
                name = Console.ReadLine();
                if (name.Any(char.IsDigit))
                {
                    throw new Exception("The name can't contain numbers!");
                }

                if (string.IsNullOrEmpty(name))
                {
                    throw new Exception("The name can't be empty!");
                }

                break;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        while (true)
        {
            try
            {
                Console.Write("Please provide the driver's years of experience: ");
                if (int.TryParse(Console.ReadLine(), out int yoe))
                {
                    van.DriverYOE = yoe;
                    break;
                }
                else
                {
                    throw new Exception("Invalid input format. Please only use numbers!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        while (true)
        {
            try
            {
                Console.Write("Start date? (enter a date in the format - \"yyyy-mm-dd\"): ");
                if (DateTime.TryParseExact(Console.ReadLine(), format, CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out startDate))
                {
                    //Console.WriteLine("Valid start date entered: " + startDate.ToString("yyyy-MM-dd"));
                    break;
                }
                else
                {
                    throw new Exception("Invalid format!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        while (true)
        {
            try
            {
                Console.Write("End date? (enter a date in the format - \"yyyy-mm-dd\"): ");
                if (DateTime.TryParseExact(Console.ReadLine(), format, CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out endDate))
                {
                    if (DateTime.Compare(endDate, startDate) < 0)
                    {
                        throw new Exception("You can't have a return date that is earlier than the start date!");
                    }

                    //Console.WriteLine("Valid end date entered: " + endDate.ToString("yyyy-MM-dd"));
                    break;
                }
                else
                {
                    throw new Exception("Invalid format!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        while (true)
        {
            try
            {
                Console.Write("Actual return date? (enter a date in the format - \"yyyy-mm-dd\"): ");
                if (DateTime.TryParseExact(Console.ReadLine(), format, CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out actualReturnDate))
                {
                    //Console.WriteLine("Valid actual return date entered: " + actualReturnDate.ToString("yyyy-MM-dd"));
                    break;
                }
                else
                {
                    throw new Exception("Invalid format!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var rentalTimeAtFirst = (endDate - startDate).Days;
        var actualRentalTimeUsed = rentalTimeAtFirst - (endDate - actualReturnDate).Days;
        VanRental vanRental = new VanRental();
        vanRental.Rent(van, name, startDate, endDate, actualReturnDate, rentalTimeAtFirst,
            actualRentalTimeUsed);
        while (true)
        {
            try
            {
                Console.Write("Type \"return\" if you wish to return the vehicle: ");
                string input = Console.ReadLine().ToLower();
                if (input == "return")
                {
                    vanRental.Return();
                    break;
                }
                else
                {
                    throw new Exception("Invalid option entered!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}