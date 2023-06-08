namespace EspacioTareas;

public class Tareas{
    private int tareaID;
    private string descripcion;
    private int duracion;

    public int TareaID { get => tareaID; set => tareaID = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public int Duracion { get => duracion; set => duracion = value; }
   // public Tareas(){}
    public Tareas(int tareaID, string descripcion, int duracion)
    {
        this.tareaID = tareaID;
        this.descripcion = descripcion;
        this.duracion = duracion;
    }

    public void Mostrar(){
        Console.WriteLine("ID de la tarea:"+TareaID);
        Console.WriteLine("Descripcion de tarea:"+Descripcion);
        Console.WriteLine("Duracion de tarea en hs:"+Duracion);
        
    }

}
