## FORMA 1
```csharp
public CancellationTokenSource Cts { get; } = new CancellationTokenSource();

await Task.Factory.StartNew(async () =>
{
    while (true)
    {
        // Your code here
        // You can use Task.Delay or not
        await Task.Delay(TimeSpan.FromSeconds(1));
    }
}, Cts.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
```

## FORMA 2
>Esta tarea se ejecuta cada 1 segundo
```csharp
Device.StartTimer(TimeSpan.FromSeconds(1), () =>
{
    // Your code here
    return true;
});
```

## FORMA 3
```csharp
await Task.Run(async () =>
{
    while (true)
    {
        // Your code here
        // You can use Task.Delay or not
        await Task.Delay(TimeSpan.FromSeconds(2));
    }
}).ConfigureAwait(true);
```

## FORMA 4
```csharp
Device.BeginInvokeOnMainThread(async () =>
{
    while (true)
    {
        // Your code here
        // You can use Task.Delay or not
        await Task.Delay(TimeSpan.FromSeconds(5));
    }
});
```