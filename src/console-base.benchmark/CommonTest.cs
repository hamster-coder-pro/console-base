using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;

[MemoryDiagnoser()]
public class CommonBenchmark
{
    private byte[] Data { get; }
    private SHA256 Sha256 { get; }

    public CommonBenchmark()
    {
        Data = new byte[1000];
        Random.Shared.NextBytes(Data);
        Sha256 = SHA256.Create();
    }


    [Benchmark]
    public void Random_Benchmark()
    {
        var i = Random.Shared.NextInt64();
    }

    [Benchmark]
    public void Sha256_Benchmark()
    {
        var hash = Sha256.ComputeHash(Data);
    }
}