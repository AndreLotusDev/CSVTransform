using CsvExtractorToJsClass.Helpers;

string csvFilePath = @"PATH";
string outputFilePath = @"PATH";

List<string[]> csvData = File.ReadAllLines(csvFilePath)
    .Select(line => line.Split(','))
    .ToList();

string[] headers = csvData[0];

headers = headers.Skip(1).ToArray();

csvData.RemoveAt(0);

HandlerHelper.Modify(csvData);

HandlerHelper.Iterate(csvData, headers);

HandlerHelper.WriteToFile(outputFilePath);
