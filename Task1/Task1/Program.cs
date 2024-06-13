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
            { 1, new Car("Mitsubishi", "Mirage", 15.000m, 3) },
            { 2, new Motorcycle("Triumph", "Tiger Sport 660", 10.000m) },
            { 3, new Van("Citroen", "Jumper", 20.000m) }
        };
    }

    static void Input()
    {
        Console.WriteLine("Here are our currently available vehicles for rental. You can pick the one you want to rent by typing its number.");
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine($"{vehicle.Key}) {vehicle.Value.Brand} {vehicle.Value.Model}");
        }

        Console.Write("\nPick your desired vehicle: ");
        string input;
        Vehicle selectedVehicle;
        int key;
        while (true)
        {
            try
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out key))
                {
                    if (vehicles.ContainsKey(key))
                    {
                        selectedVehicle = vehicles[key];
                        break;
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        if (selectedVehicle is Car car)
        {
            //rental logic
        }
        else if (selectedVehicle is Motorcycle motorcycle)
        {
            try
            {
                Console.Write("Please provide the driver's age: ");
                if (int.TryParse(Console.ReadLine(), out int age))
                {
                    motorcycle.DriverAge = age;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        else if (selectedVehicle is Van van)
        {
            try
            {
                Console.Write("Please provide the driver's years of experience: ");
                if (int.TryParse(Console.ReadLine(), out int yoe))
                {
                    van.DriverYOE = yoe;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //Console.WriteLine(((Van)selectedVehicle).DriverYOE);
    }
}