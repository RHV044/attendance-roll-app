# attendance-roll-app
**PoC of .NET MAUI + Blazor Hybrid**

Este PoC se puede utilizar como proyecto base o template ya que tiene:
- Base de datos local SQLite con implementacion de EF Migrations
- Sincronización de datos al servidor (simulado con Gforms  y Gsheet) al obtener conexion
- Proyecto Blazor separado con la UI para ser reutilizada en un proyecto Blazor WEB
     Para esto la SharedUI usa solo interfaces de los servicios. En MAUI estan las implementaciones, en Blazor WEB tendria otras implementaciones
- Uso de hardware nativo (Lector NFC)
    Maneja que el dispositivo no tenga compatibilidad
- FluentUI-blazor.net implementado para interfaces. (Lo peor del PoC, es horrible y poco responsive. Sugiero utilizar Bootstrap plano o MudBlazor)
- Utiliza bien el keyboard en android para que no overlapee con los inputs.

En este PoC no se puede:
- Editar data de las personas
- Sincronizar personas al servidor, solo existen local. (Solo se envian al gsheet las asistencias que incluyen la informacion de las personas)
- Configurar el formulario o el gsheet, esto esta hardcodeado.
- Aun no se pudo ejecutar en WearOS como me hubiera gustado
- La tabla de personas de fluentui es muy mala y no se ve nada en celular

Los datos de asistencias se sincronizan a este GSheets: https://docs.google.com/spreadsheets/d/1zO5lYvFMMEHhruPZDpr1FW5rA5UWIa9Hsxr88ffav6M
