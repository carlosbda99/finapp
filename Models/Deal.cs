using System.ComponentModel.DataAnnotations.Schema;

namespace Finapp.Models;

public class Deal
{
    public int Id { get; set; }

    public double Value { get; set; }

    public required string Description { get; set; }

    public DateTime Date { get; set; }

    public required string Source { get; set; }

    public char Type { get; set; }

    public DateTime? EndDate { get; set; }

    public int? Quota { get; set; }

    public int WalletId { get; set; }

    public required Wallet Wallet { get; set; }

    public int? CardId { get; set; }

    public Card? Card { get; set; }
    
    public int? CategoryId { get; set; }

    public Category? Category { get; set; }
}