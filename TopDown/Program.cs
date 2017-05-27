using System;

namespace TopDown
{
    public static class Program
    {
        public static Game1 game = new Game1();

        [STAThread]
        static void Main()
        {
            using (game)
                game.Run();
        }
    }
}
