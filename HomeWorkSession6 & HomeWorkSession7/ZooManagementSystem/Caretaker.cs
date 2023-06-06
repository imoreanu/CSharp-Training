using static System.Console;

namespace ZooManagementSystem
{
    public class Caretaker : Worker
    {
        public List<Animal> animalList;
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
                    WriteLine($"The {animal.Type} is fed");
                }
                else
                {
                    WriteLine($"\nFeeding the {animal.Type}");
                    animal.IsFed = true;
                    WriteLine($"The {animal.Type} was fed");
                }
            }
        }
    }
}
