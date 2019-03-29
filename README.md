# Azure SQL failover

## Prepare demo app

You need to modify `Config.cs` file and fill following preperties with corresponding values:

| Property | Value | Example |
|---|---|---|
| `Endpoint01` | Host name of first SQL server | `udck-live-01.database.windows.net` |
| `Endpoint02` | Host name of second SQL server | `udck-live-02.database.windows.net` |
| `EndpointPrimary` | Host name of read-write endpoint of failover group | `failover-live.database.windows.net` |
| `EndpointSecondary` | Host name of read-only endpoint of failover group | `failover-live.secondary.database.windows.net` |
| `Login` | SQL login that is valid for both endpoints. | `JohnDoe` |
| `Password` | SQL password  | `Qwerty12!` |
| `Database` | SQL database name | `adventure` |


## Run demo app

To compile and run demo app you can use following command (both parameters are **mandatory**):

```
dotnet run --mode=<mode> --timeout=<timeout>
```

### mode



### timeout

Timeout in seconds for thread to wait before sending the same command again. 