---
name: crear-endpoint
description: Crea o amplía un endpoint de SoporteIT siguiendo el estándar del equipo. Úsala cuando se pida añadir o modificar rutas de la API.
---

# Crear o ampliar un endpoint

Sigue siempre estos pasos:

1. **Lógica** en `SoporteIT.Core` (servicio o dominio), sin nada de HTTP. Si usa fechas, inyecta `TimeProvider`.
2. **Ruta** en `src/SoporteIT.Api/Program.cs` dentro del grupo `/incidencias`, con validación de entrada y errores `{ "error": "..." }`.
3. **Tests** en `tests/SoporteIT.Tests`: caso feliz, entrada inválida, recurso inexistente y casos límite.
4. **Documentación**: añade la ruta a la tabla de endpoints del README y a `docs-demo/peticiones.http`.
5. Ejecuta `dotnet test` y corrige hasta que pase.

Códigos HTTP: 200 lectura, 201 creación, 204 sin contenido, 400 entrada inválida, 401 sin credenciales, 404 no existe.
