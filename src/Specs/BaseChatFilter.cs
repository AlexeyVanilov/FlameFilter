using MessageFilter.Models;

namespace MessageFilter.Specs {
    public abstract class BaseChatFilter {
        private int _index;
        public abstract IModule[] modules { get; init; }
        public abstract Action<string> onMessageCancelled { get; set; }
        public abstract Action onMessageAccepted { get; set; }
        public ListType listType { get; init; }

        public void AddModule(IModule module) {
            if (_index < modules.Length) {
                modules[_index] = module;
                _index++;
            }
        }
        public bool ActivateModule(BaseKeyWordSystem kws, IModule module, string[] s) {
            if (!module.enabled) return true;
            return module.FilterMessage(kws, s);
        }
    }
}