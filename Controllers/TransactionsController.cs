/// Copyright (c) 2026 Chiara Altobelli

using Microsoft.AspNetCore.Mvc;
using Budget.Server.Model;
using Budget.Server.Interfaces;
using Budget.Server.Results;

namespace Budget.Server.Controllers;

[ApiController]
[Route("api/transactions")]
public class TransactionsController : ControllerBase
{

    private readonly ITransactionService _transactionService;
    public TransactionsController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpGet]
    public async Task<ActionResult<Result<IEnumerable<Transaction>>>> Get()
    {
        var result = await _transactionService.GetTransactionsAsync();
        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Result<Transaction>>> AddTransaction([FromBody] Transaction transaction)
    {
        var result = await _transactionService.AddTransactionAsync(transaction);
        if (!result.IsSuccess)        {
            return BadRequest(result);
        }
        return Ok(result);
    }
}