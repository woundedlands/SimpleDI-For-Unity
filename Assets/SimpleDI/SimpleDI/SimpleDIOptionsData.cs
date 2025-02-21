namespace SimpleDI
{
    [System.Serializable]
    public class SimpleDIOptionsData
    {
        public bool enableDebugging;

        public static SimpleDIOptionsData GetDefault()
        {
            return new SimpleDIOptionsData
            {
                enableDebugging = true,
            };
        }
    }
}