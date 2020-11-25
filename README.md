# agar.io-projektavimas

## Installation  
```
git clone git@github.com:mindaugasw/agar.io-projektavimas.git
cp config.xml config.local.xml
```
Edit configuration in *config.local.xml* (optional).

#### Server installation
```bash
cd agar-server
dotnet restore
```

#### Client installation

```bash
cd agar-client
dotnet restore
```

## Project configuration

Configuration is stored in *config.xml* and *config.local.xml* files.  
*config.local.xml* is gitignored and should be used for any local machine configuration.  
*config.local.xml* is read after *config.xml* and will override any previously set values in common config.  

#### Usage
Config xml file structure:
```xml
<config>
  <add key="myKey" value="myValue" />
</config>
```

*Add* element should be used for each config key-value pair.

Accessing config in-app:

```csharp
ConfigManager.Get<string>("myKey")
```


## Testing
Running client tests:
- server must be running
- run only one test class at once (other tests will crash otherwise)