using System;

// Clase que representa un nodo del árbol binario
class Node
{
    public int Value;
    public Node Left, Right;
    public Node(int value)
    {
        Value = value;
        Left = Right = null;
    }
}

// Clase que representa el Árbol Binario de Búsqueda (BST)
class BinaryTree
{
    private Node root; // Raíz del árbol

    // Método para insertar un valor en el árbol
    public void Insert(int value)
    {
        root = InsertRec(root, value);
    }

    private Node InsertRec(Node node, int value)
    {
        if (node == null)
            return new Node(value);

        if (value < node.Value)
            node.Left = InsertRec(node.Left, value);
        else
            node.Right = InsertRec(node.Right, value);

        return node;
    }

    // Método para buscar un valor en el árbol
    public bool Search(int value)
    {
        return SearchRec(root, value);
    }

    private bool SearchRec(Node node, int value)
    {
        if (node == null)
            return false;
        if (node.Value == value)
            return true;
        return value < node.Value ? SearchRec(node.Left, value) : SearchRec(node.Right, value);
    }

    // Método para recorrer el árbol en inorden
    public void InOrderTraversal()
    {
        InOrderRec(root);
        Console.WriteLine();
    }

    private void InOrderRec(Node node)
    {
        if (node != null)
        {
            InOrderRec(node.Left);
            Console.Write(node.Value + " ");
            InOrderRec(node.Right);
        }
    }

    // Método para eliminar un nodo del árbol
    public void Delete(int value)
    {
        root = DeleteRec(root, value);
    }

    private Node DeleteRec(Node node, int value)
    {
        if (node == null)
            return node;

        if (value < node.Value)
            node.Left = DeleteRec(node.Left, value);
        else if (value > node.Value)
            node.Right = DeleteRec(node.Right, value);
        else
        {
            // Caso 1: El nodo no tiene hijos o tiene un solo hijo
            if (node.Left == null)
                return node.Right;
            else if (node.Right == null)
                return node.Left;

            // Caso 2: El nodo tiene dos hijos, buscar el sucesor inorden
            Node temp = MinValueNode(node.Right);
            node.Value = temp.Value;
            node.Right = DeleteRec(node.Right, temp.Value);
        }
        return node;
    }

    // Método auxiliar para encontrar el nodo con el menor valor en el subárbol derecho
    private Node MinValueNode(Node node)
    {
        Node current = node;
        while (current.Left != null)
            current = current.Left;
        return current;
    }
}

// Clase principal con menú interactivo
class Program
{
    static void Main()
    {
        BinaryTree tree = new BinaryTree();
        while (true)
        {
            Console.WriteLine("1. Insertar nodo \n");
            Console.WriteLine("2. Buscar nodo \n");
            Console.WriteLine("3. Recorrido inorden \n");
            Console.WriteLine("4. Eliminar nodo \n");
            Console.WriteLine("5. Salir \n");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el valor a insertar: ");
                    tree.Insert(int.Parse(Console.ReadLine()));
                    break;
                case "2":
                    Console.Write("Ingrese el valor a buscar: ");
                    Console.WriteLine(tree.Search(int.Parse(Console.ReadLine())) ? "Encontrado" : "No encontrado");
                    break;
                case "3":
                    Console.Write("Recorrido inorden: ");
                    tree.InOrderTraversal();
                    break;
                case "4":
                    Console.Write("Ingrese el valor a eliminar: ");
                    tree.Delete(int.Parse(Console.ReadLine()));
                    Console.WriteLine("Nodo eliminado.");
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}

