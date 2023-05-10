namespace ZooManagementSystem
{
    public class Caretaker : Worker
    {
        List<Animal> animalList;
        public Caretaker(string name, List<Animal> animalList) : base(name)
        {
            this.animalList = animalList;
        }

        public void FeedAnimals()
        {
            foreach (Animal animal in animalList)
            {
                if (animal.IsFed) 
                {
                    Console.WriteLine($"{animal.Name} is fed");
                }
                else
                {
                    Console.WriteLine($"Feeding {animal.Name}");
                    animal.IsFed = true;
                    Console.WriteLine($"{animal.Name} was fed");
                }
            }
        }
    }
}
