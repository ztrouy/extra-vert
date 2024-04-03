List<Plant> plants = new List<Plant>() {
    new Plant() {
        Species = "Magnificus Troggloditus",
        LightNeeds = 1,
        AskingPrice = 19.99M,
        City = "Magnificus' Tower",
        ZIP = "99999",
        Sold = false,
        AvailableUntil = new DateTime(2025, 09, 11)
    },
    new Plant() {
        Species = "Goobertus Forgotis",
        LightNeeds = 2,
        AskingPrice = 00.01M,
        City = "Unknown",
        ZIP = "00000",
        Sold = false,
        AvailableUntil = new DateTime(2011, 01, 01)
    },
    new Plant() {
        Species = "Stoatus Robotus",
        LightNeeds = 3,
        AskingPrice = 101.01M,
        City = "P03 Factory",
        ZIP = "31173",
        Sold = false,
        AvailableUntil = new DateTime(2024, 05, 14)
    },
    new Plant() {
        Species = "Grimordia Strikita",
        LightNeeds = 4,
        AskingPrice = 99.95M,
        City = "Graveyard",
        ZIP = "70118",
        Sold = true,
        AvailableUntil = new DateTime(2024, 10, 19)
    },
    new Plant() {
        Species = "Leshum Superba",
        LightNeeds = 5,
        AskingPrice = 59.99M,
        City = "Cabinwood",
        ZIP = "89412",
        Sold = false,
        AvailableUntil = new DateTime(2027, 11, 25)
    }
};

Console.Clear();
MainMenu();


void MainMenu() {
    Console.WriteLine("Welcome to Plantscryption!\n");
    string userChoice = null;
    while (userChoice != "0") {
        Console.WriteLine(@"Choose an option:
    0. Close Application
    1. Display All Plants
    2. Post a Plant to be Adopted
    3. Adopt a Plant
    4. Delist a Plant
    5. Search for a Plant
    6. Plant of the Day
    7. Statistics
        ");

        userChoice = Console.ReadLine();
        Console.Clear();
        switch (userChoice) {
            case "0":
                Console.WriteLine("Goodbye!");
                break;
            case "1":
                ListAllPlants();
                break;
            case "2":
                PostPlant();
                break;
            case "3":
                AdoptPlant();
                break;
            case "4":
                DelistPlant();
                break;
            case "5":
                SearchPlant();
                break;
            case "6":
                PlantOfTheDay();
                break;
            case "7":
                StatisticsMenu();
                break;
            default:
                Console.WriteLine("Invalid choice selected, please try again\n");
                break;
        }
    }
}


void ListAllPlants() {
    Console.WriteLine("These are our plants!");
    for (int i = 0; i < plants.Count; i++) {
        // Console.WriteLine($"    {i + 1}. {plants[i].Species} in {plants[i].City} {(plants[i].Sold ? "was sold" : "is available")} for ${plants[i].AskingPrice}");
        Console.WriteLine($"{i + 1}. {PlantDetails(plants[i])}");
    }
    Console.WriteLine("");
}

void PostPlant() {
    Plant newPlant = new Plant() {
        Species = "",
        LightNeeds = 0,
        AskingPrice = 0.00M,
        City = "",
        ZIP = "",
        Sold = false,
        AvailableUntil = new DateTime()
    };
    
    Console.WriteLine("What is the species of the plant?");
    while (string.IsNullOrWhiteSpace(newPlant.Species)) {
        Console.WriteLine("Name of the species:");
        
        try {
            newPlant.Species = Console.ReadLine()!.Trim();
        }
        catch (FormatException) {
            Console.WriteLine("Please input a string");
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
            Console.WriteLine("Something went wrong, please try again!");
        }
    }

    Console.WriteLine("\nHow much light does the plant need, on a scale from 1-5?:");
    while (newPlant.LightNeeds < 1 | newPlant.LightNeeds > 5) {
        Console.WriteLine("Light needed:");
        int[] lightRange = [1, 2, 3, 4, 5];
        
        try {
            int response = int.Parse(Console.ReadLine()!.Trim());
            newPlant.LightNeeds = lightRange[response - 1];
        }
        catch (IndexOutOfRangeException) {
            Console.WriteLine("Please choose a value between 1-5!");
        }
        catch (FormatException) {
            Console.WriteLine("Please input an integer!");
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
            Console.WriteLine("Something went wrong, please try again!");
        }
    }

    Console.WriteLine("\nWhat is the price you wish to list the plant at?");
    while (newPlant.AskingPrice <= 0) {
        Console.WriteLine("Asking price:");
        try {
            newPlant.AskingPrice = decimal.Parse(Console.ReadLine()!.Trim());
        }
        
        catch (FormatException) {
            Console.WriteLine("Please put in a number!");
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
            Console.WriteLine("Something went wrong, please try again!");
        }
    }

    Console.WriteLine("\nWhat is the name of the city the plant originates?");
    while (string.IsNullOrWhiteSpace(newPlant.City)) {
        Console.WriteLine("City name:");
        try {
            newPlant.City = Console.ReadLine()!.Trim();
        }
        catch (FormatException) {
            Console.WriteLine("Please put in a name!");
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
            Console.WriteLine("Something went wrong, please try again!");
        }
    }

    Console.WriteLine("\nWhat is the ZIP code that the plant originates?");
    while (string.IsNullOrWhiteSpace(newPlant.ZIP)) {
        Console.WriteLine("ZIP code:");
        try {
            newPlant.ZIP = Console.ReadLine()!.Trim();
        }
        catch (FormatException) {
            Console.WriteLine("Please put in a ZIP code!");
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
            Console.WriteLine("Something went wrong, please try again!");
        }
    }

    DateTime validYear = new DateTime();
    DateTime validMonth = new DateTime();
    
    Console.WriteLine("\nWhat year should this post expire?");
    while (newPlant.AvailableUntil == new DateTime()) {
        Console.WriteLine("Expiration year:");
        
        try {
            int response = int.Parse(Console.ReadLine()!.Trim());
            newPlant.AvailableUntil = new DateTime(response, 1, 1);
            validYear = newPlant.AvailableUntil;
        }
        catch (ArgumentOutOfRangeException) {
            Console.WriteLine("Please choose a valid year!");
        }
        catch (FormatException) {
            Console.WriteLine("Please input an integer!");
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
            Console.WriteLine("Something went wrong, please try again!");
        }
    }

    Console.WriteLine("\nWhat month should this post expire?");
    while (newPlant.AvailableUntil == validYear) {
        Console.WriteLine("Expiration month:");

        try {
            int response = int.Parse(Console.ReadLine()!.Trim());
            newPlant.AvailableUntil = new DateTime(validYear.Year, response, 1);
            validMonth = newPlant.AvailableUntil;
        }
        catch (ArgumentOutOfRangeException) {
            Console.WriteLine("Please choose a valid month!");
        }
        catch (FormatException) {
            Console.WriteLine("Please input an integer!");
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
            Console.WriteLine("Something went wrong, please try again!");
        }
    }

    Console.WriteLine("\nWhat day should this post expire?");
    while (newPlant.AvailableUntil == validMonth) {
        Console.WriteLine("Expiration day:");

        try {
            int response = int.Parse(Console.ReadLine()!.Trim());
            newPlant.AvailableUntil = new DateTime(validYear.Year, validMonth.Month, response);
        }
        catch (ArgumentOutOfRangeException) {
            Console.WriteLine("Please choose a valid day!");
        }
        catch (FormatException) {
            Console.WriteLine("Please input an integer!");
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
            Console.WriteLine("Something went wrong, please try again!");
        }
    }

    plants.Add(newPlant);
    Console.Clear();
}

void AdoptPlant() {
    List<Plant> availablePlants = new List<Plant>();

    foreach (Plant plant in plants) {
        if (!plant.Sold & plant.AvailableUntil >= DateTime.Now) {
            availablePlants.Add(plant);
        }
    }
    
    Console.WriteLine("These are all of our available plants!");
    for (int i = 0; i < availablePlants.Count; i++) {
        Console.WriteLine($"    {i + 1}. {PlantDetails(availablePlants[i])}");
    }

    Plant chosenPlant = null;
    while (chosenPlant == null) {
        Console.WriteLine($"\nWhich plant:");
        try {
            int userChoice = int.Parse(Console.ReadLine()!.Trim());
            chosenPlant = availablePlants[userChoice - 1];
        }
        catch (FormatException) {
            Console.WriteLine("Please input an integer!");
        }
        catch (ArgumentOutOfRangeException) {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
            Console.WriteLine("Something went wrong, please try again!");
        }
    }

    chosenPlant.Sold = true;
    Console.WriteLine($"Thank you for adopting the {chosenPlant.Species} from {chosenPlant.City} for ${chosenPlant.AskingPrice}!");
}

void DelistPlant() {
    ListAllPlants();
    Console.WriteLine("Which plant would you like to delist?");

    Plant chosenPlant = null;
    while (chosenPlant == null) {
        Console.WriteLine("\nWhich plant:");
        try {
            int userChoice = int.Parse(Console.ReadLine()!.Trim());
            chosenPlant = plants[userChoice - 1];
        }
        catch (FormatException) {
            Console.WriteLine("Please input an integer!");
        }
        catch (ArgumentOutOfRangeException) {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
            Console.WriteLine("Something went wrong, please try again!");
        }
    }


    bool validChoice = false;
    while (validChoice == false) {
        Console.WriteLine($"\nYou want to delist {chosenPlant.Species}? (Y/N)");
        try {
            string confirmChoice = Console.ReadLine()!.Trim();
            switch (confirmChoice) {
                case "y":
                case "Y":
                case "yes":
                case "Yes":
                    Console.Clear();
                    Console.WriteLine($"Delisting {chosenPlant.Species}...");
                    // Console.WriteLine("\nPress any key to continue");
                    int plantIndex = plants.IndexOf(chosenPlant);
                    plants.RemoveAt(plantIndex);
                    // Console.ReadKey();
                    // Console.Clear();
                    validChoice = true;
                    break;
                case "n":
                case "N":
                case "no":
                case "No":
                    Console.Clear();
                    Console.WriteLine($"Not delisting {chosenPlant.Species}!");
                    validChoice = true;
                    break;
                default:
                    Console.WriteLine("Please input either y or n!");
                    break;
            }

        }
        catch (FormatException) {
            Console.WriteLine("Please input either y or n!");
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
            Console.WriteLine("Something went wrong, please try again!");
        }
    }

    Console.WriteLine("\nPress any key to continue");
    Console.ReadKey();
    Console.Clear();
}

void SearchPlant() {
    bool validChoice = false;
    int maxLightLevel = 0;
    
    Console.WriteLine("What is the maximum amount of light you can provide, on a scale from 1-5?");
    while (!validChoice) {
        Console.WriteLine("Light needed:");
        int[] lightRange = [1, 2, 3, 4, 5];
        
        try {
            int response = int.Parse(Console.ReadLine()!.Trim());
            maxLightLevel = lightRange[response - 1];
            validChoice = true;
        }
        catch (IndexOutOfRangeException) {
            Console.WriteLine("Please choose a value between 1-5!");
        }
        catch (FormatException) {
            Console.WriteLine("Please input an integer!");
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
            Console.WriteLine("Something went wrong, please try again!");
        }
    }

    List<Plant> foundPlants = new List<Plant>();

    foreach (Plant plant in plants) {
        if (plant.LightNeeds <= maxLightLevel) {
            foundPlants.Add(plant);
        }
    }

    Console.Clear();
    Console.WriteLine("Here are the plants that match your needs!\n");
    foreach (Plant plant in foundPlants) {
        Console.WriteLine($"{plant.Species}, with a light need of {plant.LightNeeds}");
    }

    Console.WriteLine("");
}

void PlantOfTheDay() {
    List<Plant> availablePlants = new List<Plant>();

    foreach (Plant plant in plants) {
        if (!plant.Sold) {
            availablePlants.Add(plant);
        }
    }
    
    Random random = new Random();
    int randomInteger = random.Next(0, availablePlants.Count);

    Plant randomPlant = availablePlants[randomInteger];

    Console.WriteLine("Random Plant of the Day!");
    Console.WriteLine($"\n{randomPlant.Species}, found in {randomPlant.City}, with a light need of {randomPlant.LightNeeds}, and costs ${randomPlant.AskingPrice}\n");
}

void StatisticsMenu() {
    Console.WriteLine("Which plant stat would you like to see?\n");

    string userChoice = null;
    while (userChoice != "0") {
        Console.WriteLine(@"Choose an option:
    0. Back to Main Menu
    1. Lowest Priced Plant
    2. Number of Plants Available
    3. Plant with Highest Light Needs
    4. Average Light Needs
    5. Percentage of Plants Adoptednm,j
        ");

        userChoice = Console.ReadLine()!.Trim();
        Console.Clear();
        switch (userChoice) {
            case "0":
                break;
            case "1":
                LowestPrice();
                break;
            case "2":
                AvailablePlantsCount();
                break;
            case "3":
                HighestLightNeed();
                break;
            case "4":
                AverageLightNeed();
                break;
            case "5":
                AdoptedPlantsPercentage();
                break;
            default:
                Console.WriteLine("Invalid choice selected, please try again\n");
                break;
        }
    }
}


void LowestPrice() {
    Plant chosenPlant = plants[0];

    foreach(Plant plant in plants) {
        if (plant.AskingPrice < chosenPlant.AskingPrice) {
            chosenPlant = plant;
        }
    }
    
    Console.WriteLine($"The plant with the lowest price is {chosenPlant.Species} at ${chosenPlant.AskingPrice}\n");
}

void AvailablePlantsCount() {
    int availablePlantCount = 0;

    foreach(Plant plant in plants) {
        if (!plant.Sold & plant.AvailableUntil > DateTime.Now) {
            availablePlantCount++;
        }
    }

    Console.WriteLine($"There are currently {availablePlantCount} plants available for adoption\n");
}

void HighestLightNeed() {
    Plant foundPlant = plants[0];

    foreach (Plant plant in plants) {
        if (plant.LightNeeds > foundPlant.LightNeeds) {
            foundPlant = plant;
        }
    }

    Console.WriteLine($"The plant with the greatest light needs is {foundPlant.Species}, with a light need rating of {foundPlant.LightNeeds}\n");
}

void AverageLightNeed() {
    int totalLightNeed = 0;

    foreach (Plant plant in plants) {
        totalLightNeed += plant.LightNeeds;
    }

    double totalLightNeedAsDouble = (double)totalLightNeed;
    double averageLightNeed = totalLightNeedAsDouble / plants.Count;

    Console.WriteLine($"The average light need of all plants is {averageLightNeed}\n");
}

void AdoptedPlantsPercentage() {
    int adoptedPlants = 0;
    int availablePlants = 0;

    foreach (Plant plant in plants) {
        if (plant.Sold) {
            adoptedPlants++;
        }
        else {
            availablePlants++;
        }
    }

    double adoptedPercentage = ((double)adoptedPlants / (adoptedPlants + availablePlants)) * 100;

    Console.WriteLine($"Current adoption percentage is {adoptedPercentage}%\n");
}


string PlantDetails(Plant plant) {
    string plantString = $"{plant.Species} from {plant.City}, {plant.ZIP}, with a light need of {plant.LightNeeds}{(plant.Sold ? $", and was sold for ${plant.AskingPrice}" : "")}{(!plant.Sold & plant.AvailableUntil > DateTime.Now ? $", and is available for ${plant.AskingPrice}" : "")}";

    return plantString;
}

