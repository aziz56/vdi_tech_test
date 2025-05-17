namespace Technical_TestVDI.Models
{
    public class AnagramInput
    {
        public string FirstWordsRaw { get; set; }
        public string SecondWordsRaw { get; set; }

        public List<string> FirstWords => FirstWordsRaw?
            .Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(s => s.Trim())
            .ToList() ?? new();

        public List<string> SecondWords => SecondWordsRaw?
            .Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(s => s.Trim())
            .ToList() ?? new();
    }

}
