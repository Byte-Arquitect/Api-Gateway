
# 🌐 API Gateway - Redirección de Endpoints

 **API Gateway** desarrollada en.NET 8 para redirigir solicitudes a los diferentes microservicios de Cubi12

---

## 📋 **Características principales**

- Redirección de endpoints: La API Gateway actúa como intermediaria entre el cliente y los microservicios.
- Configuración flexible de rutas.
- Incluye una colección de **Postman** para probar los endpoints.

---

## 🛠️ **Requisitos previos**

Antes de ejecutar el proyecto, asegúrate de contar con:

1. [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
2. [Postman](https://www.postman.com/downloads/) para probar los endpoints.

---

## 🚀 **Configuración inicial**

1. **Clonar el repositorio:**
   ```bash
   git clone https://github.com/Byte-Arquitect/Api-Gateway.git
   cd ApiGateway
   ```

2. **Configurar las rutas en `appsettings.json`:**

   Asegúrate que el apartado de JwtSetting del appsettings.json e vea tal que asi:
   ```json
   "JwtSettings": {
    "Authority": "https://localhost:5238",
    "Audience": "Access_Service",
    "Key" : "29f1ab627e75ee8ffd7bf2e404d782acce4e3c130e4d9fc53c5c1616b62ba861ad3af30ce548b5f8f386fa45b40fc777373de1e1aa099cd82c681be2f208f3ea023fe6eb2fdfa417c083f2791b21c03520c916536d6571a54668e0ae464ff057ea0adcd7619d58733d2c49159df82096de1d49549f8a9e44b1354e5a1d91f09347ce846422d26bf39d4d6f5d964a6fed9115524db573e2ee228135f102918b995e082860065d162a581bc6eb153f3432288ddf971bd2a7556d2277c5a0288ab1e2e18c4ceed9de2eb330292b44e3dd13e75b183b29c9bb0c80b5b14528d964167470051ecde48f7c254d09605fdb91da93a149fda5155985dd090d21884520d2"}
  

3. **Ejecutar la API Gateway:**

   Para instalar dependencias, ejecuta:
   ```bash
   dotnet restore
   ```

    Para iniciar la API Gateway, ejecuta:
    ```bash
    dotnet run
    ```
    ---

## 🧪 **Pruebas de la API Gateway**

1. **Colección de Postman:**

   Se incluye un archivo de colección de Postman en el repositorio para facilitar las pruebas. Importa el archivo `.json` en Postman y utiliza las solicitudes predefinidas.

   Ubicación del archivo:
   ```
    ApiGateway.Postman_Collection.json
   ```
