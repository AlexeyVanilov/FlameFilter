using MessageFilter.Models;
using MessageFilter.Specs;
using MessageFilter.Utils;

namespace MessageFilter.Core {
    public static class MessageListener {
        public static bool FilterMessage(BaseChatFilter chat, BaseKeyWordSystem keyWordSystem, string input) {
            if (CanFilterMessage(input, chat, chat.maxInputLength)) return true;

            string[] words = StringUtils.Dispatch(' ', input); 

            //Module iterations
            for(int i = 0; i < chat.modules.Length; i++) {
                IModule module = chat.modules[i];
                if (module == null) continue;

                if (!chat.ActivateModule(keyWordSystem, module, words))
                {
                    chat.onMessageCancelled?.Invoke(Messages.onMessageCancelled);
                    return false;
                }
            }
            chat.onMessageAccepted?.Invoke();
            return true;
        }

        private static bool CanFilterMessage(string input, BaseChatFilter chat, int maxInputLength) =>
            string.IsNullOrWhiteSpace(input) || chat?.modules == null || chat.modules.Length == 0 || input.Length > maxInputLength;
    }
}