class Traductor_Ingles_Espanol
{
    // Diccionario para traducciones de inglés a español
    static Dictionary<string, string> englishToSpanish = new Dictionary<string, string>
    {
        {"time", "tiempo"},
        {"person", "persona"},
        {"they work", "trabajan"},
        {"have", "tener"},
        {"year", "año"},
        {"way", "camino/forma"},
        {"day", "día"},
        {"thing", "cosa"},
        {"man", "hombre"},
        {"world", "mundo"},
        {"life", "vida"},
        {"hand", "mano"},
        {"part", "parte"},
        {"child", "niño/a"},
        {"eye", "ojo"},
        {"woman", "mujer"},
        {"place", "lugar"},
        {"work", "trabajo"},
        {"week", "semana"},
        {"case", "caso"},
        {"point", "punto/tema"},
        {"government", "gobierno"},
        {"company", "empresa/compañía"}
    };

    // Diccionario para traducciones de español a inglés
    static Dictionary<string, string> spanishToEnglish = new Dictionary<string, string>
    {
        {"tiempo", "time"},
        {"persona", "person"},
        {"año", "year"},
        {"camino", "way"},
        {"forma", "way"},
        {"día", "day"},
        {"cosa", "thing"},
        {"hombre", "man"},
        {"mundo", "world"},
        {"vida", "life"},
        {"mano", "hand"},
        {"parte", "part"},
        {"niño", "child"},
        {"niña", "child"},
        {"ojo", "eye"},
        {"mujer", "woman"},
        {"lugar", "place"},
        {"trabajo", "work"},
        {"semana", "week"},
        {"caso", "case"},
        {"punto", "point"},
        {"tema", "point"},
        {"gobierno", "government"},
        {"empresa", "company"},
        {"compañía", "company"}
    };

    static void Main(string[] args)
    {
        MostrarCaratula(); // Muestra la información del programa

        while (true) // Bucle principal del menú
        {
            Console.WriteLine("=========================== MENÚ ======================");
            Console.WriteLine("1. Traducir una frase \n");
            Console.WriteLine("2. Ingresar más palabras al diccionario\n");
            Console.WriteLine("0. Salir \n");
            Console.Write("Seleccione una opción: ");
            string option = Console.ReadLine();

            if (option == "1")
            {
                TranslatePhrase(); // Llamar al método de traducción
            }
            else if (option == "2")
            {
                AddWordToDictionary(); // Llamar al método para agregar palabras
            }
            else if (option == "0")
            {
                Console.WriteLine("\nGracias por usar el traductor. ¡Hasta luego!");
                break; // Salir del bucle y terminar el programa
            }
            else
            {
                Console.WriteLine("\nOpción no válida. Intente de nuevo.");
            }
        }
    }

    // Método para mostrar la carátula del programa
    static void MostrarCaratula()
    {
         Console.WriteLine(" ");
        Console.WriteLine("Univeridad Estatal Amazonica");
        Console.WriteLine(" ");
        Console.WriteLine("Estructura de Datos");
        Console.WriteLine(" ");
        Console.WriteLine("Programado por Carmen");
        Console.WriteLine(" ");
        Console.WriteLine("Paralelo A");
        
    }

    // Método para traducir una frase
    static void TranslatePhrase()
    {
        Console.Write("\nIngrese la frase: ");
        string phrase = Console.ReadLine();
        string[] words = phrase.Split(' '); // Separar la frase en palabras
        string translatedPhrase = "";

        foreach (string word in words)
        {
            // Convertir la palabra a minúsculas y eliminar signos de puntuación
            string cleanedWord = word.ToLower().Trim(new char[] { '.', ',', '!', '?' });
            
            // Buscar la palabra en los diccionarios
            if (englishToSpanish.ContainsKey(cleanedWord))
            {
                translatedPhrase += englishToSpanish[cleanedWord] + " ";
            }
            else if (spanishToEnglish.ContainsKey(cleanedWord))
            {
                translatedPhrase += spanishToEnglish[cleanedWord] + " ";
            }
            else
            {
                translatedPhrase += word + " "; // Mantener la palabra si no se encuentra traducción
            }
        }

        Console.WriteLine("\nSu frase traducida es: " + translatedPhrase.Trim());
    }

    // Método para agregar palabras al diccionario
    static void AddWordToDictionary()
    {
        Console.Write("\nIngrese la palabra en inglés: ");
        string englishWord = Console.ReadLine().ToLower();
        Console.Write("Ingrese la traducción en español: ");
        string spanishWord = Console.ReadLine().ToLower();

        // Verificar si la palabra ya existe en el diccionario
        if (!englishToSpanish.ContainsKey(englishWord))
        {
            englishToSpanish.Add(englishWord, spanishWord);
            spanishToEnglish.Add(spanishWord, englishWord);
            Console.WriteLine("\nPalabra agregada correctamente.");
        }
        else
        {
            Console.WriteLine("\nLa palabra ya existe en el diccionario.");
        }
    }
}