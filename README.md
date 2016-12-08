[![Build status](https://ci.appveyor.com/api/projects/status/jsx8fk6bgg1h1w08/branch/master?svg=true)](https://ci.appveyor.com/project/Meeji/coreutils/branch/master)

# CoreUtils
Core library re-used by our other code

## ThrowHelpers
Shortcuts for common boilerplate throw logic

### Throw
```csharp
string str = null;
Throw.IfNull(str, nameof(str)); // Throws ArgumentNullException

str = string.Empty;
Throw.IfNullOrEmpty(str, nameof(str)); // Throws ArgumentException

// Other variations are:
// - Throw.IfNullEmptyOrWhitespace
// - Throw.IfEmptyOrWhitespace
```

### ReturnParameter

```csharp
var str = "a string";
var str2 = ReturnParameter.OrThrowIfNull(str, nameof(str)); // str2 == str

str = null;
var str3 = ReturnParameter.OrThrowIfNull(str, nameof(str)); // Throws ArgumentNullException

// Other variations are:
//  - ReturnParameter.IfNullEmptyOrWhitespace
//  - ReturnParameter.OrThrowIfNullOrEmpty
//  - ReturnParameter.OrThrowIfNullEmptyOrWhitespace
//  - ReturnParameter.OrThrowIfNullOrEmpty
//  - ReturnParameter.OrThrowIfEmptyOrWhitespace
```

## LazyValue

Creates a lazy value like the built in ```Lazy<T>``` but with less overhead and without thread safety

```csharp
var i = 5;
var lazySix = LazyValue.Create(() => ++i);

// i is 5 here.
var six = lazySix.Value;
// i is 6 here.
var alsoSix = lazySix.Value;
// still 6 here
```
