namespace CsvTransformation
{
    public class CsvManager
    {
        private const char CsvNewLineCharacter = '\n';
        private const char CsvCellSeperator = ',';
        private const string CsvNullCellIdentifier = "NULL";
        
        public static string SimpleTransformCsv(string inputCsv)
        {
            if (string.IsNullOrEmpty(inputCsv))
                return inputCsv;

            var lines = inputCsv.Split(CsvNewLineCharacter);
            if (lines.Length == 0)
                return inputCsv;

            var header = lines[0]; // preserve header
            var resultLines = new List<string> { header };

            for (int i = 1; i < lines.Length; i++)
            {
                var cells = lines[i].Split(CsvCellSeperator);
                if (!cells.Any(cell => cell.Equals(CsvNullCellIdentifier)))
                {
                    resultLines.Add(lines[i]);
                }
            }

            return string.Join(CsvNewLineCharacter, resultLines);
        }
        
        public static string TransformCsv(string inputCsv)
        {
            if (string.IsNullOrEmpty(inputCsv))
                return inputCsv;

            var lines = inputCsv.Split(CsvNewLineCharacter);
            var header = lines.FirstOrDefault();
            if (header == null)
                return inputCsv;

            var dataLines = lines.Skip(1);

            var filteredLines = dataLines
                .Where(line => !line.Split(CsvCellSeperator)
                                    .Any(cell => cell.Equals(CsvNullCellIdentifier)))
                .ToList();

            var resultLines = new List<string> { header };
            resultLines.AddRange(filteredLines);

            return string.Join(CsvNewLineCharacter, resultLines);
        }
    }
}