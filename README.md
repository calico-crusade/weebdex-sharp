# weebdex-sharp
A C# API for weebdex.org

Currently this is in pre-release and does not cover all endpoints. More features and endpoints will be added in the future.

## Usage Aggreement
By using this API, you agree to the following [WeebDex.org](https://weebdex.org/terms)'s terms of service.

## Installation
You can install the NuGet package with Visual Studio. It targets .net standard 2.1 to take advantage of most of the new features within C# and .net.

```
PM> Install-Package WeebDexSharp
```

## Setup
You can either use it directly or via dependency injection (for use with asp.net core).

### Directly:
```csharp
using WeebDexSharp;

...
//You cannot access authed routes if you use this option.
var api = WeebDex.Create();

var manga = await api.Manga.Get("some-manga-id-here");
```

### Depdency Injection:
```csharp

using WeebDexSharp;

var builder = WebApplication.CreateBuilder(args);

...


builder.Services.AddWeebDex();

var app = builder.Build();
```

Then you can inject the API into any of your controllers or other services:
```csharp
using WeebDexSharp;
using Microsoft.AspNetCore.Mvc;

namespace SomeApplication;

[ApiController]
public class SomeController : ControllerBase
{
    private readonly IWeebDex _api;

    public SomeController(IWeebDex api)
    {
        _api = api;
    }

    [HttpGet, Route("manga/{id}")]
    public async Task<IActionResult> Get(string id)
    {
        return Ok(await _api.Manga.Get(id));
    }
}
```

## Documentation
More documentation coming soon.