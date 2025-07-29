namespace NobleHabitat.Domain.Entities;

public class Usuario
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public Cliente? Cliente { get; set; }
    public Propietario? Propietario { get; set; }
    public Agente? Agente { get; set; }

    public bool EsAdmin { get; set; } = false;
}

