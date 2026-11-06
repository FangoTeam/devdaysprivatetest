# Issue #1: El SLA debe contar solo el horario lectivo

**Contexto**
Los plazos de respuesta (SLA) se calculan sumando horas naturales, así que una incidencia abierta el viernes por la tarde aparece como vencida el sábado, cuando en el centro no hay nadie. El panel está dando falsas alarmas al equipo de soporte.

**Qué hay que hacer**
- El SLA solo cuenta el **horario lectivo**: lunes a viernes, de 08:00 a 15:00, hora de Madrid.
- Si la incidencia se crea fuera de horario, el plazo empieza a contar en la siguiente apertura.
- Mantén la firma pública de `PoliticaSla.Vencimiento(Incidencia)`: el panel ya la usa.
- Añade `GET /incidencias/vencidas`: incidencias no resueltas cuyo SLA ha vencido según el reloj (`TimeProvider`).
- Los festivos quedan fuera de esta issue.

**Criterios de aceptación**
- Tests nuevos que cubran los casos límite del horario.
- `dotnet test` en verde.
- README actualizado con el nuevo endpoint.
- El panel muestra solo las incidencias que realmente han vencido.
