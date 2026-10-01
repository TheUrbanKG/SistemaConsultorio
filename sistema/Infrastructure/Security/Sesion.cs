namespace sistema.Infrastructure.Security
{
    public static class Sesion
    {
        // Asigna esto al autenticar al usuario en tu formulario de login
        public static string UsuarioActual { get; set; }

        // Rol del usuario activo ('Administrador', 'Usuario', 'Recepcionista')
        public static string RolActual { get; set; }

        public static bool EsAdmin => string.Equals(RolActual, "Administrador", System.StringComparison.OrdinalIgnoreCase);
        public static bool EsRecepcionista => string.Equals(RolActual, "Recepcionista", System.StringComparison.OrdinalIgnoreCase);
        public static bool EsUsuario => string.Equals(RolActual, "Usuario", System.StringComparison.OrdinalIgnoreCase);

        // Control de acceso a expedientes clínicos (Recepcionista restringido)
        public static bool PuedeVerExpediente => !EsRecepcionista;
    }
}