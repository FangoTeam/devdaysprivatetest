# Prompts de la demo · v4 (v1 + MCP de GitHub)

1. `Explícame la arquitectura de este proyecto: qué hace cada proyecto de la solución, cómo viaja una petición y cómo lo arranco.`
2. `¿Hay reglas de negocio con riesgo escondidas en el código? Mira PoliticaSla y el panel.`
3. (con y sin instructions) `Añade la posibilidad de reabrir una incidencia resuelta: POST /incidencias/{id}/reabrir.`
4. (modo plan, MCP de GitHub) `¿Qué es lo siguiente que tengo que hacer? Busca la issue que tengo asignada en GitHub y, sin escribir código todavía, dame un plan por pasos con los archivos que tocarías, los casos límite y los tests que necesitas.`
   - Sin MCP: `Lee docs-demo/ISSUE.md. No escribas código todavía: dame un plan por pasos con los archivos que tocarías, los casos límite y los tests que necesitas.`
   - Ajuste: `Añade al plan fines de semana, creación antes de abrir y el cambio de hora de octubre.`
5. (modo agente) `Implementa el plan. Termina con dotnet test en verde.`
6. (agente Revisor) `Revisa todos los cambios y el proyecto completo.`
7. `Las pruebas de aceptación fallan. Analiza por qué y corrige el código sin tocar los tests.`
8. `Mueve la clave de administración a configuración y no la dejes en el código.`
9. (MCP de GitHub) `Crea una rama para esta issue, haz commit de los cambios, súbela y abre con el MCP de GitHub una Pull Request contra main con un título y una descripción clara: qué cambia, cómo se ha probado y Closes #<número de la issue>.`
   - Sin MCP: `Prepara el título y la descripción de la Pull Request para esta issue.`
