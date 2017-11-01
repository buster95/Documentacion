# Instalación de MongoDB en Windows

## Directorios de Instalación

**Directorio Raíz**
```bash
C:\mongo
```

**Directorio de Base de datos**
```bash
C:\mongo\data
```

**Directorio de Logs**
```bash
C:\mongo\logs
```

## Configurar variable de entorno
1. En propiedades de sistema abrir variables de entorno.
2. A la variable path agregar la ruta de bin que se encuentra dentro de mongo.
3. Comprobar que se agrego correctamente, ejecutando:
    ```bash
    mongo --version
    ```

## Instalar Servicio
>El siguiente código creará un servicio con inicio automatico en Windows con el nombre de **MongoDB**
```bash
mongod --dbpath=C:\mongo\data --logpath=C:\mongo\logs\log --install
```

## Remover Servicio
```bash
mongod --remove
```