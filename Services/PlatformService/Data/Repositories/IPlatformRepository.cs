using PlatformService.Models;

namespace PlatformService.Data.Repositories;

public interface IPlatformRepository
{
    IEnumerable<Platform> Get();
    Platform Get(int id);
    Platform Create(Platform platform);

    bool SaveChanges();
}