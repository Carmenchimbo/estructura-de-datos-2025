
class Grafo
{
    private Dictionary<string, List<string>> adyacencia;

    public Grafo()
    {
        adyacencia = new Dictionary<string, List<string>>();
    }

    public void AgregarConexion(string persona1, string persona2)
    {
        if (!adyacencia.ContainsKey(persona1))
            adyacencia[persona1] = new List<string>();
        if (!adyacencia.ContainsKey(persona2))
            adyacencia[persona2] = new List<string>();

        adyacencia[persona1].Add(persona2);
        adyacencia[persona2].Add(persona1);
    }

    public void CalcularCentralidadDeGrado()
    {
        foreach (var persona in adyacencia)
        {
            Console.WriteLine($"Centralidad de Grado de {persona.Key}: {persona.Value.Count}");
        }
    }

    public void CalcularCentralidadDeCercania(string inicio)
    {
        var distancias = new Dictionary<string, int>();
        var visitados = new HashSet<string>();
        var cola = new Queue<string>();
        
        foreach (var persona in adyacencia.Keys)
        {
            distancias[persona] = int.MaxValue;
        }

        distancias[inicio] = 0;
        cola.Enqueue(inicio);
        
        while (cola.Count > 0)
        {
            var actual = cola.Dequeue();
            if (visitados.Contains(actual)) continue;
            visitados.Add(actual);

            foreach (var vecino in adyacencia[actual])
            {
                if (!visitados.Contains(vecino))
                {
                    int nuevaDistancia = distancias[actual] + 1;
                    if (nuevaDistancia < distancias[vecino])
                    {
                        distancias[vecino] = nuevaDistancia;
                        cola.Enqueue(vecino);
                    }
                }
            }
        }

        foreach (var persona in distancias)
        {
            Console.WriteLine($"Distancia de {inicio} a {persona.Key}: {persona.Value}");
        }
    }
}

class Programa
{
    static void Main(string[] args)
    {
        var redSocial = new Grafo();
        redSocial.AgregarConexion("Ana", "Luis");
        redSocial.AgregarConexion("Ana", "Carlos");
        redSocial.AgregarConexion("Luis", "Carlos");
        redSocial.AgregarConexion("Luis", "Pedro");
        redSocial.AgregarConexion("Carlos", "Pedro");

        // Cálculo de Centralidad de Grado
        redSocial.CalcularCentralidadDeGrado();

        // Cálculo de Centralidad de Cercanía desde "Ana"
        redSocial.CalcularCentralidadDeCercania("Ana");
    }
}

