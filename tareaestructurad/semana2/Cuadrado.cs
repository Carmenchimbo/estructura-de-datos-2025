// Clase que encapsula los datos y métodos de un cuadrado
public class Cuadrado
{
    // Atributo privado que almacena el valor del lado del cuadrado
    private double lado;

    // Constructor que inicializa el lado del cuadrado
    public Cuadrado(double lado)
    {
        this.lado = lado;
    }

    // Método para calcular el área del cuadrado
    public double CalcularArea()
    {
        return lado * lado; // Fórmula: lado * lado
    }

    // Método para calcular el perímetro del cuadrado
    public double CalcularPerimetro()
    {
        return 4 * lado; // Fórmula: 4 * lado
    }
}