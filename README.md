# AutoMapperBenchmark
Projeto para testar o Benchmark do AutoMapper versus mapeamento manual


BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3880/23H2/2023Update/SunValley3)
Intel Core i9-14900K, 1 CPU, 32 logical and 24 physical cores
.NET SDK 8.0.303
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX2 

| Method            | NumberOfElements | Mean         | Error       | StdDev      | Gen0    | Gen1    | Allocated |
|------------------ |----------------- |-------------:|------------:|------------:|--------:|--------:|----------:|
| AutoMapperMapping | 10000            | 612,737.5 ns | 2,763.15 ns | 2,584.65 ns | 29.2969 | 10.7422 |  560136 B |
| ManualMapping     | 10000            | 327,585.4 ns | 2,447.75 ns | 2,289.63 ns | 29.2969 | 11.2305 |  560072 B |
| AutoMapperMapping | 1000             |  59,404.5 ns |   197.85 ns |   185.07 ns |  2.9297 |  0.4883 |   56136 B |
| ManualMapping     | 1000             |  32,050.1 ns |   160.88 ns |   142.61 ns |  2.9297 |  0.5493 |   56072 B |
| AutoMapperMapping | 100              |   5,881.0 ns |     9.83 ns |     8.21 ns |  0.2975 |       - |    5736 B |
| ManualMapping     | 100              |   3,237.4 ns |    26.01 ns |    21.72 ns |  0.3014 |  0.0038 |    5672 B |
| AutoMapperMapping | 10               |     610.8 ns |     2.49 ns |     2.21 ns |  0.0362 |       - |     696 B |
| ManualMapping     | 10               |     333.0 ns |     1.58 ns |     1.48 ns |  0.0334 |       - |     632 B |