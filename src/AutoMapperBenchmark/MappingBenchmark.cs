using AutoMapper;

using AutoMapperBenchmark.DTO;
using AutoMapperBenchmark.Models;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace AutoMapperBenchmark;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.SlowestToFastest)]
public class MappingBenchmark
{
    private IMapper? _mapper;
    private Product[]? _products;

    [Params(10, 100, 1_000, 10_000)]
    public int NumberOfElements { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        var configuration = new MapperConfiguration(config =>
        {
            config.CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price + src.Price * 100 / src.Percentage))
            ;
        });

        _mapper = configuration.CreateMapper();
        _products = Product.GenerateProducts(NumberOfElements);
    }

    [Benchmark]
    public ProductDto[] AutoMapperMapping()
    {
        return _products!.Select(x => _mapper!.Map<ProductDto>(x)).ToArray();
    }

    [Benchmark]
    public ProductDto[] ManualMapping()
    {
        return _products!.Select(x => x.ProductDto()).ToArray();
    }
}
