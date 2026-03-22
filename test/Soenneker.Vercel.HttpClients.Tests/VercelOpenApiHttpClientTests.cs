using Soenneker.Vercel.HttpClients.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Vercel.HttpClients.Tests;

[Collection("Collection")]
public sealed class VercelOpenApiHttpClientTests : FixturedUnitTest
{
    private readonly IVercelOpenApiHttpClient _httpclient;

    public VercelOpenApiHttpClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _httpclient = Resolve<IVercelOpenApiHttpClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
