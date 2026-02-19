namespace IT_STEP
{
    class Program
    {
        static void Main()
        {
            var repository = new DogRepository();

            while (true)
            {
                Console.WriteLine("\n=== DOG SHELTER MANAGEMENT ===");
                Console.WriteLine("1. Add a new dog");
                Console.WriteLine("2. View all dogs");
                Console.WriteLine("3. View dogs in shelter");
                Console.WriteLine("4. View adopted dogs");
                Console.WriteLine("5. Search dog");
                Console.WriteLine("6. Update dog by Id");
                Console.WriteLine("0. Exit");

                Console.Write("Select an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddDog(repository);
                        break;

                    case "2":
                        DisplayDogs(repository.GetAllDogs());
                        break;

                    case "3":
                        DisplayDogs(repository.GetAvailableDogs());
                        break;

                    case "4":
                        DisplayDogs(repository.GetAdoptedDogs());
                        break;

                    case "5":
                        SearchDog(repository);
                        break;

                    case "6":
                        UpdateDog(repository);
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        static void AddDog(DogRepository repository)
        {
            Console.Write("Enter dog name: ");
            string name = Console.ReadLine();

            Console.Write("Enter dog age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter dog breed: ");
            string breed = Console.ReadLine();

            var dog = new Dog
            {
                Name = name,
                Age = age,
                Breed = breed
            };

            repository.AddDog(dog);
            Console.WriteLine("Dog added successfully.");
        }

        static void SearchDog(DogRepository repository)
        {
            Console.WriteLine("Search by:");
            Console.WriteLine("1. Id");
            Console.WriteLine("2. Name");
            Console.WriteLine("3. Breed");

            Console.Write("Choose search type: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write("Enter Id: ");
                    int id = int.Parse(Console.ReadLine());
                    var dogById = repository.GetDogById(id);

                    if (dogById != null)
                        PrintDog(dogById);
                    else
                        Console.WriteLine("Dog not found.");
                    break;

                case "2":
                    Console.Write("Enter name: ");
                    var name = Console.ReadLine();
                    DisplayDogs(repository.SearchByName(name));
                    break;

                case "3":
                    Console.Write("Enter breed: ");
                    var breed = Console.ReadLine();
                    DisplayDogs(repository.SearchByBreed(breed));
                    break;

                default:
                    Console.WriteLine("Invalid search option.");
                    break;
            }
        }

        static void UpdateDog(DogRepository repository)
        {
            Console.Write("Enter dog Id to update: ");
            int id = int.Parse(Console.ReadLine());

            var dog = repository.GetDogById(id);

            if (dog == null)
            {
                Console.WriteLine("Dog not found.");
                return;
            }

            Console.Write("Enter new name: ");
            dog.Name = Console.ReadLine();

            Console.Write("Enter new age: ");
            dog.Age = int.Parse(Console.ReadLine());

            Console.Write("Enter new breed: ");
            dog.Breed = Console.ReadLine();

            Console.Write("Is adopted? (true/false): ");
            dog.IsAdopted = bool.Parse(Console.ReadLine());

            repository.UpdateDog(dog);
            Console.WriteLine("Dog updated successfully.");
        }

        static void DisplayDogs(System.Collections.Generic.IEnumerable<Dog> dogs)
        {
            foreach (var dog in dogs)
            {
                PrintDog(dog);
            }
        }

        static void PrintDog(Dog dog)
        {
            Console.WriteLine(
                $"Id: {dog.Id}, Name: {dog.Name}, Age: {dog.Age}, Breed: {dog.Breed}, Adopted: {dog.IsAdopted}");
        }
    }
}
