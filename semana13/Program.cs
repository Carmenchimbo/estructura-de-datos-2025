using s
class   program{
    static void Main() {
        revistas catalogo = new revistas();
        string[] titulos={"leoniza", "shopingru"
        };
        //insertar titulos en el catalogo//
        foreach (string titulo in titulos) {
            catalogo.insertar(titulo);
        }
        while (true) {
            Console.WriteLine("menu");
            Console.WriteLine("1. buscar revista");
            Console.WriteLine("2. salir");
            Console.WriteLine("seleccione una opcion: ");
            string opcion=Console.ReadLine("");
            if (opcion == "1") {
                Console.WriteLine("ingrese el titulo a buscar");
                string titulobuscado=Console.ReadLine("");

                bool encontrar=catalogo.buscartitulo(titulobuscado);
                Consolo.WriteLine(encontrado?"encontrado":"no encontrado");
            }else if (opcion=="2"){
                Console.WriteLine("saliendo del programa");
                break;
            }else {
                Console.WriteLine("opcion no valida intente de nuevo");
            }
        }
    }
}