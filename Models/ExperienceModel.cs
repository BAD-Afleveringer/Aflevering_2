namespace webAPI.Models;

// data representation

public class Experience  // representation of table
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public int? Price { get; set; } // ? = allow nulls
}