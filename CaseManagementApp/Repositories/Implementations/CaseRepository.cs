using CaseManagementApp.Data;
using CaseManagementApp.Models;
using Microsoft.EntityFrameworkCore;

public class CaseRepository : ICaseRepository
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

    public CaseRepository(IDbContextFactory<ApplicationDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<List<BrownsteinCase>> GetAllAsync()
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.BrownsteinCases
            .Include(c => c.Client)
            .Include(c => c.Attorney)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<BrownsteinCase?> GetByIdAsync(int id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.BrownsteinCases
            .Include(c => c.Client)
            .Include(c => c.Attorney)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddAsync(BrownsteinCase newCase)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        context.BrownsteinCases.Add(newCase);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(BrownsteinCase updatedCase)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        context.BrownsteinCases.Update(updatedCase);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var entity = await context.BrownsteinCases.FindAsync(id);
        if (entity != null)
        {
            context.BrownsteinCases.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}

