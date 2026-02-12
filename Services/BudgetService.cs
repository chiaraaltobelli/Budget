/// Copyright (c) 2026 Chiara Altobelli

using Budget.Server.Interfaces;

namespace Budget.Server.Services;

public class BudgetService : IBudgetService
{
    private readonly TimeService _timeService;

    public BudgetService(TimeService timeService)
    {
        _timeService = timeService;
    }

    public string GetStatus()
    {
        return $"The time is {_timeService.Now}";
    }   

}