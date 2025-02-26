using LazyDI.Core;

namespace LazyDI.Test.Services.Services;

public class TransientTestService : ITestTransientService, ITransient
{
    private readonly Guid _random = Guid.NewGuid();

    public Guid GetNumber()
    {
        return _random;
    }
}
