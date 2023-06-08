// See https://aka.ms/new-console-template for more information

using  EspacioTareas;

List<Tareas> MiLista = new List<Tareas>();
List<Tareas> MiListaTerminada = new List<Tareas>();
Console.WriteLine("Ingrese el numero de tareas:");
int cantidad = IngresarInt();
int ID;
string DescripcionTarea;
int DuracionTarea;

var seed = Environment.TickCount;
var random = new Random(seed);

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
Console.Clear();
int opcion;
for (int i=0; i< MiLista.Count; i++)
{
    Console.WriteLine("Tarea pendiente");
    MiLista[i].Mostrar();
    do{
        Console.WriteLine("Desea colocar esta tarea como terminada: Yes(1) No(0)");
        opcion = IngresarInt();
    }while(opcion != 1 && opcion != 0);
   if(opcion == 1){
        MiListaTerminada.Add(MiLista[i]);
        MiLista.RemoveAt(i);
        i--;
   }
}

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

Console.Clear();
Console.WriteLine("Buscar tarea por descripcion");
Console.Write("Ingrese la tarea a buscar: ");
string treaBuscar = Console.ReadLine();
bool estarea;
foreach(var item in MiLista){
    estarea =item.Descripcion.Contains(treaBuscar);
    if(estarea){
        item.Mostrar();
    }
}


int IngresarInt(){
    int op;
    if(int.TryParse(Console.ReadLine(), out op)){
        return op;
    }else{
        Console.WriteLine("Error");
        return 9999;
    }
}
