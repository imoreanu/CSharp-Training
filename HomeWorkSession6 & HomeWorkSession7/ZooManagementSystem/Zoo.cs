using static System.Console;
namespace ZooManagementSystem
{
    class Zoo
    {
        public Zoo()
        {
            Title = "Zoo Management System";
            WriteLine(@"
███████╗ ██████╗  ██████╗ 
╚══███╔╝██╔═══██╗██╔═══██╗
  ███╔╝ ██║   ██║██║   ██║
 ███╔╝  ██║   ██║██║   ██║
███████╗╚██████╔╝╚██████╔╝
╚══════╝ ╚═════╝  ╚═════╝            
");
            WriteLine("Welcome to the Zoo!");

            VisitigSchedule visitigSchedule = new(DayOfWeek.Tuesday, DateTime.Now);
            visitigSchedule.ZooSchedule();
            
            WriteLine("\nHere are the zoo animals: \n");

            Animal elephant = new("Elephant","Dumbo", "Veggies", ConsoleColor.Blue);
            elephant.Greet();
            Animal giraffe = new("Giraffe", "Mellaman", "Leaves", ConsoleColor.DarkYellow);
            giraffe.Greet();
            Animal panther = new("Panther", "Baaghera", "Meat", ConsoleColor.Red);
            panther.Greet();

            List<Animal> animalList = new()
            {
                elephant,
                giraffe,
                panther
            };

            Caretaker caretaker = new("Mark", animalList);
            caretaker.FeedAnimals();

            TicketVendor ticketVendor = new("Johnny", 200, 150);
            ticketVendor.SellTickets(150);
            WriteLine($"\n{ticketVendor.Name} sold {ticketVendor.SoldTickets} tickets");

            WriteLine("\n\nPress any key to exit...");
            ReadKey(true);
        }
    }
}
