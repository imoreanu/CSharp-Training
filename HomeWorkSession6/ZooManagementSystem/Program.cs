using ZooManagementSystem;

Elephant elephant = new Elephant("Dumbo", "Veggies");
Giraffe giraffe = new Giraffe("Mellaman", "Leaves");
Tiger tiger = new Tiger("SheerKhan", "Meat");

List<Animal> animalList = new List<Animal>
{
    elephant,
    giraffe,
    tiger
};

Caretaker caretaker = new Caretaker("Mark", animalList);
caretaker.FeedAnimals();

TicketVendor ticketVendor = new TicketVendor("Johnny");
ticketVendor.SellTickets(100);
ticketVendor.SellTickets(50);
Console.WriteLine($"{ticketVendor.Name} sold {ticketVendor.SoldTickets} tickets");