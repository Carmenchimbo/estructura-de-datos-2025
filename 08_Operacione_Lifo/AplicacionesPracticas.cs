public static class LifoAplicaciones
{
    public static void run()
    {
        // Se crea una instancia del parque de diversiones.
        ParqueDiversiones parque = new ParqueDiversiones();

        // Se registran personas en la atracción.
        parque.RegistrarPersona("Luis");
        parque.RegistrarPersona("Sofía");
        parque.RegistrarPersona("Carlos");

        // Se muestra el estado de la cola.
        parque.VerCola();

        // Se asignan asientos a las primeras personas en la cola.
        parque.AsignarAsiento();
        parque.AsignarAsiento();

        // Se muestra nuevamente el estado de la cola después de asignar los asientos.
        parque.VerCola();
    }
}

/// <summary>
/// Clase que representa un parque de diversiones con una cola de espera para las atracciones.
/// </summary>
class ParqueDiversiones
{
    // Cola para gestionar las personas que esperan para subir a la atracción.
    private System.Collections.Generic.Queue<string> colaDeEspera;

    /// <summary>
    /// Constructor que inicializa la cola de espera.
    /// </summary>
    public ParqueDiversiones()
    {
        colaDeEspera = new System.Collections.Generic.Queue<string>();
    }

    /// <summary>
    /// Registra una persona en la cola de espera.
    /// </summary>
    /// <param name="nombre">Nombre de la persona que se registra.</param>
    public void RegistrarPersona(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            System.Console.WriteLine("El nombre no puede estar vacío.");
            return;
        }

        colaDeEspera.Enqueue(nombre); // Se agrega la persona al final de la cola.
        System.Console.WriteLine(nombre + " ha sido registrado para la atracción.");
    }

    /// <summary>
    /// Asigna un asiento a la primera persona en la cola y la elimina de la lista de espera.
    /// </summary>
    public void AsignarAsiento()
    {
        if (colaDeEspera.Count > 0) // Verifica si hay personas en la cola.
        {
            string persona = colaDeEspera.Dequeue(); // Se obtiene y elimina la primera persona de la cola.
            System.Console.WriteLine(persona + " ha subido a la atracción.");
            System.Console.WriteLine("Quedan " + colaDeEspera.Count + " personas en la cola.");
        }
        else
        {
            System.Console.WriteLine("No hay personas en la cola.");
        }
    }

    /// <summary>
    /// Muestra el estado actual de la cola de espera.
    /// </summary>
    public void VerCola()
    {
        System.Console.WriteLine("Estado actual de la cola:");
        if (colaDeEspera.Count > 0)
        {
            foreach (var persona in colaDeEspera)
            {
                System.Console.WriteLine(persona);
            }
        }
        else
        {
            System.Console.WriteLine("La cola está vacía.");
        }
    }
}
