namespace CsvTransformation.Benchmarks.Extensions;

using BenchmarkDotNet.Reports;
using System.Text;

public static class BenchmarkExtensions
{
 public static string GenerateMarkdownTable(this Summary summary)
{
    var sb = new StringBuilder();
    
    sb.AppendLine("| Benchmark Name | Result | Mean (ms) | Error (ms) | StdDev (ms) | Median (ms) |  Units |");
    sb.AppendLine("|----------------|---------|-----------|------------|--------------|--------------|-------|-------|--------|--------|----------------|-------|");

    foreach (var report in summary.Reports)
    {
        var benchName = report.BenchmarkCase.DisplayInfo;
        var result = report.BuildResult != null ? report.BuildResult.ToString() : "N/A";

        if (report.ResultStatistics != null)
        {
            var stats = report.ResultStatistics;
            var meanMs = stats.Mean / 1_000_000; // Convert nanoseconds to milliseconds
            var errorMs = stats.StandardError / 1_000_000;
            var stdDevMs = stats.StandardDeviation / 1_000_000;
            var medianMs = stats.Median / 1_000_000;

            sb.AppendLine($"| {benchName} | {result} | {meanMs:F3} | {errorMs:F3} | {stdDevMs:F3} | {medianMs:F3} |  | ms |");
        }
        else
        {
            sb.AppendLine($"| {benchName} | {result} | N/A | N/A | N/A | N/A | N/A | N/A | N/A | N/A | N/A | ms |");
        }
    }

    // Add detailed descriptions for each metric
    sb.AppendLine();
    sb.AppendLine("**Column Descriptions:**");
    sb.AppendLine("- **Benchmark Name:** The name or description of the benchmark tested.");
    sb.AppendLine("- **Result:** The outcome or specific result of the benchmark.");
    sb.AppendLine("- **Mean (ms):** Arithmetic mean of all measurements.");
    sb.AppendLine("- **Error (ms):** Half of 99.9% confidence interval.");
    sb.AppendLine("- **StdDev (ms):** Standard deviation of all measurements.");
    sb.AppendLine("- **Median (ms):** Median value separating the higher half of measurements.");
    sb.AppendLine("- **Units:** The measurement units used, here milliseconds.");

    return sb.ToString();
}
}