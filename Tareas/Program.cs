using Tareas;
using System.Text.Json;

HttpClient client = new HttpClient();
string url = "https://jsonplaceholder.typicode.com/todos/";
HttpResponseMessage response = await client.GetAsync(url);

if (response.IsSuccessStatusCode)
{
    string json = await response.Content.ReadAsStringAsync();
    List<Tarea>? tareas = JsonSerializer.Deserialize<List<Tarea>>(json);

    if (tareas != null)
    {
        Console.WriteLine("\n--Tareas Pendientes--");

        foreach (Tarea t in tareas)
        {
            if(!t.completada)
            {
                Console.WriteLine($"ID: {t.id}, Título: {t.titulo}");
            }
            
        }
        Console.WriteLine($"\n--Tareas Completadas--");
        
        foreach(Tarea t in tareas)
        {
            if(!t.completada)
            {
                Console.WriteLine($"ID: {t.id}, Título: {t.titulo}");
            }
        }
        string jsonOut = JsonSerializer.Serialize(tareas, new JsonSerializerOptions { WriteIndented = true});
        File.WriteAllText("tareas.json", jsonOut);
        Console.Write("\nArchivo tareas.json generado con exito");
    }
    else
    {
        Console.WriteLine("No se pudo deserializar la respuesta.");
    }
}
else
{
    Console.WriteLine($"Error en la respuesta: codigo {response.StatusCode}");
}