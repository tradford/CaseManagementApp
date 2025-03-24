using CaseManagementApp.Data;
using CaseManagementApp.Models;
using Microsoft.EntityFrameworkCore;

public class AttorneyRepository : IAttorneyRepository
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

    public AttorneyRepository(IDbContextFactory<ApplicationDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<List<Attorney>> GetAllAsync()
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Attorneys
            .AsNoTracking()
            .OrderBy(a => a.Name)
            .ToListAsync();
    }

    public async Task<Attorney?> GetByIdAsync(int id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Attorneys.FindAsync(id);
    }

    public async Task AddAsync(Attorney attorney)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        context.Attorneys.Add(attorney);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Attorney attorney)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        context.Attorneys.Update(attorney);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var entity = await context.Attorneys.FindAsync(id);
        if (entity != null)
        {
            context.Attorneys.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}

