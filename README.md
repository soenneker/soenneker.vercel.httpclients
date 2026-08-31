[![](https://img.shields.io/nuget/v/soenneker.vercel.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.vercel.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.vercel.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.vercel.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.vercel.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.vercel.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.vercel.httpclients/codeql.yml?style=for-the-badge&label=CodeQL)](https://github.com/soenneker/soenneker.vercel.httpclients/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Vercel.HttpClients

Provides a cached `HttpClient` configured for the Vercel REST API with Bearer-token authentication.

## Installation

```bash
dotnet add package Soenneker.Vercel.HttpClients
```

## Configuration

```json
{
  "Vercel": {
    "AccessToken": "your-vercel-access-token"
  }
}
```

`Vercel:ApiKey` remains supported as a legacy name for the same token value. The token must have access to the personal account or team whose resources are requested.

## Registration

```csharp
using Soenneker.Vercel.HttpClients.Registrars;

services.AddVercelOpenApiHttpClientAsSingleton();
```

Scoped registration is available through `AddVercelOpenApiHttpClientAsScoped()`. Each provider instance owns a separate cached client and removes only that client when disposed.

## Usage

```csharp
using Soenneker.Vercel.HttpClients.Abstract;

public sealed class DeploymentReader
{
    private readonly IVercelOpenApiHttpClient _clients;

    public DeploymentReader(IVercelOpenApiHttpClient clients)
    {
        _clients = clients;
    }

    public async ValueTask<HttpResponseMessage> GetDeployments(
        string? teamId,
        CancellationToken cancellationToken)
    {
        HttpClient client = await _clients.Get(cancellationToken);
        string path = "v6/deployments";

        if (!string.IsNullOrWhiteSpace(teamId))
            path += $"?teamId={Uri.EscapeDataString(teamId)}";

        return await client.GetAsync(path, cancellationToken);
    }
}
```

The base address is `https://api.vercel.com/`; individual request paths include their API version. Requests include `Authorization: Bearer <AccessToken>` by default.
