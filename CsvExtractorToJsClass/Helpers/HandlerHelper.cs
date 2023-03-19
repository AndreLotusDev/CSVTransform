namespace CsvExtractorToJsClass.Helpers
{
    public static class HandlerHelper
    {
        public static void Modify(List<string[]> csv)
        {
            CustomModification.ExecuteTransform(csv);
        }

        public static void Iterate(List<string[]> csv, string[] headers)
        {
            CustomModification.ExecuteIteration(csv, headers);
        }

        public static void WriteToFile(string outputFilePath)
        {
            File.WriteAllText(outputFilePath, CustomModification.ActualResult);
        }
    }
}
