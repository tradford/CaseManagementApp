using CaseManagementApp.Data;
using CaseManagementApp.Models;
using Microsoft.EntityFrameworkCore;

public class ClientRepository : IClientRepository
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

    public ClientRepository(IDbContextFactory<ApplicationDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<List<Client>> GetAllAsync()
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Clients
            .AsNoTracking()
            .OrderBy(c => c.FullName)
            .ToListAsync();
    }

    public async Task<Client?> GetByIdAsync(int id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Clients.FindAsync(id);
    }

    public async Task AddAsync(Client client)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        context.Clients.Add(client);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Client client)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        context.Clients.Update(client);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var entity = await context.Clients.FindAsync(id);
        if (entity != null)
        {
            context.Clients.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}

