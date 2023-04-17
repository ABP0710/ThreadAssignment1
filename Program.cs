using System.Net.Http.Headers;

namespace ThreadAssignment1
{

    internal class Program
    {
        //Øvelse 1:
        public void WorkThreadFunction()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("C#-trådning er nemt!");
                //Thread.Sleep(1000); 
            }
            //Thread.Sleep(1000);
            Console.WriteLine(Thread.CurrentThread.Name);
        }

        //Øvelse 2:
        public void WorkThreadFunction1()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Også med flere tråde.....");
                //Thread.Sleep(1000); hvis thread.sleep er inde i forloopet på begge metoder, udskrives trådenene skiftevis i consolen og afslutter med trådenes navne.
            }
            //Thread.Sleep(1000); ligger thread.sleep uden for forloopet, men før cw med trådens navn, udskrives forloops først i begge tråde inden trådenes navne udskrives.
            Console.WriteLine(Thread.CurrentThread.Name);
        }

        //Øvelse 3:
        static void temp()
        {
            Random rnd = new Random();

            int alarmCount = 0;
            do
            {
                int temperatur = rnd.Next(-20, 120);
                Console.WriteLine(temperatur);
                Thread.Sleep(500);
                if (temperatur < 0 || temperatur > 100)
                {
                    alarmCount++;
                    Console.WriteLine("Alarm aktiv");
                }
            } while (alarmCount < 3);
        }


        class threprog
        {
            public static void Main()
            {
                Program pg = new Program();


                //tråden til Øvelse 1:
                Thread t0 = new Thread(new ThreadStart(pg.WorkThreadFunction));
                t0.Name = "Tråd 0";
                t0.Start();
                t0.Join();

                //tråden til øvelse 2:
                Thread t1 = new Thread(new ThreadStart(pg.WorkThreadFunction1));
                t1.Name = "Tråd 1";
                t1.Start();
                t1.Join();

                //tråden til øvelse 3:
                Thread t = new Thread(temp);
                t.Start();
                while (t.IsAlive)
                {
                    Thread.Sleep(10000);
                    Console.WriteLine("Tråden lever!");
                }
                t.Join();
                Console.WriteLine("Alam tråd termineret");
                Console.ReadKey();




                Console.Read();
            }
        }
    }
}