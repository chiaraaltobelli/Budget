/// Copyright (c) 2026 Chiara Altobelli

using Microsoft.EntityFrameworkCore;
using Budget.Server.Model;

namespace Budget.Server.Data;

public class BudgetDbContext : DbContext
{
    public DbSet<Transaction> Transactions => Set<Transaction>();
    
    public BudgetDbContext(DbContextOptions<BudgetDbContext> options) : base(options)
    {
        
    }
}