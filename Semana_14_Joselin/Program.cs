
//árboles binarios, con tipos de datos primitivos (enteros, cadenas, etc.) o
 //de objetos a su elección, para demostrar las principales operaciones contenidas
  //en las diapositivas de esta semana. La aplicación deberá contener un menú para mostrar 
//cada una de las operaciones y el registro de datos dentro del árbol, se lo realizará mediante teclado.

namespace ArbolBinarioApp
{
    // Clase para los nodos del árbol
    class Nodo
    {
        public int Valor { get; set; }
        public Nodo Izquierdo { get; set; }
        public Nodo Derecho { get; set; }

        public Nodo(int valor)
        {
            Valor = valor;
            Izquierdo = null;
            Derecho = null;
        }
    }

    // Clase principal del árbol binario
    class ArbolBinario
    {
        public Nodo Raiz { get; private set; }

        public ArbolBinario()
        {
            Raiz = null;
        }

        // Insertar un valor en el árbol
        public void Insertar(int valor)
        {
            Raiz = InsertarRecursivo(Raiz, valor);
        }

        private Nodo InsertarRecursivo(Nodo nodo, int valor)
        {
            // Si el nodo es nulo, crear un nuevo nodo
            if (nodo == null)
            {
                return new Nodo(valor);
            }

            // Si el valor es menor, insertar en el subárbol izquierdo
            if (valor < nodo.Valor)
            {
                nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, valor);
            }
            // Si el valor es mayor, insertar en el subárbol derecho
            else if (valor > nodo.Valor)
            {
                nodo.Derecho = InsertarRecursivo(nodo.Derecho, valor);
            }
            // Si el valor ya existe, no hacer nada
            
            return nodo;
        }

        // Buscar un valor en el árbol
        public bool Buscar(int valor)
        {
            return BuscarRecursivo(Raiz, valor);
        }

        private bool BuscarRecursivo(Nodo nodo, int valor)
        {
            // Si el nodo es nulo, el valor no existe
            if (nodo == null)
            {
                return false;
            }

            // Si el valor es igual al valor del nodo, se encontró
            if (valor == nodo.Valor)
            {
                return true;
            }

            // Si el valor es menor, buscar en el subárbol izquierdo
            if (valor < nodo.Valor)
            {
                return BuscarRecursivo(nodo.Izquierdo, valor);
            }
            // Si el valor es mayor, buscar en el subárbol derecho
            return BuscarRecursivo(nodo.Derecho, valor);
        }

        // Eliminar un valor del árbol
        public void Eliminar(int valor)
        {
            Raiz = EliminarRecursivo(Raiz, valor);
        }

        private Nodo EliminarRecursivo(Nodo nodo, int valor)
        {
            // Si el nodo es nulo, el valor no existe
            if (nodo == null)
            {
                return null;
            }

            // Si el valor es menor, eliminar del subárbol izquierdo
            if (valor < nodo.Valor)
            {
                nodo.Izquierdo = EliminarRecursivo(nodo.Izquierdo, valor);
            }
            // Si el valor es mayor, eliminar del subárbol derecho
            else if (valor > nodo.Valor)
            {
                nodo.Derecho = EliminarRecursivo(nodo.Derecho, valor);
            }
            // Si el valor es igual, este es el nodo a eliminar
            else
            {
                // Caso 1: Nodo hoja (sin hijos)
                if (nodo.Izquierdo == null && nodo.Derecho == null)
                {
                    return null;
                }
                // Caso 2: Nodo con un solo hijo
                else if (nodo.Izquierdo == null)
                {
                    return nodo.Derecho;
                }
                else if (nodo.Derecho == null)
                {
                    return nodo.Izquierdo;
                }
                // Caso 3: Nodo con dos hijos
                else
                {
                    // Encontrar el sucesor (el valor más pequeño en el subárbol derecho)
                    nodo.Valor = EncontrarMinimo(nodo.Derecho);
                    // Eliminar el sucesor
                    nodo.Derecho = EliminarRecursivo(nodo.Derecho, nodo.Valor);
                }
            }
            return nodo;
        }

        // Encuentra el valor mínimo en un subárbol
        private int EncontrarMinimo(Nodo nodo)
        {
            int minimo = nodo.Valor;
            while (nodo.Izquierdo != null)
            {
                minimo = nodo.Izquierdo.Valor;
                nodo = nodo.Izquierdo;
            }
            return minimo;
        }

        // Recorrido en orden (inorden)
        public List<int> RecorridoInOrden()
        {
            List<int> resultado = new List<int>();
            RecorridoInOrdenRecursivo(Raiz, resultado);
            return resultado;
        }

        private void RecorridoInOrdenRecursivo(Nodo nodo, List<int> resultado)
        {
            if (nodo != null)
            {
                RecorridoInOrdenRecursivo(nodo.Izquierdo, resultado);
                resultado.Add(nodo.Valor);
                RecorridoInOrdenRecursivo(nodo.Derecho, resultado);
            }
        }

        // Recorrido preorden
        public List<int> RecorridoPreOrden()
        {
            List<int> resultado = new List<int>();
            RecorridoPreOrdenRecursivo(Raiz, resultado);
            return resultado;
        }

        private void RecorridoPreOrdenRecursivo(Nodo nodo, List<int> resultado)
        {
            if (nodo != null)
            {
                resultado.Add(nodo.Valor);
                RecorridoPreOrdenRecursivo(nodo.Izquierdo, resultado);
                RecorridoPreOrdenRecursivo(nodo.Derecho, resultado);
            }
        }

        // Recorrido postorden
        public List<int> RecorridoPostOrden()
        {
            List<int> resultado = new List<int>();
            RecorridoPostOrdenRecursivo(Raiz, resultado);
            return resultado;
        }

        private void RecorridoPostOrdenRecursivo(Nodo nodo, List<int> resultado)
        {
            if (nodo != null)
            {
                RecorridoPostOrdenRecursivo(nodo.Izquierdo, resultado);
                RecorridoPostOrdenRecursivo(nodo.Derecho, resultado);
                resultado.Add(nodo.Valor);
            }
        }

        // Calcular la altura del árbol
        public int Altura()
        {
            return AlturaRecursiva(Raiz);
        }

        private int AlturaRecursiva(Nodo nodo)
        {
            if (nodo == null)
            {
                return 0;
            }
            else
            {
                int alturaIzquierda = AlturaRecursiva(nodo.Izquierdo);
                int alturaDerecha = AlturaRecursiva(nodo.Derecho);

                return Math.Max(alturaIzquierda, alturaDerecha) + 1;
            }
        }

        // Contar el número de nodos
        public int ContarNodos()
        {
            return ContarNodosRecursivo(Raiz);
        }

        private int ContarNodosRecursivo(Nodo nodo)
        {
            if (nodo == null)
            {
                return 0;
            }
            else
            {
                return 1 + ContarNodosRecursivo(nodo.Izquierdo) + ContarNodosRecursivo(nodo.Derecho);
            }
        }
    }

    // Clase principal de la aplicación
    class Program
    {
        static void Main(string[] args)
        {
            ArbolBinario arbol = new ArbolBinario();
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== ÁRBOL BINARIO DE BÚSQUEDA ===");
                Console.WriteLine("1. Insertar un valor");
                Console.WriteLine("2. Buscar un valor");
                Console.WriteLine("3. Eliminar un valor");
                Console.WriteLine("4. Recorrido en orden (InOrden)");
                Console.WriteLine("5. Recorrido en preorden (PreOrden)");
                Console.WriteLine("6. Recorrido en postorden (PostOrden)");
                Console.WriteLine("7. Altura del árbol");
                Console.WriteLine("8. Número de nodos");
                Console.WriteLine("9. Salir");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Ingrese el valor a insertar: ");
                            if (int.TryParse(Console.ReadLine(), out int valorInsertar))
                            {
                                arbol.Insertar(valorInsertar);
                                Console.WriteLine($"Valor {valorInsertar} insertado correctamente.");
                            }
                            else
                            {
                                Console.WriteLine("Valor inválido. Debe ser un número entero.");
                            }
                            break;

                        case 2:
                            Console.Write("Ingrese el valor a buscar: ");
                            if (int.TryParse(Console.ReadLine(), out int valorBuscar))
                            {
                                bool encontrado = arbol.Buscar(valorBuscar);
                                if (encontrado)
                                {
                                    Console.WriteLine($"El valor {valorBuscar} existe en el árbol.");
                                }
                                else
                                {
                                    Console.WriteLine($"El valor {valorBuscar} NO existe en el árbol.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Valor inválido. Debe ser un número entero.");
                            }
                            break;

                        case 3:
                            Console.Write("Ingrese el valor a eliminar: ");
                            if (int.TryParse(Console.ReadLine(), out int valorEliminar))
                            {
                                arbol.Eliminar(valorEliminar);
                                Console.WriteLine($"El valor {valorEliminar} ha sido eliminado del árbol si existía.");
                            }
                            else
                            {
                                Console.WriteLine("Valor inválido. Debe ser un número entero.");
                            }
                            break;

                        case 4:
                            List<int> inorden = arbol.RecorridoInOrden();
                            Console.WriteLine("Recorrido InOrden:");
                            MostrarLista(inorden);
                            break;

                        case 5:
                            List<int> preorden = arbol.RecorridoPreOrden();
                            Console.WriteLine("Recorrido PreOrden:");
                            MostrarLista(preorden);
                            break;

                        case 6:
                            List<int> postorden = arbol.RecorridoPostOrden();
                            Console.WriteLine("Recorrido PostOrden:");
                            MostrarLista(postorden);
                            break;

                        case 7:
                            int altura = arbol.Altura();
                            Console.WriteLine($"La altura del árbol es: {altura}");
                            break;

                        case 8:
                            int cantidadNodos = arbol.ContarNodos();
                            Console.WriteLine($"El número de nodos en el árbol es: {cantidadNodos}");
                            break;

                        case 9:
                            salir = true;
                            break;

                        default:
                            Console.WriteLine("Opción inválida. Intente nuevamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        // Método para mostrar los elementos de una lista
        static void MostrarLista(List<int> lista)
        {
            if (lista.Count == 0)
            {
                Console.WriteLine("El árbol está vacío.");
                return;
            }

            foreach (int valor in lista)
            {
                Console.Write($"{valor} ");
            }
            Console.WriteLine();
        }
    }
}