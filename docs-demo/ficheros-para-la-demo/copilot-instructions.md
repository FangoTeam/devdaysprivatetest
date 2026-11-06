# Instrucciones del equipo SoporteIT

- Código, nombres y comentarios en español. PascalCase para tipos y métodos, camelCase para variables locales.
- C# moderno (constructores primarios, expresiones de colección, pattern matching) con nullable activado y sin warnings.
- Nunca uses `DateTime.Now` ni `DateTime.UtcNow`: inyecta `TimeProvider` para poder probar el tiempo.
- La lógica de negocio va en `SoporteIT.Core`; `SoporteIT.Api` solo expone endpoints finos.
- Todo cambio de comportamiento lleva tests xUnit en `tests/SoporteIT.Tests` (Arrange/Act/Assert, nombres descriptivos con guiones bajos).
- Los errores HTTP se devuelven como `{ "error": "mensaje" }` con el código adecuado.
- Nunca pongas secretos ni claves en el código: usa configuración o variables de entorno.
- Antes de dar algo por terminado ejecuta `dotnet test` y déjalo en verde.
- Actualiza el README si cambia un endpoint. Commits: `tipo: descripción` (feat, fix, test, docs).
