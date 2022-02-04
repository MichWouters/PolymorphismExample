using Zoo;

Console.WriteLine("Hello, World!");

IList<Animal> animals = GenerateAnimals();
PrintAnimals(animals);

IList<Animal> GenerateAnimals()
{
    // Polymorphism -> Derived classes can take the shape of their base class
    // Constructor values MUST be provided. Public Properties are optional
    Animal cat = new Cat("Felix", new[] { "birds", "mice" }, false, true) { Age = 2 };
    Animal dog = new Dog("Max", new[] { "cats" }, false, false) { Age = 4 };

    // Default params don't need to be set. (Amount of stomachs)
    Animal cow = new Cow("Bella", new[] { "Grass" });

    /* Polymorphism and generics: A generic<T> list can store a list of any data type.
        * But, once the data type is set, that list can only store objects of that type. E.g. A list of int cannot contain a string.
        * Inheritance is a 'is - a ' relationship -> Cat is an animal, dog is an animal.
        * Ergo -> These can be stored in a list of animals.
     */
    IList<Animal> animals = new List<Animal>();
    animals.Add(cat);
    animals.Add(dog);
    animals.Add(cow);
    return animals;
}

void PrintAnimals(IList<Animal> animals)
{
    foreach (Animal animal in animals)
    {
        // We can access all Properties of the Animal class in each of the animals.
        Console.WriteLine($"Animal Id: {animal.Id}");
        Console.WriteLine($"Name: {animal.Name}");
        Console.WriteLine($"Age: {animal.Age}");

        // Polymorphism and overriding
        // Thanks to overriding, we can call the same method X amount of times and get a different result, based on the type of class being handled.
        Console.WriteLine(animal.GetAnimalCall());

        // BUT, we cannot access the extra Properties and Methods in the derived classes.
        // To access these, we have to perform a conversion.
        // Is and As are perfect for this as they check if the type can be converted first.
        Carnivore carnivore = animal as Carnivore;
        if (carnivore is not null)
        {
            // Single Responsability -> One methodod = One responsability
            PrintCarnivoreInfo(carnivore);
        }

        Herbivore herbivore = animal as Herbivore;
        if (herbivore is not null)
        {
            PrintHerbivoreInfo(herbivore);
        }

        Console.WriteLine("-------------------------------------");
        Console.WriteLine();
    }

    Console.ReadLine();
}

void PrintCarnivoreInfo(Carnivore carnivore)
{
    Console.WriteLine($"This predator enjoys hunting: {string.Join(" and ", carnivore.FavouritePrey)}");
    Console.WriteLine($"Is this predator lethal to humans?: {(carnivore.IsDangerousToHumans ? "Yes" : "No")}");

    Cat cat = carnivore as Cat;
    if (cat != null)
    {
        Console.WriteLine($"Is this kitty a house cat?: {(cat.IsHouseCat ? "Yes" : "No")}");
    }

    Dog dog = carnivore as Dog;
    if (dog != null)
    {
        Console.WriteLine($"Is this dog a good boy?: {(dog.IsGoodBoy ? "Ofcourse" : "No, but actually yes")}");
        dog.FetchStick();
    }
}

void PrintHerbivoreInfo(Herbivore herbivore)
{
    Console.WriteLine($"This herbivore enjoys: {string.Join("and", herbivore.FavouriteFoods)}");

    // Is returns a bool -> If true, this class can be derived into a deriving class
    // As is usually more performant.
    if (herbivore is Cow)
    {
        Cow cow = (Cow)herbivore;
        Console.WriteLine($"This cow has {cow.AmountOfStomachs} stomachs");

        cow.ProduceMilk();
    }
}