/// Copyright (c) 2026 Chiara Altobelli

namespace Budget.Server.Model;

public class Transaction
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Account { get; set; } = string.Empty;
    public string? Category { get; set; }
    public string? Note { get; set; }
}