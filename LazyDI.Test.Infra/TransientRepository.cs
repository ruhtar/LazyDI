using LazyDI.Core;
using LazyDI.Test.Services.Repo;

namespace LazyDI.Test.Infra;

public class TransientRepository : ITransientRepo, ITransient
{
    private readonly Guid _random = Guid.NewGuid();

    public Guid GetNumber()
    {
        return _random;
    }
}
