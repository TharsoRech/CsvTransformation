using CsvTransformation;

namespace CsvTransformationTests
{
    [TestClass]
    public class CsvManagerTests
    {
        public required TestContext TestContext { get; set; }

        [TestMethod]
        [DynamicData(nameof(TestDataSet.GenerateBasicDataSet), typeof(TestDataSet), DynamicDataSourceType.Method)]
        public void TestSimpleTransformCsvMethod(string display_name, string input, string expected)
        {
            TestContext.WriteLine($" > {display_name}");
            string result = CsvManager.SimpleTransformCsv(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(TestDataSet.GenerateBasicDataSet), typeof(TestDataSet), DynamicDataSourceType.Method)]
        public void TestTransformCsvMethod(string display_name, string input, string expected)
        {
            TestContext.WriteLine($" > {display_name}");
            string result = CsvManager.TransformCsv(input);
            Assert.AreEqual(expected, result);
        }
    }

    public static class TestDataSet
    {
        public static IEnumerable<object[]> GenerateBasicDataSet()
        {
            yield return new object[]
            {
               "Example.1",
                "id,name,age,score\n1,Jack,NULL,12\n17,Betty,28,11",
                "id,name,age,score\n17,Betty,28,11"
            };
            yield return new object[]
            {
                "Example.2",
                "header,header\nANNUL,ANNULLED\nnull,NILL\nNULL,NULL",
                "header,header\nANNUL,ANNULLED\nnull,NILL"
            };
            yield return new object[]
            {
                "Example.3",
                "country,population,area\nUK,67m,242000km2",
                "country,population,area\nUK,67m,242000km2"
            };
        }
    }
}