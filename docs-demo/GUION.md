# Guion de la demo · SoporteIT · v4 (45 min)

**Único cambio respecto a la v1:** la issue está en GitHub y Copilot la trae con el **MCP de GitHub**; al final, también abre la Pull Request con el MCP.

**Historia:** primer día en el equipo de soporte IT de un instituto. El panel marca incidencias como vencidas cuando no lo están. Tu primera tarea: arreglar el SLA.

**Momentos "wow"** (no los cuentes antes):
1. El panel enseña 5 incidencias en rojo. Al terminar, solo 3. El panel "mentía" y nadie tocó la pantalla.
2. Copilot encuentra solo el `TODO` del SLA y explica el problema de negocio.
3. Las pruebas de aceptación del cliente rompen la solución del agente (o la confirman) delante de todos.
4. El Revisor encuentra una clave secreta en el código que nadie le había pedido buscar.

## 09:00 · Bienvenido a tu primer trabajo (5 min)
- Slides. Arranca `dotnet run --project src/SoporteIT.Api`: el panel se abre con 5 filas en rojo.
- Di: «Tu jefa dice que el panel de incidencias da falsas alarmas. Tienes 8 horas y un compañero nuevo».

## 09:30 · Entiende el proyecto antes de tocar nada (8 min)
- Chat con el repo: prompt 1 y 2 de `PROMPTS.md`. Fíjate en que localiza el `TODO` en `PoliticaSla`.
- Instructions: pide «reabrir una incidencia» SIN reglas, observa (¿`DateTime.UtcNow`?, ¿sin tests?), `git restore .`.
- Copia `copilot-instructions.md` a `.github/` y repite. Contraste: `TimeProvider`, español, tests.

## 10:30 · Tu primera tarea (8 min)
- Pregunta «¿Qué es lo siguiente que tengo que hacer?» y pide SOLO el plan (prompt 4). Copilot usa el MCP de GitHub para encontrar y leer tu issue asignada: enseña las llamadas a herramientas. No implementes.
- Cuestiónalo: ¿contempla fines de semana, antes de abrir, cambio de hora? Pídele que lo añada.
- Di: «El agente ejecuta bien lo que se ha entendido y planificado».

## 12:00 · Manos al código (12 min)
- Copia el agente `revisor.agent.md` y la skill `crear-endpoint` a `.github/`.
- Modo agente: «Implementa el plan» (prompt 5). Mientras trabaja, explica qué ve la sala.
- Revisa el diff en voz alta. Pasa el Revisor (prompt 6): debe señalar la clave en `Program.cs` y el repositorio no thread-safe.

## 15:00 · Que funcione no significa que esté bien (7 min)
- Copia `docs-demo/pruebas-aceptacion/SlaAceptacionTests.cs` a `tests/SoporteIT.Tests/` y ejecuta `dotnet test`.
- Si falla algo (viernes por la tarde, cambio de hora): prompt 7, sin tocar los tests. Si todo pasa: «Bien por el agente, pero la nota no es suya: la tienen las pruebas».
- Recarga el panel: pasan de 5 a 3 filas rojas. Mueve la clave a configuración (prompt 8) y pide la PR (prompt 9): Copilot crea la rama, hace commit y push y abre la PR con el MCP. Enséñala en GitHub con `Closes #1`. No hagas merge.

## 17:00 · Fin de tu primer día (5 min)
- Slides. Qué hizo Copilot, qué decidiste tú.

## Si algo falla
- Rama `demo-resuelta-v4` con la solución completa: `git restore . && git clean -fd v4/demo && git switch demo-resuelta-v4` (en un repo creado con `preparar-repo-demo.ps1`: `git switch demo-resuelta`).
- Sin la rama: `git apply --ignore-whitespace docs-demo/plan-b/demo-resuelta.patch` desde la carpeta de la demo.
- **El MCP no responde o no hay red:** pega `ISSUE.md` en el chat y sigue con el prompt 4 «Sin MCP». Para la PR, usa el prompt 9 «Sin MCP» y ábrela desde la web.
- El modelo no es determinista: ensaya al menos 3 veces. Graba un vídeo corto por bloque.
