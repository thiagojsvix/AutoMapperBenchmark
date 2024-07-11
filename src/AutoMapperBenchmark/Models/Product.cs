using AutoMapperBenchmark.DTO;

namespace AutoMapperBenchmark.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public decimal Percentage { get; set; }

    public ProductDto ProductDto()
    {
        return new ProductDto
        {
            Name = Name,
            Description = Description,
            Price = Price + Price * 100 / Percentage,
        };
    }

    public static Product[] GenerateProducts(int NumberOfElements)
    {
        var products = new Product[NumberOfElements];

        products = Enumerable.Range(1, NumberOfElements).Select(x => new Product
        {
            Id = x,
            Name = $"Product Name {x}",
            Description = $"Product Description {x}",
            Price = 45.50m,
            Percentage = 19
        }).ToArray();

        return products;
    }
}
