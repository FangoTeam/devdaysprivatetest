# SoporteIT · Gestor de incidencias del instituto

Repo de la demo de **Tu primer día como desarrollador… y tu compañero es GitHub Copilot**.
API en C# (ASP.NET Core Minimal API) con un panel web, pensada para que Copilot tenga algo real que explorar.

## Requisitos
- SDK de .NET 10 (si usas otro, cambia `TargetFramework` en `Directory.Build.props`)
- VS Code con C# Dev Kit o Visual Studio, con GitHub Copilot

## Arrancar
```bash
dotnet test
dotnet run --project src/SoporteIT.Api   # http://localhost:5080  (abre el panel)
```
En Development la hora está simulada (lunes 9/11/2026, 12:30 Madrid) y se cargan 8 incidencias de ejemplo.

## Estructura
- `src/SoporteIT.Core`: dominio y reglas de negocio (incidencias, SLA)
- `src/SoporteIT.Api`: endpoints y panel HTML
- `tests/SoporteIT.Tests`: pruebas xUnit
- `docs-demo/`: guion, prompts, checklist y archivos que se añaden en vivo
- `docs-demo/plan-b/`: parche con la solución completa, por si la demo se tuerce
- `.vscode/mcp.json`: servidor MCP de GitHub, para que Copilot traiga la issue asignada y abra la PR

## Endpoints
| Método | Ruta | Descripción |
|---|---|---|
| GET | /panel | Panel de incidencias con su estado de SLA |
| GET | /incidencias | Lista las incidencias |
| GET | /incidencias/{id} | Detalle |
| POST | /incidencias | Crea `{ "titulo", "aula", "prioridad" }` |
| POST | /incidencias/{id}/resolver | Marca como resuelta |
