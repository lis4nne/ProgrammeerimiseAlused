Console.WriteLine("Hello, World!");

//1, Arvuti mõtleb arvu 1-20
Random rnd = new Random();
int arvutiArv = rnd.Next(1, 21); //genereerib arvu

bool arvAraArvatud = false;

while (!arvAraArvatud)
{
    
//2. Küsimus ja kasutaja sisend
Console.WriteLine("Arva ära arv (1-20):");
int kasutajaArv = Convert.ToInt32(Console.ReadLine());
    
 //3. Kas arv oli õige või vale?
 if(kasutajaArv == arvutiArv)
{
    Console.WriteLine("Õige! Arvasid ära");
        arvAraArvatud = true;
}

if(kasutajaArv > arvutiArv)
{
    Console.WriteLine("Arv on väiksem.");
}

if(kasutajaArv < arvutiArv)
{
    Console.WriteLine("Arv on suurem.");
}
    
}
Console.WriteLine("Vajuta Enter, et sulgeda programm...");
Console.ReadLine();