using BenchmarkDotNet.Attributes;

namespace CsvTransformation.Benchmarks;

public class CsvTransformBenchmarks
{
    private string? sampleCsv; // Marked as nullable
    

    [GlobalSetup]
    public void Setup()
    {
        // Generate a larger dataset for more meaningful benchmarking
        sampleCsv = "id,name,age,score\n" +
                    "1,Jack,NULL,12\n" +
                    "17,Betty,28,11\n" +
                    "2,NULL,30,15\n" +
                    "3,Anna,25,14\n" +
                    "4,George,NULL,9\n" +
                    // Add more rows to increase size
                    "5,Sam,40,20\n" +
                    "6,NULL,50,25\n" +
                    "7,Lucy,33,17\n" +
                    "8,Tom,29,13\n" +
                    "9,Anna,31,18\n" +
                    "10,Mark,NULL,22\n" +
                    "11,Paul,44,19\n" +
                    "12,NULL,55,23\n" +
                    "13,George,38,16\n" +
                    "14,David,27,10\n" +
                    "15,Anna,45,24\n" +
                    "16,NULL,60,26\n";
    }

    [Benchmark]
    public string SimpleTransform() => CsvManager.SimpleTransformCsv(sampleCsv!);

    [Benchmark]
    public string AlternativeTransform() => CsvManager.TransformCsv(sampleCsv!);
}