using MessageFilter.Models;
using MessageFilter.Specs;

namespace MessageFilter.Core.Modules {
    public sealed class BanWordModule : IModule {
        public BaseChatFilter chat { get; init; }
        public bool enabled { get; set; } = true;
        public bool FilterMessage(BaseKeyWordSystem kws, string[] input) {
            switch (chat.listType) {
                case ListType.Blacklist:
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (kws.Contains(input[i])) {
                            return false;
                        }
                    }
                    break;
                case ListType.Whitelist:
                    for (int i = 0; i < input.Length; i++) {
                        if (!kws.Contains(input[i])) {
                            return false;
                        }
                    }
                    break;
            }
            return true;
        }

        public BanWordModule(BaseChatFilter chat) {
            this.chat = chat;
        }
    }
}