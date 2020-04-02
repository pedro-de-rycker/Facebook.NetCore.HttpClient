# Facebook.NetCore.HttpClient

A extend HTTP client for facebook graph API.

This package is part of a three package group :
- [Facebook.AspNetCore.Extensions.DependencyInjection](https://github.com/pedro-de-rycker/Facebook.AspNetCore.Extensions.DependencyInjection)
- [Facebook.NetCore.Service](https://github.com/pedro-de-rycker/Facebook.NetCore.Service)
- [Facebook.NetCore.HttpClient](https://github.com/pedro-de-rycker/Facebook.NetCore.HttpClient)

## Get started

Download the following package from [nuget.org](https://www.nuget.org/) :

```
Facebook.NetCore.HttpClient
```

## Constructor : FacebookHttpClient(string version)

```csharp
FacebookHttpClient client = new FacebookHttpClient(version);
```
Where `version` is the Facebook graph API version.

Exemple :

```csharp
FacebookHttpClient client = new FacebookHttpClient("v6.0");
```
## Extended methods

### GetAsync

````csharp
GetAsync(
    string endpoint,
    string accessToken,
    IDictionary<string, string> args = null,
    HttpCompletionOption options = default,
    CancellationToken cancellationToken = default)
````

Where :
- **endpoint**: same as for the regular [HttpClient](https://docs.microsoft.com/dotnet/api/system.net.http.httpclient?view=netcore-3.1).
- **accessToken**: the token to use. Can be a user, application, page token depending on the required type for the request.
- **args**: the different arguments to pass.
- **options**: same as for the regular [HttpClient](https://docs.microsoft.com/dotnet/api/system.net.http.httpclient?view=netcore-3.1).
- **cancellationToken**: same as for the regular [HttpClient](https://docs.microsoft.com/dotnet/api/system.net.http.httpclient?view=netcore-3.1).

### PostAsync

````csharp
PostAsync(
    string endpoint,
    HttpContent content,
    string accessToken,
    IDictionary<string, string> args = null,
    System.Threading.CancellationToken cancellationToken = default)
````

Where :
- **endpoint**: same as for the regular [HttpClient](https://docs.microsoft.com/dotnet/api/system.net.http.httpclient?view=netcore-3.1).
- **content**: same as for the regular [HttpClient](https://docs.microsoft.com/dotnet/api/system.net.http.httpclient?view=netcore-3.1).
- **accessToken**: the token to use. Can be a user, application, page token depending on the required type for the request.
- **args**: the different arguments to pass.
- **cancellationToken**: same as for the regular [HttpClient](https://docs.microsoft.com/dotnet/api/system.net.http.httpclient?view=netcore-3.1).
