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
            Console.WriteLine($"The max temp was: {MaxTemperature(temperature)}");
            Console.WriteLine($"The min temp was: {MinTemperature(temperature)}");
            Console.WriteLine(MostCommonConditions(weatherConditions));


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

        static int MinTemperature(int[] temperature)
        {
            // A hőmérsékletek közül kiválasztjuk a legelsőt, mint legkissebb
            int min = temperature[0];
            // Átmegyünk a listán
            foreach (var item in temperature)
            {
                // Ha az aktuális elem kisebb, mint a jelenlegi min, akkor az aktuális legyen a min
                if (item < min)
                {
                    min = item;
                }
            }
            return min;
        }

        static int MaxTemperature(int[] temperature)
        {
            // A hőmérsékletek közül kiválasztjuk a legelsőt, mint legnagyobb
            int max = temperature[0];
            // Átmegyünk a listán
            foreach (var item in temperature)
            {
                // Ha az aktuális elem nagyobb, mint a jelenlegi max, akkor az aktuális legyen a max
                if (item > max)
                {
                    max = item;
                }
            }
            return max;
        }

        static string MostCommonConditions(string[] conditions)
        {
            // A jelenlegi legtöbbet megjelenő időjárási viszony számlálója
            int count = 0;
            // A legtöbbet megjelenő időjárási viszony számlálója
            string mostCommon = conditions[0];

            // Végig megyünk a kapott listán és egyesével kiválasztjuk a listában levő időjárási viszonyokat
            for (int i = 0; i < conditions.Length; i++)
            {
                //Inicializáljuk a változót, ami azért szolgál, hogy megszámolja, hogy az adott időjársi viszony hányszor szerepel a listában
                int tempCount = 0;
                for (int j = 0;  j < conditions.Length; j++)
                {
                    Console.WriteLine("Test2: " + conditions[j]);
                    // Végigmegyünk a listán, és ellenőrizzük, hogy hányszor van jelen az első for loopban lévő időjárásiviszony a jelen futó for loopban ami megint végig megy az egész listán
                    // Ha a 2. for loopban lévő item megegyezik az elsővel akkor a tempCounthoz hozzáadunk egyet
                    if (conditions[j] == conditions[i])
                    {
                        tempCount++;
                    }
                }
                // Ha a tempCount nagyobb, mint a jelenlegi count akkor a count új értéke a tempCount lesz, illetve a leggyakoribb változót is átváltoztatjuk arra az elemre, amely az 1. for loopban van
                if (tempCount > count)
                {
                    count = tempCount;
                    mostCommon = conditions[i];
                }
            }
            return mostCommon;
        }
    }
}
