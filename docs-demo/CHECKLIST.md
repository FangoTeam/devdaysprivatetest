# Checklist previo · v4

## GitHub (nuevo en la v4)
- [ ] Issue del SLA creada en el repo de la demo (contenido de `ISSUE.md`) y **asignada al ponente**
- [ ] Servidor MCP `github` (`.vscode/mcp.json`) iniciado en VS Code y con sesión; prueba «¿qué issues tengo asignadas?»
- [ ] Para cada ensayo: cierra la PR anterior, borra la rama `issue-*` y reabre la issue
- [ ] Wifi probado: el MCP y la PR necesitan red

## Resto (igual que la v1)

- [ ] SDK de .NET instalado (`dotnet --version`); si no es .NET 10, ajustar `Directory.Build.props`
- [ ] `dotnet test` en verde en la rama `main` (la primera vez descarga paquetes: hazlo con red)
- [ ] `dotnet run --project src/SoporteIT.Api` abre el panel con 5 filas en rojo
- [ ] Copilot con modo agente, modo plan, agentes y skills disponibles en tu IDE (comprueba rutas `.github/` con la documentación actual)
- [ ] Zoom del editor al 150 % y terminal con letra grande
- [ ] Rama `demo-resuelta-v4` probada: panel con 3 filas en rojo
- [ ] Ensayo completo al menos 3 veces; un vídeo corto por bloque
- [ ] Wifi del aula probado o hotspot de respaldo
