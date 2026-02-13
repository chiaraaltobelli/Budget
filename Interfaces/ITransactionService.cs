
/// Copyright (c) 2026 Chiara Altobelli

using Budget.Server.Model;
using Budget.Server.Results;

namespace Budget.Server.Interfaces;

public interface ITransactionService
{
    Task<Result<IEnumerable<Transaction>>> GetTransactionsAsync();
    Task<Result> AddTransactionAsync(Transaction transaction);
}
