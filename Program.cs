using BenchmarkDotNet.Running;

namespace IDvsGuid
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<DataGeneratorBenchmarks>();
        }
    }
}
