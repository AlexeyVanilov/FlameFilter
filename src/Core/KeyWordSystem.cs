using MessageFilter.Specs;

namespace MessageFilter.Core {
    public sealed class KeyWordSystem : BaseKeyWordSystem {
        public KeyWordSystem(BaseChatFilter chat) {
            currentChat = chat;
        }
    }
}