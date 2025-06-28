using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using CsvTransformation.Benchmarks;
using CsvTransformation.Benchmarks.Extensions;

var config = ManualConfig.Create(DefaultConfig.Instance)
    .WithOptions(ConfigOptions.DisableOptimizationsValidator)
    .WithSummaryStyle(BenchmarkDotNet.Reports.SummaryStyle.Default)
    .WithArtifactsPath("BenchmarkResults"); // Directory for results

var summary = BenchmarkRunner.Run<CsvTransformBenchmarks>(config);

// Save summary to RESULTS.md
var summmaryTable = summary.GenerateMarkdownTable();
File.WriteAllText("RESULTS.md", summmaryTable);
Console.WriteLine($"Result: {summmaryTable}");