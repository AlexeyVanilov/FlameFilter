namespace MessageFilter.Specs {
    public abstract class BaseKeyWordSystem {
        public readonly HashSet<string> _keyWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        public BaseChatFilter currentChat { get; init; }
        public int KeyWordsCount { get; }
        public void Register(string s) => _keyWords.Add(s);
        public bool Contains(string s) => _keyWords.Contains(s);
    }
}