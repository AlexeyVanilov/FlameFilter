using MessageFilter.Core;
using MessageFilter.Core.Modules;

namespace Examples {
    public static class Program {
        private static KeyWordSystem keyWordSystem;
        private static ChatFilter chatFilter;
        private static bool isRunning = true;
        public static void Main(string[] args) {
            Setup();

            while(isRunning) {
                string input = Console.ReadLine();
                bool success = MessageListener.FilterMessage(chatFilter, keyWordSystem, input);
                if (!success) {
                    DenyMessage();
                }
            }
        }
        public static void Setup() {
            chatFilter = new ChatFilter(2);
            keyWordSystem = new KeyWordSystem(chatFilter);
            chatFilter.AddModule(new BanWordModule(chatFilter));
            chatFilter.AddModule(new AntiSpamModule(chatFilter, 3));

            keyWordSystem.Register("bed");
            keyWordSystem.Register("book");
            keyWordSystem.Register("workbench");
            keyWordSystem.Register("anvil");

            chatFilter.onMessageCancelled += RedLine;
        }

        public static void RedLine(string msg) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void DenyMessage() {
            Thread.Sleep(500);
            Console.Clear();
        }
    }
}