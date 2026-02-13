/// Copyright (c) 2026 Chiara Altobelli

using Microsoft.EntityFrameworkCore;
using Budget.Server.Data;
using Budget.Server.Interfaces;
using Budget.Server.Model;
using Budget.Server.Results;

namespace Budget.Server.Services;

public class TransactionService : ITransactionService
{
    private readonly BudgetDbContext _db;

    public TransactionService(BudgetDbContext db)
    {
        _db = db;
    }

    public async Task<Result<IEnumerable<Transaction>>> GetTransactionsAsync()
    {
        var transactions = await _db.Transactions
            .OrderByDescending(t => t.Date)
            .Take(100)
            .ToListAsync();
        return Result<IEnumerable<Transaction>>.Success(transactions);
    }

    public async Task<Result> AddTransactionAsync(Transaction transaction)
    {
        _db.Transactions.Add(transaction);
        await _db.SaveChangesAsync();
        return Result.Success("");
    }
}