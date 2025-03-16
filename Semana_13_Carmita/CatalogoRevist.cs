
// Clase principal que ejecuta el programa
public class CatalogoRevista {

    public static void Main() {

        CatalogoRevistas catalogo = new CatalogoRevistas();

        string[] titulos = {

            "National Geographic", "Scientific American", "Time", "Forbes", "Nature",
            "The Economist", "Popular Science", "Wired", "Discover", "Smithsonian"
        };

        // Insertar los 10 títulos en el catálogo

        foreach (string titulo in titulos) {

            catalogo.Insertar(titulo);
        }

        // Menú interactivo para buscar revistas
        while (true) {
            Console.WriteLine("\n=== Menú del Catálogo de Revistas === \n");

            Console.WriteLine("1. Buscar un título \n ");

            Console.WriteLine("2. Salir \n");

            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            if (opcion == "1") {

                Console.Write("Ingrese el título de la revista a buscar: ");

                string tituloBuscado = Console.ReadLine();

                bool encontrado = catalogo.BuscarTitulo(tituloBuscado);

                Console.WriteLine(encontrado ? "Encontrado" : "No encontrado");

            } else if (opcion == "2") {

                Console.WriteLine("Saliendo del programa...");
                break;

            } else {

                Console.WriteLine("Opción no válida. Intente de nuevo.");
            }
        }
    }
}

// Clase que representa el catálogo de revistas usando un Árbol Binario de Búsqueda (ABB)
public class CatalogoRevistas {

    private RevistaNodo raiz; // Nodo raíz del árbol


    // Método para insertar un título en el catálogo (ABB)
    public void Insertar(string titulo) {

        raiz = InsertarRecursivo(raiz, titulo);
    }

    // Método auxiliar recursivo para insertar un nuevo título en el árbol
    private RevistaNodo InsertarRecursivo(RevistaNodo nodo, string titulo) {

        if (nodo == null) {

            return new RevistaNodo(titulo);
        }

        int comparador = String.CompareOrdinal(titulo, nodo.Titulo);

        if (comparador < 0) {

            nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, titulo);

        } else if (comparador > 0) {

            nodo.Derecho = InsertarRecursivo(nodo.Derecho, titulo);
        }

        return nodo;
    }

    // Método para buscar un título en el catálogo usando búsqueda recursiva
    public bool BuscarTitulo(string titulo) {

        return BuscarRecursivo(raiz, titulo);
    }

    // Método auxiliar recursivo para buscar un título en el árbol
    private bool BuscarRecursivo(RevistaNodo nodo, string titulo) {

        if (nodo == null) {
            
            return false;
        }

        int comparador = String.CompareOrdinal(titulo, nodo.Titulo);

        if (comparador == 0) {
            return true; // Se encontró el título
        } else if (comparador < 0) {
            return BuscarRecursivo(nodo.Izquierdo, titulo);
        } else {
            return BuscarRecursivo(nodo.Derecho, titulo);
        }
    }
}

// Clase que representa un nodo en el Árbol Binario de Búsqueda
public class RevistaNodo {
    public string Titulo; // Título de la revista
    public RevistaNodo Izquierdo; // Hijo izquierdo en el ABB
    public RevistaNodo Derecho; // Hijo derecho en el ABB

    // Constructor de la clase RevistaNodo
    public RevistaNodo(string titulo) {

        Titulo = titulo;

        Izquierdo = null;

        Derecho = null;
    }
}
