// See https://aka.ms/new-console-template for more information

using  EspacioTareas;

List<Tareas> MiLista = new List<Tareas>();

int cantidad = IngresarOption();
for (int i = 0; i < cantidad; i++)
{
    Tareas valor1 = new Tareas(12,"asdasd", 123);
    MiLista.Add(valor1);
}

foreach (var item in MiLista)
{
    Console.WriteLine(item);
}


int IngresarOption(){
    int op;
    if(int.TryParse(Console.ReadLine(), out op)){
        return op;
    }else{
        Console.WriteLine("Error");
        return 9999;
    }
}
