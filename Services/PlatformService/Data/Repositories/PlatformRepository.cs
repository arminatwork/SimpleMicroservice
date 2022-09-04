namespace PlatformService.Data.Repositories;

public class PlatformRepository : IPlatformRepository
{
    private readonly AppDbContext _appDbContext;

    public PlatformRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public IEnumerable<Platform> Get()
    {
        return _appDbContext.Platforms.ToList();
    }

    public Platform Get(int id)
    {
        return _appDbContext.Platforms.FirstOrDefault(_ => _.Id.Equals(id));
    }

    public Platform Create(Platform platform)
    {
        ArgumentNullException.ThrowIfNull(platform);

        return _appDbContext.Platforms.Add(platform).Entity;
    }

    public bool SaveChanges()
    {
        return _appDbContext.SaveChanges() >= 0;
    }
}