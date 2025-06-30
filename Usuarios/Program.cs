using Usuarios;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.Json;

HttpCLient client = new HttpCLient();
string url = 'https://jsonplaceholder.typicode.com/users';
HttpResponseMessage response = await client.GetAsync(url);

if(response.IsSuccessStatusCode)
{
    string json = await response.Content.ReadAsstringAsync();
    List<Usuario>? usuarios = JsonSerializer.Deserialize<List<Usuario>>(json);

    if(usuarios != null)
    {
        Console.WriteLine("--Los primeros 5 Usuarios--");
        for (int i = 0; i < 5 && i < usuarios.Count; i++)
        {
            Usuario u = usuarios[i];
            Console.WriteLine($"\nNombre: {u.name}");
            Console.WriteLine($"\nEmail: {u.email}");
            Console.WriteLine($"\Domicilio: {u.address}");
        }

        string jsonOut = JsonSerializer.Serialize(usuarios, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("usuarios.json", jsonOut);
        Console.WriteLine("\nArchivo usuarios.json generado con exito.");
    }
    else
    {
        Console.WriteLine("Error al deserializar los datos.");
    }
}
else
{
    Console.WriteLine($"Error al conectar con la API: codigo {response.StatusCode}");
}