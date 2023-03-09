// See https://aka.ms/new-console-template for more information

using GymnastikForening;
using Microsoft.VisualBasic;

//Hold h1 = new Hold("Tumle22t", 2022, "Tumlinger", 500, 20);
//Hold h2 = new Hold("Rollinger22s", 2022, "Rollinger", 700, 15);
//Console.WriteLine(h1);
//Console.WriteLine(h2);


HoldKatalog holdKatalog = new HoldKatalog();
//try
//{
//    holdKatalog.TilføjHold(h1);
//    holdKatalog.TilføjHold(h2);
//}
//catch (ArgumentException aex)
//{
//    Console.WriteLine("Fejl ved tilføjelse af hold");
//}

Console.WriteLine(holdKatalog); //udskriving vha. ToString metode


Deltager d1 = new Deltager("Poul Henriksen", "Vej 123", 3);
Deltager d2 = new Deltager("Charlotte Heegaard", "Gade 321", -1);
Deltager d3 = new Deltager("Ole Olsen", "Aleen 177", 3);
Deltager d4 = new Deltager("Anne Antonsen", "Street 321", 7);

Console.WriteLine(d1);
Console.WriteLine(d2);

Hold h1 = new Hold("Tumle22t", 2022, "Tumlinger", 500, 20);
Hold h2 = new Hold("Rollinger22s", 2022, "Rollinger", 700, 15);
Hold h3 = new Hold("Tumle23k", 2023, "Tumlinger", 500, 5);
try
{
    h3.TilmeldDeltager(d1); 
    //h3.TilmeldDeltager(d2);
    h1.TilmeldDeltager(d3);
    h2.TilmeldDeltager(d4);
    h2.TilmeldDeltager(d3);
}
catch(FuldtHoldException fex)
{
    Console.WriteLine(fex.Message);
}
catch(ArgumentException aex)
{
    Console.WriteLine(aex.Message);
}
catch(Exception ex)
{
    Console.WriteLine("generel fejl!");
}
finally
{
    Console.WriteLine("Denne  del udføres altid. Er ikke relevant i dette tilfælde!");
}
try
{
    holdKatalog.TilføjHold(h1);
    holdKatalog.TilføjHold(h2);
    holdKatalog.TilføjHold(h3);
}
catch (ArgumentException aex)
{
    Console.WriteLine("Fejl ved tilføjelse af hold");
}
Console.WriteLine("\nAntaltilmeldte");
Console.WriteLine( $"Antal tilmeldte på h2 {h2.AntalTilmeldte()}");

Console.WriteLine("\nFindHold iterativ");
Hold foundHold = holdKatalog.FindHold("Rollinger22s");
if (foundHold != null)
    Console.WriteLine(foundHold);

Console.WriteLine("\nFindHoldLinq");
Hold foundHoldl = holdKatalog.FindHoldLinq("Rollinger22s");
if (foundHold != null)
    Console.WriteLine(foundHoldl);

Console.WriteLine("\nFindAntalHold iterativ");
int foundHoldAntal = holdKatalog.FindAntalHold("Tumlinger");
Console.WriteLine(foundHoldAntal);
Console.WriteLine("\nFindAntalHoldLinq");
int foundAntalHoldl = holdKatalog.FindAntalHoldLinq("Tumlinger");
Console.WriteLine(foundAntalHoldl);


Console.WriteLine("\nSamletAntalDeltagerePåAlleHold");
Console.WriteLine($"Samlet antal deltagere på alle hold {holdKatalog.SamletAntalDeltagerePåAlleHold()} ");
Console.WriteLine($"Samlet antal deltagere på alle hold linq {holdKatalog.SamletAntalDeltagerePåAlleHoldLinq()} ");


Console.WriteLine($"Antal hold med navn \"Rollinger\" iterativ { holdKatalog.FindAntalHold("Rollinger")}");
Console.WriteLine($"Antal hold med navn \"Tumlinger\" iterativ {holdKatalog.FindAntalHold("Tumlinger")}");
Console.WriteLine($"Antal hold med navn \"Rollinger\" Linq {holdKatalog.FindAntalHoldLinq("Rollinger")}");
Console.WriteLine($"Antal hold med navn \"Tumlinger\" Linq {holdKatalog.FindAntalHoldLinq("Tumlinger")}");


Console.WriteLine($"GennemsnitligeDeltagerePrHold iterativ {holdKatalog.GennemsnitligeDeltagerePrHold()} ");
Console.WriteLine($"GennemsnitligeDeltagerePrHold linq {holdKatalog.GennemsnitligeDeltagerePrHoldLinq()}");


Console.WriteLine("\nHent holdliste iterativ");
foreach (Hold hold in holdKatalog.HentHoldListe("Tumlinger"))
{
    Console.WriteLine(hold);
}

Console.WriteLine("\nHent holdliste Linq");
foreach (Hold hold in holdKatalog.HentHoldListeLinq("Tumlinger"))
{
    Console.WriteLine(hold);
}


Console.WriteLine($"\nFlestDeltagerePåHold iterativ {holdKatalog.FlestDeltagerePåHold()}");
Console.WriteLine($"FlestDeltagerePåHold Linq {holdKatalog.FlestDeltagerePåHoldLinq()}");


Console.WriteLine($"\nHoldMedFlestDeltagere() iterativ {holdKatalog.HoldMedFlestDeltagere()} antal tilmeldte {holdKatalog.HoldMedFlestDeltagere().AntalTilmeldte()}");
Console.WriteLine($"\nHoldMedFlestDeltagereLinq() Linq {holdKatalog.HoldMedFlestDeltagereLinq()} antal tilmeldte {holdKatalog.HoldMedFlestDeltagereLinq().AntalTilmeldte()}");



Console.WriteLine($"\nHoldMedHøjstIndtjenning() iterativ {holdKatalog.HoldMedHøjstIndtjenning()} \n");


Ansat a1 = new Ansat("Poul", "Gade 123", "12121212", "Pedel");
Ansat u1 = new Underviser("Charlotte", "Vej 321", "3434344", "Super instruktør", "Gymnastik instruktør uddannelse", true);
Ansat ad1 = new Administrator("Carina", "Alleen 777", "7878787", "Direktør", "Overordnet ledelsesansvar");
Console.WriteLine(a1);
Console.WriteLine(u1);
Console.WriteLine(ad1);

Console.WriteLine("Generic repository");
GenericRepository<Ansat> ansatte = new GenericRepository<Ansat>();
Ansat an1 = new Ansat("Peter", "Gade 231", "1212", "Chief");

Ansat an2 = new Underviser("Kurt", "Street", "4545", "Instruktør", "Gymnastik kursus basis", true);

ansatte.Add(a1);
ansatte.Add(u1);
ansatte.Add(ad1);
ansatte.Add(an1);
ansatte.Add(an2);
foreach(IAnsat a in ansatte.List)
{
    Console.WriteLine(a);
}
Console.WriteLine("Remove");
Ansat an1ToRemove = new Ansat("Peter", "Gade 231", "1212", "Chief");
ansatte.Remove(an1ToRemove);
foreach (IAnsat a in ansatte.List)
{
    Console.WriteLine(a);
}
Console.WriteLine("Update");
Ansat an2UpdateNew = new Underviser("Kurt Petersen", "Gadegade 444", "4545", "Instruktør", "Gymnastik kursus basis", true);
ansatte.Update(an2, an2UpdateNew);
foreach (IAnsat a in ansatte.List)
{
    Console.WriteLine(a);
}

Console.WriteLine("Udskrivning sorteret");
ansatte.List.Sort();
foreach (IAnsat a in ansatte.List)
{
    Console.WriteLine(a);
}



Console.ReadLine();


