using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;

[MemoryDiagnoser]
public class SwitchBenchmark
{
    [Benchmark]
    public string RunSwitchExpressions2()
    {
        string result = "";

        for (int number = 0; number <= 75; number += 5)
        {
            result = number switch
            {
                >= 0 and < 10 => "Between 0 and 10 (exclusive)",
                >= 10 and < 20 => "Between 10 and 20 (exclusive)",
                >= 20 and < 30 => "Between 20 and 30 (exclusive)",
                >= 30 and < 40 => "Between 30 and 40 (exclusive)",
                >= 40 and < 50 => "Between 40 and 50 (exclusive)",
                >= 50 and < 60 => "Between 50 and 60 (exclusive)",
                60 => "Equal to 60",
                _ => "Other cases"
            };
        }

        return result;
    }

    [Benchmark]
    public string RunSwitchCase2()
    {
        string result2 = "";

        for (int number2 = 0; number2 <= 75; number2 += 5)
        {
            switch (number2)
            {
                case int n when (n >= 0 && n < 10):
                    result2 = "Between 0 and 10 (exclusive)";
                    break;
                case int n when (n >= 10 && n < 20):
                    result2 = "Between 10 and 20 (exclusive)";
                    break;
                case int n when (n >= 20 && n < 30):
                    result2 = "Between 20 and 30 (exclusive)";
                    break;
                case int n when (n >= 30 && n < 40):
                    result2 = "Between 30 and 40 (exclusive)";
                    break;
                case int n when (n >= 40 && n < 50):
                    result2 = "Between 40 and 50 (exclusive)";
                    break;
                case int n when (n >= 50 && n < 60):
                    result2 = "Between 50 and 60 (exclusive)";
                    break;
                case 60:
                    result2 = "Equal to 60";
                    break;
                default:
                    result2 = "Other cases";
                    break;
            }
        }

        return result2;
    }

    static void Main()
    {
        var config = ManualConfig.Create(DefaultConfig.Instance)
            .AddDiagnoser(MemoryDiagnoser.Default);

        var summary = BenchmarkRunner.Run<SwitchBenchmark>(config);
    }
}
