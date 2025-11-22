namespace Shopmate.Utils
{
    static class ShopMateUtils
    {
        public static int ReadChoice(int[] options)
        {
            int choice;
            Console.Write("=> ");
            choice = Convert.ToInt32(Console.ReadLine());
            while (!Array.Exists(options, e => e == choice))
            {
                Console.WriteLine("Invalid choice. Select a valid option from the menu.");
                Console.Write("=> ");
                choice = Convert.ToInt32(Console.ReadLine());
            }
            return choice;
        }

        public static void Loading(string topic, int time)
        {
            Console.Write(topic);
            Thread.Sleep(time / 4);
            Console.Write(".");
            Thread.Sleep(time / 4);
            Console.Write(".");
            Thread.Sleep(time / 4);
            Console.Write(".");
            Thread.Sleep(time / 4);
            Console.WriteLine();
        }
        public static void Loading(int time)
        {
            Thread.Sleep(time);
        }
        public static void PageName(string name)
        {
            int width = 50;
            for (int i = 0; i <= width; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            for (int i = 0; i <= (width - name.Length) / 2; i++)
            {
                Console.Write(" ");
            }
            Console.Write($" {name} ");
            Console.WriteLine();
            for (int i = 0; i <= width; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine();
        }
    }
}