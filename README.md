# attendance-roll-app
**PoC of .NET MAUI + Blazor Hybrid**

Este PoC se puede utilizar como proyecto base o template ya que tiene:
- Base de datos local SQLite con implementacion de EF Migrations
- Sincronización de datos al servidor (simulado con Gforms  y Gsheet) al obtener conexion
- Proyecto Blazor separado con la UI para ser reutilizada en un proyecto Blazor WEB
     Para esto la SharedUI usa solo interfaces de los servicios. En MAUI estan las implementaciones, en Blazor WEB tendria otras implementaciones
- Uso de hardware nativo (Lector NFC)
    Maneja que el dispositivo no tenga compatibilidad
- FluentUI-blazor.net implementado para interfaces. (Lo peor del PoC, es horrible y poco responsive)

