using System.IO;
using System;


string? path;
int encontrado = 0;
do
{
    System.Console.WriteLine("Porfavor escribir el path del directoria a Analizar");
    path = Console.ReadLine();
    if (Directory.Exists(path))
    {
        encontrado = 1;
        string[] directorios = Directory.GetDirectories(path);
        string[] archivos = Directory.GetFiles(path);

        System.Console.WriteLine("Carpetas dentro de la ruta dada:");
        foreach (string directorio in directorios)
        {
            System.Console.WriteLine("  " + directorio.Remove(0, path.Length + 1));
        }
        System.Console.WriteLine("Archivos dentro de la ruta dada y su tamaño:");
        long tamanio;
        string nombre;
        DateTime fechaUltModificacion;
        var infoarchivos = new List<string>();
        foreach (string archivo in archivos)
        {
            var info = new FileInfo(archivo);
            tamanio = info.Length / 1024;
            nombre = info.Name;
            fechaUltModificacion = info.LastWriteTime;
            System.Console.WriteLine($"  {nombre} | {tamanio} KB");
            infoarchivos.Add($"{nombre};{tamanio};{fechaUltModificacion.ToString("yyyy-MM-dd HH:mm")}");
        }
        File.Create($"{path}\\reporte_archivos.csv").Close();
        File.WriteAllLines(Path.Combine(path, "reporte_archivos.csv"), infoarchivos);
    }
    else
    {
        System.Console.WriteLine("Ruta no encontrada");
    }
} while (encontrado == 0);