using CaseManagementApp.Data;
using CaseManagementApp.Models;
using Microsoft.EntityFrameworkCore;

public class CaseNoteRepository : ICaseNoteRepository
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

    public CaseNoteRepository(IDbContextFactory<ApplicationDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<List<CaseNote>> GetByCaseIdAsync(int caseId)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.CaseNotes
            .Where(n => n.BrownsteinCaseId == caseId)
            .OrderByDescending(n => n.CreatedAt)
            .ToListAsync();
    }

    public async Task<CaseNote?> GetByIdAsync(int id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.CaseNotes.FindAsync(id);
    }

    public async Task AddAsync(CaseNote note)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        context.CaseNotes.Add(note);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CaseNote note)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        context.CaseNotes.Update(note);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var note = await context.CaseNotes.FindAsync(id);
        if (note is not null)
        {
            context.CaseNotes.Remove(note);
            await context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.CaseNotes.AnyAsync(e => e.Id == id);
    }
}
