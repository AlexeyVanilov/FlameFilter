using MessageFilter.Specs;
using Utils;

namespace MessageFilter.Core {
    /// <summary>
    /// Chat contains modules and events. capacity of modules is immutable, you must define modules capacity on start
    /// </summary>
    public sealed class ChatFilter : BaseChatFilter {
        public ChatFilter(int modulesCapacity, int maxInputLength = defaultMaxInputLength) {
            //set modules array capacity
            modules = new Arcane<IModule>(modulesCapacity);
            this.maxInputLength = maxInputLength;
        }

        public override Action<string> onMessageCancelled { get; set; }

        public override Action onMessageAccepted { get; set; }
    }
}