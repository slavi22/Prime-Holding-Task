using System.Globalization;
using Task1.Rental;
using Task1.Vehicles;

namespace Task1;

class Program
{
    private static Dictionary<int, Vehicle> vehicles;

    static void Main(string[] args)
    {
        Init();
        //Console.WriteLine(((Car)vehicles[1]).SafetyRating);
        Input();


        Console.ReadKey();
    }

    static void Init()
    {
        vehicles = new Dictionary<int, Vehicle>
        {
            { 1, new Car("Mitsubishi", "Mirage", 15_000m, 3) },
            { 2, new Motorcycle("Triumph", "Tiger Sport 660", 10_000m) },
            { 3, new Van("Citroen", "Jumper", 20_000m) }
        };
    }

    static void Input()
    {
        Console.WriteLine(
            "Here are our currently available vehicles for rental. You can pick the one you want to rent by typing its number.");
        foreach (var vehicle in vehicles)
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
                    if (vehicles.ContainsKey(key))
                    {
                        selectedVehicle = vehicles[key];
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
        string format = "yyyy-MM-dd";
        DateTime startDate;
        DateTime endDate;
        DateTime actualReturnDate;
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
        carRental.Rent(car, startDate, endDate, actualReturnDate, rentalTimeAtFirst,
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
        string format = "yyyy-MM-dd";
        DateTime startDate;
        DateTime endDate;
        DateTime actualReturnDate;
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
        motorcycleRental.Rent(motorcycle, startDate, endDate, actualReturnDate, rentalTimeAtFirst,
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
        string format = "yyyy-MM-dd";
        DateTime startDate;
        DateTime endDate;
        DateTime actualReturnDate;
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
        vanRental.Rent(van, startDate, endDate, actualReturnDate, rentalTimeAtFirst,
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