// See https://aka.ms/new-console-template for more information

using  EspacioTareas;

List<Tareas> MiLista = new List<Tareas>();
List<Tareas> MiListaTerminada = new List<Tareas>();

int ID;
string DescripcionTarea;
int DuracionTarea;
//Como ingresar valores aleatorios 
var seed = Environment.TickCount;
var random = new Random(seed);


int op;
do{
    Console.Clear();
    Console.WriteLine("Ingrese la opcion");
    Console.WriteLine("1-Ingresar N tareas");
    Console.WriteLine("2-Ingresar a lista de tareas terminadas");
    Console.WriteLine("3-Buscar en tares pendiente una descripcion");
    Console.WriteLine("4-Mostrar tareas terminada y pendientes");
    Console.WriteLine("5-Salir");
    Console.Write("Opcion: ");
    op= IngresarInt();
    switch(op){
        case 1:
            Console.Clear();
            Console.Write("Ingrese el numero de tareas: ");
            int cantidad = IngresarInt();
            for (int i = 0; i < cantidad; i++)
            { 
                Console.Clear();
                Console.WriteLine("Ingrese el ID de la tarea: ");
                ID = IngresarInt();
                Console.WriteLine("Ingrese descripcion de tarea: ");
                DescripcionTarea = Console.ReadLine();
                DuracionTarea = random.Next(10,100);
                Tareas valor1 = new Tareas(ID, DescripcionTarea, DuracionTarea);
                MiLista.Add(valor1);
            }
            Console.WriteLine("Presione enter para continuar.");
            Console.ReadKey();
            break;
        case 2:
            Console.Clear();
            int opcion;
            for (int i=0; i< MiLista.Count; i++) // Count es una clase que permite contar los elementos de una lista 
            {
                Console.WriteLine("Tarea pendiente");
                MiLista[i].Mostrar();
                do{
                    Console.WriteLine("Desea colocar esta tarea como terminada: Yes(1) No(0)");
                    opcion = IngresarInt();
                }while(opcion != 1 && opcion != 0);
                if(opcion == 1){
                        MiListaTerminada.Add(MiLista[i]); // Add clase que añade elemento a una lista
                        MiLista.RemoveAt(i); // eleimina un elemento de una lista en este caso utilizamos la posicion 
                        i--;
                }
            }
            Console.WriteLine("Presione enter para continuar.");
            Console.ReadKey();
            break;
        case 3:
            Console.Clear();
            Console.WriteLine("Buscar tarea por descripcion");
            Console.Write("Ingrese la tarea a buscar: ");
            string treaBuscar = Console.ReadLine();
            bool estarea;
            foreach(var item in MiLista){
                estarea =item.Descripcion.Contains(treaBuscar); //Busca una subcadena en otra cadena la clase Caontains devuelve un bool
                if(estarea){
                    item.Mostrar();
                }
            }
            Console.WriteLine("\nPresione enter para continuar.");
            Console.ReadKey();
            break;
        case 4:
            Console.Clear();
            Console.WriteLine("Tarea pendiente");
            foreach (var item in MiLista)
            {   
                item.Mostrar();
            }
            Console.WriteLine("Tarea terminadas");
            foreach (var item in MiListaTerminada)
            {
                item.Mostrar();
            }
            Console.WriteLine("Presione enter para continuar.");
            Console.ReadKey();
            break;
        case 5:
            Console.Clear();
            Console.WriteLine("Gracias por elegirnos.");
            break;
    }
}while( op != 5);

//Funcion ingresar entero 
int IngresarInt(){
    int op;
    if(int.TryParse(Console.ReadLine(), out op)){
        return op;
    }else{
        Console.WriteLine("Error");
        return 9999;
    }
}
