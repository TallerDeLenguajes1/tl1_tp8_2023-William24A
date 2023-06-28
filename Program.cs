// See https://aka.ms/new-console-template for more information

// using  EspacioTareas;

// List<Tareas> MiLista = new List<Tareas>();
// List<Tareas> MiListaTerminada = new List<Tareas>();

// int ID;
// string DescripcionTarea;
// int DuracionTarea;
// Como ingresar valores aleatorios 
// var seed = Environment.TickCount;
// var random = new Random(seed);


// int op;
// do{
//     Console.Clear();
//     Console.WriteLine("Ingrese la opcion");
//     Console.WriteLine("1-Ingresar N tareas");
//     Console.WriteLine("2-Ingresar a lista de tareas terminadas");
//     Console.WriteLine("3-Buscar en tares pendiente una descripcion");
//     Console.WriteLine("4-Mostrar tareas terminada y pendientes");
//     Console.WriteLine("5-Guarde horas trabajadas por este empleado");
//     Console.WriteLine("6-Salir");
//     Console.Write("Opcion: ");
//     op= IngresarInt();
//     switch(op){
//         case 1:
//             Console.Clear();
//             Console.Write("Ingrese el numero de tareas: ");
//             int cantidad = IngresarInt();
//             for (int i = 0; i < cantidad; i++)
//             { 
//                 Console.Clear();
//                 ID = i+1;
//                 Console.WriteLine("Ingrese descripcion de tarea "+ID+": ");
//                 DescripcionTarea = Console.ReadLine();
//                 DuracionTarea = random.Next(10,100);
//                 Tareas valor1 = new Tareas(ID, DescripcionTarea, DuracionTarea);
//                 MiLista.Add(valor1);
//             }
//             Console.WriteLine("Presione enter para continuar.");
//             Console.ReadKey();
//             break;
//         case 2:
//             Console.Clear();
//             int opcion;
//             for (int i=0; i< MiLista.Count; i++) // Count es una clase que permite contar los elementos de una lista 
//             {
//                 Console.WriteLine("Tarea pendiente");
//                 MiLista[i].Mostrar();
//                 do{
//                     Console.WriteLine("Desea colocar esta tarea como terminada: Yes(1) No(0)");
//                     opcion = IngresarInt();
//                 }while(opcion != 1 && opcion != 0);
//                 if(opcion == 1){
//                         MiListaTerminada.Add(MiLista[i]); // Add clase que añade elemento a una lista
//                         MiLista.RemoveAt(i); // eleimina un elemento de una lista en este caso utilizamos la posicion 
//                         i--;
//                 }
//             }
//             Console.WriteLine("Presione enter para continuar.");
//             Console.ReadKey();
//             break;
//         case 3:
//             Console.Clear();
//             Console.WriteLine("Buscar tarea por descripcion");
//             Console.Write("Ingrese la tarea a buscar: ");
//             string treaBuscar = Console.ReadLine();
//             bool estarea;
//             foreach(var item in MiLista){
//                 estarea =item.Descripcion.Contains(treaBuscar); //Busca una subcadena en otra cadena la clase Caontains devuelve un bool
//                 if(estarea){
//                     item.Mostrar();
//                 }
//             }
//             Console.WriteLine("\nPresione enter para continuar.");
//             Console.ReadKey();
//             break;
//         case 4:
//             Console.Clear();
//             Console.WriteLine("Tarea pendiente");
//             foreach (var item in MiLista)
//             {   
//                 item.Mostrar();
//             }
//             Console.WriteLine("Tarea terminadas");
//             foreach (var item in MiListaTerminada)
//             {
//                 item.Mostrar();
//             }
//             Console.WriteLine("Presione enter para continuar.");
//             Console.ReadKey();
//             break;
//         case 5:
//             Console.Clear();
//             string ruta = @"C:\Users\wil37\OneDrive\Documentos\A_Segundo_Año\Taller de Lenguaje 1\tl1_tp8_2023-William24A\archivo.txt";
//             try
//             {
//                 using( StreamWriter archivo = new StreamWriter(ruta, true))
//                 {   
//                     int suma=0;
//                     foreach(var item in MiListaTerminada){
//                         suma +=item.Duracion;
//                     }
//                     archivo.WriteLine("Empleado trabajo: ");
//                     archivo.WriteLine(suma);
//                 }
//                 Console.WriteLine("Archivo creado exitosamente.");
//             }
//             catch (System.Exception)
//             {
                
//                 throw;
//             }
//             Console.WriteLine("Presione enter para continuar.");
//             Console.ReadKey();
//             break;
//         case 6:
//             Console.Clear();
//             Console.WriteLine("Gracias por elegirnos.");
//             break;
//     }
// }while( op != 6);

// Funcion ingresar entero 6
// int IngresarInt(){
//     int op;
//     if(int.TryParse(Console.ReadLine(), out op)){
//         return op;
//     }else{
//         Console.WriteLine("Error");
//         return 9999;
//     }
// }

Console.Write("Ingrese ruta de carpeta: "); //ingresar la ruta de la carpeta
string rutaArchivo = Console.ReadLine();

if(!Directory.Exists(rutaArchivo)){ //funcion que indica si es que existe un archivo o no
    Console.WriteLine("No existe este archivo.");
    return;
}

try
{
    var listaArchivos = new List<string>();
    string nombreA;

    foreach(var archivo in Directory.GetFiles(rutaArchivo)) // se buscan las carpetas que existan en esa ruta dada
    {
        nombreA = archivo.ToString().Split(@"\").Last();
        listaArchivos.Add(nombreA);
    } 
    // crear archivo cvs
    using( StreamWriter archivo = new StreamWriter("index.csv", true) ){
        archivo.WriteLine("Indice,Archivo, Extension");
        for (int i = 0; i < listaArchivos.Count ; i++)
        {
            string nombre = Path.GetFileName(listaArchivos[i]); // extrae en nombre del archivo
            string extension = Path.GetExtension(listaArchivos[i]); // extrae la extesion del archivo con el .
            archivo.WriteLine($"{i+1},{nombre.Split(".")[0]},{extension.Split(".")[1]}");

        }

        Console.WriteLine("Se guardo exitosamente el archivo index.cvs");
    }
}
catch (System.Exception)
{
    throw;
}