# Meplato Store 2 API for .NET

[![Build Status](https://travis-ci.org/meplato/store2-dotnet-client.svg?branch=master)](https://travis-ci.org/meplato/store2-dotnet-client)

This is the .NET client for the Meplato Store 2 API. It consists of a library
to integrate your infrastructure with Meplato suite for suppliers.

## Prerequisites

You need three things to use the Meplato Store 2 API.

1. A login to Meplato Store 2.
2. An API token.
3. Microsoft Visual Studio (at least VS 2013) and .NET 4.5.1.

Get your login by contacting Meplato Supplier Network Services. The API token
is required to securely communicate with the Meplato Store 2 API. You can
find it in the personalization section when logged into Meplato Store.

## Installation

1. Open the solution in `.\src\Meplato.Store2.vs2013.sln` (or `.\src\Meplato.Store2.vs2015.sln`).
2. Build the solution.

## Using the library

All functionality of the Meplato Store 2 API is separated into services.
So you e.g. have a service to work with catalogs, another
service to work with products in a catalog etc. All services need to be
initialized with your API token.

```csharp
using Meplato.Store2.Catalogs;

// Client is used to perform HTTP requests.
// The library comes with a default HTTP client,
// but you can build or use your own.
var client = new Meplato.Store2.Client();

// Create and initialize the Catalogs service with your API token.
var service = new Service(client) {
    User = "<your-api-token>"
};

// Get the first 10 of your catalogs, sorted by creation date (descending), then by name.
var response = await service.Search().Skip(0).Take(10).Sort("-created,name").Do();
Console.WriteLine("You have {0} catalog(s).", response.TotalItems);
foreach (var catalog in response.Items)
{
    Console.WriteLine("Catalog with ID={0} has name {1}", catalog.Id, catalog.Name);
}
```

Feel free to read the unit tests for the various usage scenarios of the
library.

## Documentation

Complete documentation for the Meplato Store 2 API can be found at
[https://developer.meplato.com/store2](https://developer.meplato.com/store2).

## Testing

Run the NUnit tests in the Visual Studio solution.

# License

This software is licensed under the Apache 2 license.

    Copyright (c) 2015 Meplato GmbH, Switzerland <http://www.meplato.com>

    Licensed under the Apache License, Version 2.0 (the "License");
    you may not use this file except in compliance with the License.
    You may obtain a copy of the License at

        http://www.apache.org/licenses/LICENSE-2.0

    Unless required by applicable law or agreed to in writing, software
    distributed under the License is distributed on an "AS IS" BASIS,
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    See the License for the specific language governing permissions and
    limitations under the License.
