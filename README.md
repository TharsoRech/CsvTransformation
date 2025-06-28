# CSV Data Transformation Solution

This solution implements two methods to filter CSV data by removing rows with "NULL" values.

## Files Included
- `CsvManager.cs` : Contains both transformation methods.
- `CsvManagerTests.cs` : Unit tests for both methods.
- `Benchmarks.cs` : Performance benchmarking using BenchmarkDotNet.

## Usage

### Running Tests
- Open the solution in Visual Studio 2022.
- Build the solution.
- Run the tests via Test Explorer.

### Running Benchmarks
- Ensure BenchmarkDotNet is installed (`dotnet add package BenchmarkDotNet`)
- Build the solution.
- Run the `Program` class to execute benchmarks.
- Results will be displayed in the console.

## Notes
- The `SimpleTransformCsv` uses imperative style.
- The `TransformCsv` uses LINQ for a different approach.
- Benchmarks compare execution times with larger datasets.
