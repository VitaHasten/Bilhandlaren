using ConsoleApp17;
using System;
using System.ComponentModel;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

// Creating list for available cars
List<Cars> carsForSale = new List<Cars>();

// Creating list for sold cars
List<Cars> soldCars = new List<Cars>();

// Creating an array of objects
Cars[] Car = new Cars[100];

// Creating objects (Cars available for sale)
Car[0] = new Cars("Volvo", "240", "Darkblue", "Manual", "Petrol", 1982, 450000, 44000, 18000, 0, true);
Car[1] = new Cars("Skoda", "Kodiaq", "Black", "Automatic", "Petrol", 2020, 27000, 325000, 275000, 0, true);
Car[2] = new Cars("Audi", "Q7", "Silver", "Automatic", "Diesel", 2015, 144000, 285000, 242000, 0, true);
Car[3] = new Cars("Kia", "Picanto", "Red", "Manual", "Petrol", 2018, 27600, 105000, 88000, 0, true);
Car[4] = new Cars("Audi", "A6", "Babyblue", "Manual", "Petrol", 2015, 142000, 241000, 200000, 0, true);
Car[5] = new Cars("SAAB", "9000", "Yellow", "Manual", "Petrol", 2003, 221000, 32000, 10000, 0, true);
Car[6] = new Cars("Volkswagen", "Golf", "White", "Automatic", "Petrol", 2014, 115000, 105000, 88000, 0, true);
Car[7] = new Cars("BMW", "iX1", "White", "Automatic", "Electric", 2017, 47000, 163000, 130000, 0, true);
Car[8] = new Cars("Seat", "Ibiza", "Bronze", "Manual", "Diesel", 2018, 52000, 116000, 92000, 0, true);

// Presents the main menu
MainMenu();

// Adding objects to list carsForSale
void LoadCarsToList()
{
    
    for (int i = 0; i < Car.Length; i++)
    {
        carsForSale.Add(Car[i]);
    }
}

// Presentering objects for sale, with a loop
void PresentCars()

{
    
    // Adding a centered title. 
    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------|");
    string text = "CARS FOR SALE";
    int windowWidth = Console.WindowWidth;
    int textWidth = text.Length;
    int padding = (windowWidth / 2) - (textWidth / 2);

    Console.SetCursorPosition(padding, Console.CursorTop);
    Console.WriteLine(text);
    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------|");

    // Presenting cars for sale from their objects, with formating.
    Console.WriteLine(string.Format("{0,-6} | {1,-10} | {2,-7} | {3,-8} | {4,-12} | {5,-8} | {6,-5} | {7,-9} | {8,-11} | {9,-14} | {10,-9} |", "Object", "Car brand", "Model", "Color", "Transmission", "Engine", "Year", "Distance", "Sales price", "Purchase price", "For sale?"));
    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------|");

    for (int i = 0; i < Car.Length; i++)
        if (Car[i] != null)
        {
        Console.WriteLine(string.Format("{0,-6} | {1,-10} | {2,-7} | {3,-8} | {4,-12} | {5,-8} | {6,-5} | {7,-9} | {8,-11} | {9,-14} | {10,-9} |", (i+1), Car[i].carBrand, Car[i].model, Car[i].color, Car[i].transmission, Car[i].engine, Car[i].year, Car[i].distanceKm+" km", Car[i].salesPrice+" kr", Car[i].purchasePrice+" kr", Car[i].forSale));
        }
    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------|");
    Console.Write("\nPress any key to continue. ");
    Console.ReadLine();
}

// Presenting the list of cars for sale. (Not in use)
void PresentCars2()
{
    // Presenting cars for sale from the list, without formating.
    foreach (var carList in carsForSale)
    {
        if (carList != null)
        {
            Console.Write($"{carList.carBrand} ");
            Console.Write($"{carList.model} ");
            Console.Write($"{carList.color} ");
            Console.Write($"{carList.transmission} ");
            Console.Write($"{carList.engine} ");
            Console.Write($"{carList.year} ");
            Console.Write($"{carList.distanceKm} ");
            Console.Write($"{carList.salesPrice} ");
            Console.Write($"{carList.purchasePrice} ");
            Console.Write($"{carList.forSale} \n");
        }
    }
    Console.WriteLine("Press any key to return to main menu.");
    Console.ReadLine();
}

// Add Car-object to list carsForSale
void AddCar() 
{
    Console.Clear();
    string moreCars = "";
    while (moreCars!="n")
    {
        // Find first empty array position among the Car-objects.
        int index = -1;
        for (int i = 0; i < Car.Length; i++)
        {
            if (Car[i] == null)
            {
                index = i;
                break;
            }
        }

        // Adding new Car-object to the first free array position.
        if (index != -1)
        {
            Car[index] = new Cars("Seat", "Ibiza", "Bronze", "Manual", "Diesel", 2018, 52000, 116000, 92000, 0, true);

            Console.Write("Carbrand: ");
            Car[index].carBrand = Console.ReadLine();
            Console.Write("Model: ");
            Car[index].model = Console.ReadLine();
            Console.Write("Color: ");
            Car[index].color = Console.ReadLine();
            Console.Write("Transmission: ");
            Car[index].transmission = Console.ReadLine();
            Console.Write("Engine: ");
            Car[index].engine = Console.ReadLine();
            Console.Write("Year: ");
            Car[index].year = int.Parse(Console.ReadLine());
            Console.Write("Distance: ");
            Car[index].distanceKm = int.Parse(Console.ReadLine());
            Console.Write("Sales price: ");
            Car[index].salesPrice = int.Parse(Console.ReadLine());
            Console.Write("Purchase price: ");
            Car[index].purchasePrice = int.Parse(Console.ReadLine());
            Car[index].forSale = true;
            LoadCarsToList();
        }
        
        // If all 100 position in the array are taken, we end up here.
        else
        {
            Console.WriteLine("We cannot fit any more new cars. Sell some cars to add more.");
            moreCars = "n";
        }

        Console.Write("\nAdd more cars? y/n ");
        moreCars= Console.ReadLine().ToLower();
        Console.Clear();        
    }
    MainMenu();
}

// Removing car-object and removing object from list carsForSale and adding it to list soldCars
void SellCar() 
{
    Console.Clear();
    PresentCars();

    int sellCarChoiche = 0;

    Console.Write("\nSelect the number of the car you want to sell: ");
    sellCarChoiche=int.Parse(Console.ReadLine());
    Console.Write("Enter the price you sold it for: ");
    Car[sellCarChoiche-1].salesPrice= int.Parse(Console.ReadLine());
    Car[sellCarChoiche-1].forSale= false;
    Car[sellCarChoiche - 1].result =  (Car[sellCarChoiche - 1].salesPrice) - (Car[sellCarChoiche - 1].purchasePrice);
    LoadCarsToList();
    soldCars.Add(Car[sellCarChoiche - 1]);
    carsForSale.Remove(Car[sellCarChoiche-1]);
    Car[sellCarChoiche - 1] = null;
    MainMenu();
}

// Presenting the sold objects from the list soldCars
void ShowSoldCars() 
{
    
    Console.Clear();
    if (soldCars.Count > 0)
    {
        foreach (var showCars in soldCars)
        {
            Console.Write($"Car: {showCars.carBrand} ");
            Console.Write($"{showCars.model}");
            Console.WriteLine($"\nSold for: {showCars.salesPrice} kr");
            Console.Write($"Total income: {showCars.result} kr");

        }
        Console.WriteLine("\n\nPress any key to return to main menu.");
        Console.ReadLine();
    }

    else
    {
        Console.WriteLine("No cars sold!\n");
        Console.WriteLine("Press any key to return to main menu.");
        Console.ReadLine();
    }
    MainMenu();
}

// The main menu
void MainMenu()
{
    Console.Clear();
    Console.WriteLine("1. Cars for sale");
    Console.WriteLine("2. Add a car for sale");
    Console.WriteLine("3. Mark a car as sold");
    Console.WriteLine("4. Show sold cars");
    Console.WriteLine("\n5. Exit program\n");
    string option = Console.ReadLine();
    switch (option)
    {
        case "1":
            {
                LoadCarsToList();
                PresentCars();
                MainMenu();
                break;
            }
        case "2":
            {
                AddCar();
                break;
            }
        case "3":
            {
                SellCar();
                break;
            }
            case "4": 
            {
                ShowSoldCars();
                break;
            }
    }
}
