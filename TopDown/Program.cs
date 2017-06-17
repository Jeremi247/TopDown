using SharpRaven;
using SharpRaven.Data;
using System;

namespace TopDown
{
    public static class Program
    {
        public static Game1 game = new Game1();

        [STAThread]
        static void Main()
        {
			try
			{
				using (game)
					game.Run();
			}
			catch (Exception e)
			{
				var ravenClient = new RavenClient("https://12ee265ead35440c8adc29e804382f4e:0471e3c336734908b09aa99a4d474a22@sentry.io/180679");
				ravenClient.Capture(new SentryEvent(e));
			}
		}
    }
}
