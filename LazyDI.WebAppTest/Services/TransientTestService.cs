using LazyDI.Core;

namespace LazyDI.WebAppTest.Services;

public class SingletonTestService : ITestSingletonService, ISingleton
{
    private readonly Guid _random = Guid.NewGuid();

    public Guid GetNumber()
    {
        return _random;
    }
}
