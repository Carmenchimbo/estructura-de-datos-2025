using System;

namespace HolaMundo
{
    // Clase Rectángulo
    public class Rectangulo
    {
        private double largo;
        private double ancho;

        // Constructor
        public Rectangulo(double _largo, double _ancho)
        {
            largo = _largo;
            ancho = _ancho;
        }

        // Área del rectángulo
        public double Area()
        {
            return largo * ancho;
        }

        // Perímetro del rectángulo
        public double Perimetro()
        {
            return 2 * (largo + ancho);  // 2*(largo + ancho)
        }
    }

    // Clase Círculo
    public class Circulo
    {
        private double radio;

        // Constructor
        public Circulo(double _radio)
        {
            radio = _radio;
        }

        // Área del círculo
        public double Area()
        {
            return Math.PI * radio * radio;  // π * radio²
        }

        // Perímetro del círculo
        public double Perimetro()
        {
            return 2 * Math.PI * radio;  // 2 * π * radio
        }
    }

    // Clase principal que se muestra en pantalla
    public class Programa
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Universidad Estatal Amazónica");
            Console.WriteLine("------------------------------------");
            
            // Mostrar información del Rectángulo
            Console.WriteLine("Rectángulo:");
            Rectangulo figuraRectangulo = new Rectangulo(5.0, 3.0);
            Console.WriteLine("El área del rectángulo es: " + figuraRectangulo.Area().ToString("F2"));
            Console.WriteLine("El perímetro del rectángulo es: " + figuraRectangulo.Perimetro().ToString("F2"));
            Console.WriteLine("------------------------------------");

            // Mostrar información del Círculo
            Console.WriteLine("Círculo:");
            Circulo figuraCirculo = new Circulo(4.0);
            Console.WriteLine("El área del círculo es: " + figuraCirculo.Area().ToString("F2"));
            Console.WriteLine("El perímetro del círculo es: " + figuraCirculo.Perimetro().ToString("F2"));
            Console.WriteLine("------------------------------------");
        }
    }
}
