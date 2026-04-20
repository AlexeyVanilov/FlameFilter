namespace MessageFilter.Specs {
    public interface IModule {
        BaseChatFilter chat { get; init; }
        bool enabled { get; set; }
        bool FilterMessage(BaseKeyWordSystem keyWordSystem, string[] input);
    }
}