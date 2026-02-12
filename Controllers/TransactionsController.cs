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
    private readonly BudgetDbContext _db;

    public TransactionsController(BudgetDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    [Route("api/gettransactions")]
    public async Task<ActionResult<IEnumerable<Transaction>>> Get()
    {
        var transactions = await _db.Transactions
            .OrderByDescending(t => t.Date)
            .Take(100)
            .ToListAsync();

        return Ok(transactions);
    }

    [HttpPost]
    [Route("api/addtransaction")]
    public async Task<ActionResult<Transaction>> Create([FromBody] Transaction transaction)
    {
        _db.Transactions.Add(transaction);
        await _db.SaveChangesAsync();
        return Ok(transaction);
    }
}