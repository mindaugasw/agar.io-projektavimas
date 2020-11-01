# agar.io-projektavimas

## Installation  
`git clone git@github.com:mindaugasw/agar.io-projektavimas.git`  

#### Server installation
```bash
cd agar-server
dotnet restore
cp config.xml _config.local.xml
```
Edit configuration in *config.local.xml* (optional).

#### Client installation

```bash
cd agar-client
dotnet restore
cp config.xml _config.local.xml
```
Edit configuration in *config.local.xml* (optional).


## Project configuration

Configuration is stored in *config.xml* and *config.local.xml* files.  
*config.local.xml* is gitignored and should be used for any local machine configuration.  
*config.local.xml* is read after *config.xml* and will override any previously set values in common config.  
Same system is implemented on both client and server projects.  

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

