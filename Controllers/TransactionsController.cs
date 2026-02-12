/// Copyright (c) 2026 Chiara Altobelli

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Budget.Server.Data;
using Budget.Server.Model;

namespace Budget.Server.Controllers;

[ApiController]
[Route("api/transactions")]
public class TransactionsController : ControllerBase
{
    private readonly BudgetDbContext _dbContext;

    public TransactionsController(BudgetDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    [Route("api/gettransactions")]
    public async Task<ActionResult<IEnumerable<Transaction>>> Get()
    {
        var transactions = await _dbContext.Transactions
            .OrderByDescending(t => t.Date)
            .Take(100)
            .ToListAsync();

        return Ok(transactions);
    }

    [HttpPost]
    [Route("api/addtransaction")]
    public async Task<ActionResult<Transaction>> Create([FromBody] Transaction transaction)
    {
        _dbContext.Transactions.Add(transaction);
        await _dbContext.SaveChangesAsync();
        return Ok(transaction);
    }
}