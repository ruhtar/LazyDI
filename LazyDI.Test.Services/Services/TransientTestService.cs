using LazyDI.Core;
using LazyDI.Test.Services.Repo;

namespace LazyDI.Test.Services.Services;

public class TransientTestService : ITestTransientService, ITransient
{
    private readonly Guid _random = Guid.NewGuid();
    private readonly ITransientRepo transientRepo;

    public TransientTestService(ITransientRepo transientRepo)
    {
        this.transientRepo = transientRepo;
    }

    public (Guid, Guid) GetNumber()
    {
        return (_random, transientRepo.GetNumber());
    }
}
