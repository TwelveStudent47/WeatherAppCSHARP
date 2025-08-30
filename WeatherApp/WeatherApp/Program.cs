namespace WeatherApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of days to simulate: ");
            int days = int.Parse(Console.ReadLine());

            //Inicializáljuk a listát, annyi szám lesz benne amennyit a felhasználó beütött
            int[] temperature = new int[days];
            //Létrehozzuk az időjárási viszonyokat, amik közül lehet választani
            string[] conditions = { "Sunny", "Rainy", "Cloudy", "Snowy" };
            //Inicializáljuk a listát, amiben tárolni fogjuk azon a napi időjárási viszonyt
            string[] weatherConditions = new string[days];

            Random random = new Random();

            //Legeneráljuk a fokokat azalapján, hogy a felhasználó hány napot írt be
            for (int i = 0; i < days; i++)
            {
                //Létrehozza az aznapi fokot
                temperature[i] = random.Next(-10, 40);

                // Egy if statement ha a random választott fok 0 alatt lenne akkor alapból a "Snowy" időjárási viszonyt válassza ki
                //Viszont ha a feltétel nem teljesül akkor válasszon random és ha nem 0 alatt van akkor ne lehessen a "Snowy"-t kiválasztani
                if (temperature[i] < 0)
                {
                    weatherConditions[i] = conditions[conditions.Length - 1];
                }
                else
                {
                    weatherConditions[i] = conditions[random.Next(conditions.Length - 1)];
                }
            }

            foreach (var item in temperature)
            {
                Console.WriteLine(item);
            }

            foreach (var item in weatherConditions)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"The Avarage Temperature is: {CalculateAvg(temperature)}");

            Console.ReadKey();
        }

        static float CalculateAvg(int[] temps)
        {
            // Létrehozzuk az összeg változót, hogy tudjuk tárolni a listában lévő számok összegét(double, mivel az átlagnak nem egész számnak kell lennie minden esetben
            float sum = 0;

            //Átmegyünk egyesével a listán és minden elemet hozzáadjuk az összeg változónk jelenlegi értékéhez
            foreach (var item in temps)
            {
                sum += item;
            }

            float avg = sum / temps.Length;

            return avg;
        }
    }
}
