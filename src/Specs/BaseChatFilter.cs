using MessageFilter.Models;
using Utils;

namespace MessageFilter.Specs {
    public abstract class BaseChatFilter {
        protected const int defaultMaxInputLength = 750;

        public Arcane<IModule> modules { get; init; }
        public abstract Action<string> onMessageCancelled { get; set; }
        public abstract Action onMessageAccepted { get; set; }
        public int maxInputLength { get; protected set; }
        public ListType listType { get; init; }

        public void AddModule(IModule module) => modules.Add(module);
        public bool ActivateModule(BaseKeyWordSystem kws, IModule module, string[] s) {
            if (!module.enabled) return true;
            return module.FilterMessage(kws, s);
        }
    }
}