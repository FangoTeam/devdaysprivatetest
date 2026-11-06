namespace SoporteIT.Api;

/// <summary>Reloj simulado para que la demo sea siempre igual.</summary>
public sealed class RelojFijo(DateTimeOffset ahora) : TimeProvider
{
    public override DateTimeOffset GetUtcNow() => ahora.ToUniversalTime();
}
