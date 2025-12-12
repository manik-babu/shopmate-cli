namespace Shopmate.Utils
{
    static class ShopMateUtils
    {
        public static int ReadChoice(int[] options)
        {
            int choice;
            Console.Write("Choose: ");
            choice = Convert.ToInt32(Console.ReadLine());
            while (!Array.Exists(options, e => e == choice))
            {
                Console.WriteLine("Invalid choice. Select a valid option from the menu.");
                Console.Write("Choose: ");
                choice = Convert.ToInt32(Console.ReadLine());
            }
            return choice;
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