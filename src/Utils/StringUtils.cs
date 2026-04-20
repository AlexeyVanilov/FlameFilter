namespace MessageFilter.Utils {
    public static class StringUtils {
        public static string[] Dispatch(string input) {
            if (string.IsNullOrWhiteSpace(input)) return Array.Empty<string>();
            return input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}