/// Copyright (c) 2026 Chiara Altobelli

using Microsoft.AspNetCore.Mvc;
using Budget.Server.Interfaces;

namespace Budget.Server.Controllers;

[ApiController]
[Route("api/[budgets]")]
public class BudgetController : ControllerBase
{
    private readonly IBudgetService _budgetService;
    
    public BudgetController(IBudgetService budgetService)
    {
        _budgetService = budgetService;
    }   

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_budgetService.GetStatus());
    }
}
