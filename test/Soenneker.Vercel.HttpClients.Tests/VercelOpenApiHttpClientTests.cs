using Soenneker.Vercel.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Vercel.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class VercelOpenApiHttpClientTests : HostedUnitTest
{
    private readonly IVercelOpenApiHttpClient _httpclient;

    public VercelOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IVercelOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
