# Instalación
>El nombre del paquete descargable en Nuget es **sqlite-net-pcl** el autor es **Frank A. Krueger** Para el uso de base de datos locales se debe programar un DependencyService para cada plataforma debido a que para cada plataforma hay un directorio diferente al momento de guardar datos localmente.

# Programación
### Creación de interfaz en el proyecto compartido
```csharp
public interface sqliteInterface{
    string GetLocalPath(string filename);
}
```

### Implementación en Android
```csharp
// Before namespace
[assembly: Dependency(typeof(sqliteImplements)]

public class sqliteImplements : sqliteInterface{
    public string GetLocalPath(string filename){
        string docFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        string libFolder = Path.Combine(docFolder, filename);
        return libFolder;
    }
}
```

### Implementación en iOS
```csharp
// Before namespace
[assembly: Dependency(typeof(sqliteImplements)]

public class sqliteImplements : sqliteInterface{
    public string GetLocalPath(string filename){
        string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");
        if (!Directory.Exists(libFolder))
        {
            Directory.CreateDirectory(libFolder);
        }
        return Path.Combine(libFolder, filename);
    }
}
```

### Implementación en UWP
```csharp
// Before namespace
[assembly: Dependency(typeof(sqliteImplements)]

public class sqliteImplements : sqliteInterface{
    public string GetLocalPath(string filename){
        string libFolder = Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        return libFolder;
    }
}
```