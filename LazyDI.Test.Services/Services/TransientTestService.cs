using LazyDI.Core;

namespace LazyDI.Test.Services.Services;

public class SingletonTestService : ITestSingletonService, ISingleton
{
    private readonly Guid _random = Guid.NewGuid();

    public Guid GetNumber()
    {
        return _random;
    }
}
