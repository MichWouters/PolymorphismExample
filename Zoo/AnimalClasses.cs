namespace Zoo
{
    // An abstract class can only be inherited from. It cannot be instantiated -> Opposite of sealed
    public abstract class Animal
    {
        // A private variable can only be accessed in this class
        private string _name;

        private static int _counter;

        public int Id { get; set; }

        public int Age { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(Name));
                }

                _name = value;
            }
        }

        // A Protected Property or Method can only be accessed in this class or derived classes
        protected Animal(string name)
        {
            Id = ++_counter;
            Name = name;
        }

        // A virtual method can be overridden or expanded upon in derived classes
        public virtual string GetAnimalCall()
        {
            return "Animal noise goes here";
        }
    }

    public abstract class Carnivore : Animal
    {
        public string[] FavouritePrey { get; set; }

        public bool IsDangerousToHumans { get; set; }

        // A class that derives from a class with a constructor with variables must provide those variables (base).
        protected Carnivore(string name, string[] favouritePrey, bool isDangerousToHumans)
            : base(name)
        {
            FavouritePrey = favouritePrey;
            IsDangerousToHumans = isDangerousToHumans;
        }

        // Overriding a method allows us to override all existing functionality
        public override string GetAnimalCall()
        {
            return "This predator can roar fiercely:";
        }
    }

    public abstract class Herbivore : Animal
    {
        public string[] FavouriteFoods { get; set; }

        protected Herbivore(string name, string[] favouriteFoods)
            : base(name)
        {
            FavouriteFoods = favouriteFoods;
        }

        // Overriding a method allows us to override all existing functionality
        public override string GetAnimalCall()
        {
            return "This docile herbivore has a lovely call:";
        }
    }

    public class Cat : Carnivore
    {
        public bool IsHouseCat { get; set; }

        public Cat(string name, string[] favouritePrey, bool isDangerousToHumans, bool isHouseCat)
            : base(name, favouritePrey, isDangerousToHumans)
        {
            IsHouseCat = isHouseCat;
        }

        // Overriding can also use what is already there and expand upon it.
        public override string GetAnimalCall()
        {
            return $"{base.GetAnimalCall()} MEOW!";
        }
    }

    public class Dog : Carnivore
    {
        public bool IsGoodBoy { get; set; }

        // Default parameters allow for a default value -> These set a value if none is provided
        public Dog(string name, string[] favouritePrey, bool isDangerousToHumans, bool isGoodBoy = true)
            : base(name, favouritePrey, isDangerousToHumans)
        {
            IsGoodBoy = isGoodBoy;
        }

        public void FetchStick()
        {
            Console.WriteLine("That stick never had a chance");
        }

        // Overriding can also use what is already there and expand upon it.
        public override string GetAnimalCall()
        {
            return $"{base.GetAnimalCall()} BARK BARK";
        }
    }

    public class Cow : Herbivore
    {
        private int _amountOfStomachs;

        public int AmountOfStomachs
        {
            get => _amountOfStomachs;
            set
            {
                if (value > 0)
                {
                    _amountOfStomachs = value;
                }
            }
        }

        public Cow(string name, string[] favouriteFoods, int amountOfStomachs = 4)
            : base(name, favouriteFoods)
        {
            AmountOfStomachs = amountOfStomachs;
        }

        public void ProduceMilk()
        {
            Console.WriteLine("Milk for the milk gods!");
        }

        // Overriding can also use what is already there and expand upon it.
        public override string GetAnimalCall()
        {
            return $"{base.GetAnimalCall()} MOOOOOO!";
        }
    }
}