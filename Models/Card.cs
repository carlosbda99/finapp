namespace Finapp.Models;

public class Card
{
    public int Id { get; set; }

    public required string Description { get; set;}

    public double TotalLimit { get; set; }

    public double AvailableLimit { get; set; }

    public double? Annuity { get; set; }
}