double BoxA, BoxB, BoxC, BoxD, BoxE, BoxF, BoxG, BoxH, BoxI;
BoxA = 45;
BoxB = 56;
BoxC = BoxA + BoxB;
BoxD = BoxA - BoxB;
BoxE = BoxA * BoxB;
BoxF = BoxB / BoxA;
BoxG = BoxA % BoxB;
BoxH = ++BoxA;
BoxI = --BoxB;

//Addition
Console.WriteLine("The Addition result is " + BoxC);

//Substraction
Console.WriteLine("The Substraction result is " + BoxD);

//Multiplication
Console.WriteLine("The Multipliation result is " + BoxE);

//Division
Console.WriteLine("The Division result is " + BoxF);

//Modulus
Console.WriteLine("The Modulus result is " + BoxG);

//Increment
Console.WriteLine("The Increment result is " + BoxH);

//Decrement
Console.WriteLine("The Decrement result is " + BoxI);