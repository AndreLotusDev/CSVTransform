using System.Text;

namespace CsvExtractorToJsClass.Helpers
{
    public static class CustomModification
    {
        public static string ActualResult = string.Empty;
        public static void ExecuteTransform(List<string[]> csv)
        {
            for (int i = 0; i < csv.Count; i++)
            {
                if (csv[i].Length >= 7)
                {
                    csv[i][1] = csv[i][0] + csv[i][1];
                    csv[i] = csv[i].Skip(1).ToArray();
                }
            }
        }

        public static void ExecuteIteration(List<string[]> csv, string[] headers)
        {
            StringBuilder stringBuilder = new();
            stringBuilder.Append("[");
            foreach (string[] row in csv)
            {
                var iso2Code = row[1].Trim().Replace("\"", "");
                var shouldContinue = row[1].Trim().Replace("\"", "").Length != 2;
                if (shouldContinue) continue;

                var isNtAllUpper = !iso2Code.All(char.IsUpper);
                if (isNtAllUpper) continue;

                //row[1].Replace("\"", "").Replace("'", "") + "=" +
                stringBuilder.Append("{");
                for (int i = 0; i < headers.Length; i++)

                {
                    var pureRow = row[i + 1].Replace("\"", "").Replace(";", "").Trim();
                    var isNumber = int.TryParse(pureRow, out _);

                    var finalFormat = isNumber ? pureRow : "\"" + pureRow.Trim().Replace("'", "").Replace(";", "") + "\"";

                    var tempLine = $"{headers[i].Replace(";", "")}: {finalFormat},\n";
                    stringBuilder.Append(tempLine);
                }

                stringBuilder.Append("} ,");
            }
            stringBuilder.Append("]");

            ActualResult = stringBuilder.ToString();
        }
    }
}
