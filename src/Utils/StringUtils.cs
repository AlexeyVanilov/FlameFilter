namespace MessageFilter.Utils {
    public static class StringUtils {
        public static string[] Dispatch(char separator, string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return Array.Empty<string>();

            ReadOnlySpan<char> span = input.AsSpan().Trim();

            int wordCount = 0;
            foreach (var range in span.Split(separator)) {
                if (!span[range].IsWhiteSpace()) wordCount++;
            }

            string[] output = new string[wordCount];
            int index = 0;

            foreach (var range in span.Split(separator)) {
                var word = span[range];
                if (!word.IsWhiteSpace()) {
                    output[index++] = word.ToString();
                }
            }

            return output;
        }
    }
}