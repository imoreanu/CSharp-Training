using static System.Console;

namespace ZooManagementSystem
{
    public class Animal
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Diet { get; set; }
        public bool IsFed { get; set; }
        public ConsoleColor Color { get; set; }
        public Animal(string type, string name, string diet, ConsoleColor color)
        {
            Type = type;
            Name = name;
            Diet = diet;
            Color = color;
        }

        public void Greet()
        {
            ForegroundColor = Color;
            WriteLine($"The {Type} attempts to pronounce its own name: {Name}");
            ResetColor();
        }
    }
}
