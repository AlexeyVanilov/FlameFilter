using MessageFilter.Specs;

namespace MessageFilter.Core.Modules {
    public sealed class AntiSpamModule : IModule {
        public bool enabled { get; set; } = true;
        public BaseChatFilter chat { get; init; }

        public bool FilterMessage(BaseKeyWordSystem kws, string[] input) {
            if (input.Length == 0) return true;

            var counts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (var word in input) {
                if (counts.ContainsKey(word)) {
                    counts[word]++;
                    if (counts[word] >= maxRepeatingWords) {
                        return false;
                    }
                }
                else {
                    counts[word] = 1;
                }
            }
            return true;
        }

        private readonly int maxRepeatingWords;
        public AntiSpamModule(BaseChatFilter chat, int maxRepeatingWords) {
            this.chat = chat;
            this.maxRepeatingWords = maxRepeatingWords;
        }
    }
}